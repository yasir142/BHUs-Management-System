using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BHUs
{
    public partial class Home : Form
    {
        private int currentStaffId; //  store logged-in staff

        public Home(int staffId)
        {
            InitializeComponent();
            currentStaffId = staffId;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            PatientRegistration patientRegistrationForm = new PatientRegistration(currentStaffId);
            patientRegistrationForm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PatientRegistration patientRegistrationForm = new PatientRegistration(currentStaffId);
            patientRegistrationForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PatientInformation patientInformationForm = new PatientInformation(currentStaffId);
            patientInformationForm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            StaffInformation staffInformationForm = new StaffInformation(currentStaffId);
            staffInformationForm.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ViewPatientCheckOut viewPatientCheckOutForm = new ViewPatientCheckOut();
            viewPatientCheckOutForm.ShowDialog();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            MedicineRecord medicalRecord = new MedicineRecord(currentStaffId);
            medicalRecord.ShowDialog();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            MedicineRecord medicalRecord = new MedicineRecord(currentStaffId);
            medicalRecord.ShowDialog();
        }
    }
}

