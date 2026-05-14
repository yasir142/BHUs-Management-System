using System.Data;
using Microsoft.Data.SqlClient;

namespace BHUs
{
    public partial class PatientInformation : Form
    {

        private int currentStaffId;
        private object staffId;

        public PatientInformation(int staffId)
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
            dataGridView1.ReadOnly = false; // Allow editing for update
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT PatientId,staffId, Name, Date, Contact, Building, RoomNo, Symptoms, Perception FROM PatientInformation WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(PatientId.Text))
            {
                query += " AND PatientId = @PatientId";
                parameters.Add(new SqlParameter("@PatientId", PatientId.Text.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(currentStaffId.ToString()))
            {
                query += " AND staffId = @staffId";
                parameters.Add(new SqlParameter("@StaffId", currentStaffId.ToString().Trim()));
                {
                    if (!string.IsNullOrWhiteSpace(Name.Text))
                    {
                        query += " AND Name LIKE @Name";
                        parameters.Add(new SqlParameter("@Name", "%" + Name.Text.Trim() + "%"));
                    }
                    if (!string.IsNullOrWhiteSpace(Contact.Text))
                    {
                        query += " AND Contact LIKE @Contact";
                        parameters.Add(new SqlParameter("@Contact", "%" + Contact.Text.Trim() + "%"));
                    }
                    if (!string.IsNullOrWhiteSpace(RoomNo.Text))
                    {
                        query += " AND RoomNo = @RoomNo";
                        parameters.Add(new SqlParameter("@RoomNo", RoomNo.Text.Trim()));
                    }

                    using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddRange(parameters.ToArray());

                        try
                        {
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                                dataGridView1.ReadOnly = false; // Allow editing for update
                            }
                            else
                            {
                                MessageBox.Show("No matching records found.");
                                dataGridView1.DataSource = null;
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
                

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells["PatientId"].Value != null)
                {
                    string patientId = row.Cells["PatientId"].Value.ToString();
                    string name = row.Cells["Name"].Value?.ToString();
                    string contact = row.Cells["Contact"].Value?.ToString();
                    string building = row.Cells["Building"].Value?.ToString();
                    string roomNo = row.Cells["RoomNo"].Value?.ToString();
                    string symptoms = row.Cells["Symptoms"].Value?.ToString();
                    string perception = row.Cells["Perception"].Value?.ToString();
                    // Handle Date properly
                    object dateValue = row.Cells["Date"].Value;
                    DateTime date;

                    string query = "UPDATE PatientInformation SET Name=@Name, Date=@Date, Contact=@Contact, Building=@Building, RoomNo=@RoomNo, Symptoms=@Symptoms, Perception=@Perception WHERE PatientId=@PatientId";

                    using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@PatientId", patientId);
                        command.Parameters.AddWithValue("@Name", name);
                        if (dateValue != null && DateTime.TryParse(dateValue.ToString(), out date))
                            command.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                        else
                            command.Parameters.Add("@Date", SqlDbType.Date).Value = DBNull.Value; ;
                        command.Parameters.AddWithValue("@Contact", contact);
                        command.Parameters.AddWithValue("@Building", building);
                        command.Parameters.AddWithValue("@RoomNo", roomNo);
                        command.Parameters.AddWithValue("@Symptoms", symptoms);
                        command.Parameters.AddWithValue("@Perception", perception);

                        try
                        {
                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Record updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Update failed.");
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

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM PatientInformation WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(PatientId.Text))
            {
                query += " AND PatientId = @PatientId";
                parameters.Add(new SqlParameter("@PatientId", PatientId.Text.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(Name.Text))
            {
                query += " AND Name LIKE @Name";
                parameters.Add(new SqlParameter("@Name", "%" + Name.Text.Trim() + "%"));
            }
            if (!string.IsNullOrWhiteSpace(Contact.Text))
            {
                query += " AND Contact LIKE @Contact";
                parameters.Add(new SqlParameter("@Contact", "%" + Contact.Text.Trim() + "%"));
            }
            if (!string.IsNullOrWhiteSpace(RoomNo.Text))
            {
                query += " AND RoomNo = @RoomNo";
                parameters.Add(new SqlParameter("@RoomNo", RoomNo.Text.Trim()));
            }

            if (parameters.Count == 0)
            {
                MessageBox.Show("Please enter at least one search criteria to delete records.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete the matching record(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddRange(parameters.ToArray());

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Record(s) deleted successfully.");
                            dataGridView1.DataSource = null; // Clear DataGridView after delete
                        }
                        else
                        {
                            MessageBox.Show("No matching records found to delete.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void PatientInformation_Load(object sender, EventArgs e)
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
            // Allow control keys (e.g., Backspace) and digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numeric values are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
