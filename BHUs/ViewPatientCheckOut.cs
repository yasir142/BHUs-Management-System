using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BHUs
{
    public partial class ViewPatientCheckOut : Form
    {
       

        private DataTable staffDataTable = new DataTable(); // Global DataTable

        public ViewPatientCheckOut()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStaffData();
        }

        private void LoadStaffData()
        {
            string query = @"SELECT PatientId, Name, Age, Contact, Building, RoomNo, Symptoms, Perception FROM PatientInformation WITH(NOLOCK)";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                try
                {
                    connection.Open();
                    staffDataTable.Clear(); // Ensure no duplicate data
                    adapter.Fill(staffDataTable);
                    dataGridView1.DataSource = staffDataTable; 
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
                dv.RowFilter = $"CONVERT(PatientId, 'System.String') LIKE '%{searchValue}%' OR " +
                               $"Name LIKE '%{searchValue}%' OR " +
                               $"CONVERT(Age, 'System.String') LIKE '%{searchValue}%' OR " +
                               $"Contact LIKE '%{searchValue}%' OR " +
                               $"Building LIKE '%{searchValue}%' OR " +
                               $"CONVERT(RoomNo, 'System.String') LIKE '%{searchValue}%' OR " +
                               $"Symptoms LIKE '%{searchValue}%' OR " +
                               $"Perception LIKE '%{searchValue}%'";
                dataGridView1.DataSource = dv;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patientId = ""; //textBoxPatientId.Text.Trim(); // Get PatientId from textbox

            if (string.IsNullOrEmpty(patientId))
            {
                MessageBox.Show("Please enter a Patient ID to search.");
                return;
            }

            
            string query = "SELECT PatientId, Name, Date, Contact, Building, RoomNo, Symptoms, Perception FROM PatientInformation WHERE PatientId = @PatientId";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientId", patientId);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt; // Display data in DataGridView
                        dataGridView1.ReadOnly = true; // Prevent editing in DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No patient found with this ID.");
                        dataGridView1.DataSource = null; // Clear DataGridView if no record found
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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
            // Allow control keys (e.g., Backspace) and digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numeric values are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}

    