using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BHUs
{
    public partial class PatientRegistration : Form
    {
        
       

        private int currentStaffId;
        public PatientRegistration(int staffId)
        {
            InitializeComponent();
            currentStaffId = staffId;
            textBoxName.KeyPress += textBoxName_KeyPress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Basic mandatory field checks
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxAge.Text) ||
                string.IsNullOrWhiteSpace(textBoxContact.Text) ||
                string.IsNullOrWhiteSpace(textBoxBuilding.Text) ||
                string.IsNullOrWhiteSpace(textBoxRoomNo.Text) ||
                string.IsNullOrWhiteSpace(comboBoxStatus.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrice.Text) ||
                string.IsNullOrWhiteSpace(textBoxPerception.Text) ||
                string.IsNullOrWhiteSpace(textBoxqgiven.Text))
            {
                MessageBox.Show("All fields are mandatory! Please fill in all required information.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // take only alphabets and spaces
            string name = textBoxName.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Invalid Name! Only alphabets are allowed.",
                                "Input Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validate Age
            int age;
            if (!int.TryParse(textBoxAge.Text, out age))
            {
                MessageBox.Show("Invalid Age! Please enter a valid number.");
                return;
            }

            // Gender check
            string gender = string.Empty;
            if (radioButton1.Checked)
                gender = "Male";
            else if (radioButton2.Checked)
                gender = "Female";
            else
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

            DateTime date = dateTimePickerDate.Value;
            string contact = textBoxContact.Text;
            string building = textBoxBuilding.Text;
            string roomNo = textBoxRoomNo.Text;
            string status = comboBoxStatus.Text;

            decimal price;
            if (!decimal.TryParse(textBoxPrice.Text, out price))
            {
                MessageBox.Show("Invalid Price! Please enter a valid decimal number.");
                return;
            }

            string perception = textBoxPerception.Text;

            // Get selected symptoms
            List<string> selectedStatuses = new List<string>();
            foreach (var item in Symptoms.CheckedItems)
            {
                selectedStatuses.Add(item.ToString());
            }
            string SymptomsList = string.Join(", ", selectedStatuses);

            int quantityGiven;
            if (!int.TryParse(textBoxqgiven.Text, out quantityGiven))
            {
                MessageBox.Show("Invalid Quantity!");
                return;
            }
            // Check medicine stock before inserting
            if (!ValidateMedicineStock(textBoxPerception.Text, int.Parse(textBoxqgiven.Text)))
            {
                return; // stop if medicine not available
            }

            // Proceed with database insertion
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("InsertPatientAndMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Patient parameters
                    command.Parameters.AddWithValue("@StaffId", currentStaffId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Contact", contact);
                    command.Parameters.AddWithValue("@Building", building);
                    command.Parameters.AddWithValue("@RoomNo", roomNo);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Symptoms", SymptomsList);
                    command.Parameters.AddWithValue("@Perception", perception);

                    // Medicine parameters
                    command.Parameters.AddWithValue("@MedicineName", perception);
                    command.Parameters.AddWithValue("@QuantityGiven", quantityGiven);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Patient and Medicine record added successfully!");

                        // Clear all fields
                        textBoxName.Clear();
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        textBoxAge.Clear();
                        dateTimePickerDate.Value = DateTime.Now;
                        textBoxContact.Clear();
                        textBoxBuilding.Clear();
                        textBoxRoomNo.Clear();
                        textBoxPrice.Clear();
                        textBoxPerception.Clear();
                        Symptoms.ClearSelected();
                        textBoxqgiven.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private bool ValidateMedicineStock(string perception, int quantityGiven)
        {
            // Split the comma-separated medicine names
            string[] medicineNames = perception.Split(',');

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();

                foreach (string rawName in medicineNames)
                {
                    string medicineName = rawName.Trim();
                    if (string.IsNullOrWhiteSpace(medicineName))
                        continue;

                    string query = "SELECT RemainingQuantity FROM Medicines WHERE Name = @Name";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", medicineName);

                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show($"Medicine '{medicineName}' does not exist in stock.",
                                            "Medicine Not Found",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return false;
                        }

                        int remaining = Convert.ToInt32(result);
                        if (remaining < quantityGiven)
                        {
                            MessageBox.Show($"Not enough stock for '{medicineName}'.\n" +
                                            $"Available: {remaining}, Required: {quantityGiven}",
                                            "Insufficient Stock",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }

            return true; // All medicines are available
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //textBoxPatientId.Clear();
            textBoxName.Clear();
            radioButton1.Checked = false;  // Uncheck the gender radio buttons
            radioButton2.Checked = false;
            textBoxAge.Clear();
            dateTimePickerDate.Value = DateTime.Now;
            textBoxContact.Clear();
            textBoxBuilding.Clear();
            textBoxRoomNo.Clear();
            comboBoxStatus.Clear();
            textBoxPrice.Clear();
            textBoxPerception.Clear();
            // **Clear CheckedListBox selections**
            for (int i = 0; i < Symptoms.Items.Count; i++)
            {
                Symptoms.SetItemChecked(i, false);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxContact_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, control keys (like Backspace), and spaces
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Block the key
                MessageBox.Show("Only alphabets are allowed in the Name field.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBoxAlpabatic_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, control keys (like Backspace), and spaces
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Only alphabets are allowed in the Name field.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBoxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // take space and digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numeric values are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBoxContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Allow only digits and control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numeric values are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Limit to exactly 12 digits
            if (!char.IsControl(e.KeyChar)) // ignore control keys (like Backspace)
            {
                if (textBox.Text.Length >= 12)
                {
                    e.Handled = true; // stop typing more characters
                    MessageBox.Show("You can enter only 12 digits.", "Input Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }

        private void textBoxContact_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Check if entered digits are less than 12
            if (textBox.Text.Length > 0 && textBox.Text.Length < 12)
            {
                MessageBox.Show("Please enter exactly 12 digits.", "Invalid Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus(); // keep focus on same textbox
            }
        }

    }

}



