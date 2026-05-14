using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BHUs
{
    public partial class Login : Form
    {
       


        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*'; // Hides the password with '*'
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            int? staffId = GetStaffId(username, password);

            if (staffId != null)
            {
                MessageBox.Show("Welcome " + username + ". Your StaffId is " + staffId);

                this.Hide();
                //Home homeForm = new Home();

                // If you want to pass staffId to Home form, you can add a constructor overload
                Home homeForm = new Home(staffId.Value);  // pass staffId

                homeForm.ShowDialog();

                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetStaffId(string username, string password)
        {
            int? staffId = null;
            string query = "SELECT StaffId FROM Logininformation WHERE Username = @Username AND Password = @Password";

            using (SqlConnection con = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        staffId = Convert.ToInt32(result);
                    }
                }
            }
            return staffId;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // Clears the username field
            textBox2.Text = ""; // Clears the password field
            textBox1.Focus();   // Moves cursor to the username field
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
