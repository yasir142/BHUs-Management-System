using System.Data;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;

namespace BHUs
{
    public partial class MedicineRecord : Form
    {
       

        private int currentStaffId;

        public MedicineRecord(int staffId)
        {
            InitializeComponent();
            InitializeDataGridView();
            currentStaffId = staffId;
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = false;
            // Defensive check
            if (dataGridView1.Columns.Contains("MedicineId"))
            {
                dataGridView1.Columns["MedicineId"].ReadOnly = true;
            }

        }

        private void MedicineRecord_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData(string name = "", string type = "")
        {
            string query = "SELECT * FROM Medicines WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query += " AND Name LIKE @Name";
                parameters.Add(new SqlParameter("@Name", "%" + name + "%"));
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query += " AND Type LIKE @Type";
                parameters.Add(new SqlParameter("@Type", "%" + type + "%"));
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddRange(parameters.ToArray());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        //  Add Medicine
        private void button1_Click(object sender, EventArgs e)
        {
            string name = nametxt.Text.Trim();
            string type = typetxt.Text.Trim();

            int totalQuantity = int.Parse(totalquantity.Text.Trim());
            int remaningQuantity = int.Parse(Rquantitytxt.Text.Trim());


            string query = "INSERT INTO Medicines (Name, Type, TotalQuantity, RemainingQuantity) VALUES (@Name, @Type, @TotalQuantity, @RemainingQuantity)";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@TotalQuantity", totalQuantity);

                cmd.Parameters.AddWithValue("@RemainingQuantity", remaningQuantity);

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine added successfully.");
                LoadData();
            }
            //  Clear input fields
            nametxt.Clear();
            typetxt.Clear();
            totalquantity.Clear();
            //usdquantitytxt.Clear();
            Rquantitytxt.Clear();

            //  Optionally, set focus back to the first field
            nametxt.Focus();
        }

        //   Delete Medicine
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            int medicineId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MedicineId"].Value);

            string query = "DELETE FROM Medicines WHERE MedicineId = @MedicineId";

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this medicine?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MedicineId", medicineId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine deleted successfully.");
                    LoadData();
                }
            }
        }

      
        

        private void button3_Click(object sender, EventArgs e)
        {
            string medicineId = textBoxsearch.Text.Trim(); //  you have a textbox for Medicine ID

            if (string.IsNullOrEmpty(medicineId))
            {
                MessageBox.Show("Please enter a Medicine ID to search.");
                return;
            }

            string query = "SELECT MedicineId, Name, Type, TotalQuantity, RemainingQuantity FROM Medicines WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", medicineId);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.ReadOnly = true; //  grid read-only for safety
                    }
                    else
                    {
                        MessageBox.Show("No medicine found with this ID.");
                        dataGridView1.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dosagetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            // Get the selected row
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            // Get updated values from the grid
            int medicineId = Convert.ToInt32(row.Cells["MedicineId"].Value);
            string name = row.Cells["Name"].Value?.ToString();
            string type = row.Cells["Type"].Value?.ToString();
            int totalQuantity = Convert.ToInt32(row.Cells["TotalQuantity"].Value);
            int remainingQuantity = Convert.ToInt32(row.Cells["RemainingQuantity"].Value);

            string query = @"UPDATE Medicines 
                     SET Name = @Name, 
                         Type = @Type, 
                         TotalQuantity = @TotalQuantity, 
                         RemainingQuantity = @RemainingQuantity 
                     WHERE MedicineId = @MedicineId";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MedicineId", medicineId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@TotalQuantity", totalQuantity);
                cmd.Parameters.AddWithValue("@RemainingQuantity", remainingQuantity);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Medicine record updated successfully.");
                        LoadData(); // Refresh the grid
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}

