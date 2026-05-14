using System.Data;
using Microsoft.Data.SqlClient;

namespace BHUs
{
    public partial class StaffInformation : Form
    {

        private DataTable staffDataTable = new DataTable(); // Global DataTable
        private int currentStaffId;
        public StaffInformation(int staffId)
        {
            InitializeComponent();
            currentStaffId = staffId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStaffData();
            dataGridView1.Columns["StaffId"].ReadOnly = true; // Lock StaffId column
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string name = nametext.Text;
            string gender = radioButton1.Checked ? "Male" : "Female";
            string position = positiontext.Text;
            string contact = contacttext.Text;
            string username = usernametext.Text;
            string password = passwordtext.Text;

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert into StaffInformation and return new StaffId
                    string query1 = "INSERT INTO StaffInformation (Name, Gender, Position, Contact) " +
                                    "VALUES (@Name, @Gender, @Position, @Contact); " +
                                    "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    SqlCommand command1 = new SqlCommand(query1, connection, transaction);
                    command1.Parameters.AddWithValue("@Name", name);
                    command1.Parameters.AddWithValue("@Gender", gender);
                    command1.Parameters.AddWithValue("@Position", position);
                    command1.Parameters.AddWithValue("@Contact", contact);

                    int newStaffId = (int)command1.ExecuteScalar();  //  correct way to get new StaffId

                    // Insert into LoginInformation with the correct StaffId
                    string query2 = "INSERT INTO LoginInformation (StaffId, Username, Password) " +
                                    "VALUES (@StaffId, @Username, @Password)";

                    SqlCommand command2 = new SqlCommand(query2, connection, transaction);
                    command2.Parameters.AddWithValue("@StaffId", newStaffId);
                    command2.Parameters.AddWithValue("@Username", username);
                    command2.Parameters.AddWithValue("@Password", password);
                    command2.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Staff information added successfully!");
                    LoadStaffData();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        
        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.CurrentRow;

            // Get StaffId as a string (since it's NVARCHAR)
            string staffId = selectedRow.Cells["StaffId"].Value?.ToString();

            if (string.IsNullOrEmpty(staffId))
            {
                MessageBox.Show("Invalid StaffId. Please check the data.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells["staffId"].Value != null)
                {
                    string name = row.Cells["Name"].Value.ToString();
                    string position = row.Cells["Position"].Value.ToString();
                    string contact = row.Cells["Contact"].Value.ToString();
                    string username = row.Cells["Username"].Value.ToString();
                    string password = row.Cells["Password"].Value.ToString();

                    using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Update StaffInformation table
                            string query1 = "UPDATE StaffInformation SET Name=@Name, Position=@Position, Contact=@Contact WHERE StaffId=@StaffId";
                            using (SqlCommand command1 = new SqlCommand(query1, connection, transaction))
                            {
                                command1.Parameters.AddWithValue("@StaffId", staffId);
                                command1.Parameters.AddWithValue("@Name", name);
                                command1.Parameters.AddWithValue("@Position", position);
                                command1.Parameters.AddWithValue("@Contact", contact);
                                int staffUpdateResult = command1.ExecuteNonQuery();

                                if (staffUpdateResult == 0)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Failed to update StaffInformation. Rolling back changes.");
                                    return;
                                }
                            }

                            // Update LoginInformation table
                            string query2 = "UPDATE LoginInformation SET Username=@Username, Password=@Password WHERE StaffId=@StaffId";
                            using (SqlCommand command2 = new SqlCommand(query2, connection, transaction))
                            {
                                command2.Parameters.AddWithValue("@StaffId", staffId);
                                command2.Parameters.AddWithValue("@Username", username);
                                command2.Parameters.AddWithValue("@Password", password);
                                int loginUpdateResult = command2.ExecuteNonQuery();

                                if (loginUpdateResult == 0)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Failed to update LoginInformation. Rolling back changes.");
                                    return;
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Staff information updated successfully!");
                            LoadStaffData(); // Refresh DataGridView
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void Rest_Click(object sender, EventArgs e)
        {
            staffidtext.Clear();
            nametext.Clear();
            radioButton1.Checked = false;
            radioButton1.Checked = false;
            positiontext.Clear();
            contacttext.Clear();
            usernametext.Clear();
            passwordtext.Clear();
        }

        private void LoadStaffData()
        {
            string query = @"SELECT 
                  s.StaffId, 
                  s.Name, 
                  s.Gender, 
                  s.Position, 
                  s.Contact, 
                  l.Username, 
                  l.Password
               FROM StaffInformation s
               INNER JOIN LoginInformation l ON s.StaffId = l.StaffId";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                try
                {
                    connection.Open();
                    staffDataTable.Clear(); // Clear previous data
                    adapter.Fill(staffDataTable);
                    dataGridView1.DataSource = staffDataTable; // Bind to DataGridView                                                              
                    dataGridView1.Columns["StaffId"].ReadOnly = true;  // Lock StaffId column to prevent editing
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = searchtxt.Text.Trim().Replace("'", "''"); // Escape single quotes

            if (staffDataTable.Rows.Count > 0)
            {
                DataView dv = staffDataTable.DefaultView;
                // Apply RowFilter with correct syntax
                // Use CONVERT to ensure numeric columns can be searched as strings
                dv.RowFilter = $"CONVERT(StaffId, 'System.String') LIKE '%{searchValue}%' OR " +
                               $"Name LIKE '%{searchValue}%' OR " +
                               $"Contact LIKE '%{searchValue}%' OR " +
                               $"Username LIKE '%{searchValue}%' OR " +
                               $"Password LIKE '%{searchValue}%'";
                dataGridView1.DataSource = dv;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void staffidtext_TextChanged(object sender, EventArgs e)
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
    }
}
