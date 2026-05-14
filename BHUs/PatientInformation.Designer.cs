using System.Windows.Forms;

namespace BHUs
{
    partial class PatientInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            RoomNo = new TextBox();
            Contact = new TextBox();
            Name = new TextBox();
            PatientId = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label3 = new Label();
            label2 = new Label();
            SearchButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(352, 28);
            label1.Name = "label1";
            label1.Size = new Size(182, 24);
            label1.TabIndex = 0;
            label1.Text = "Patient Information";
            // 
            // RoomNo
            // 
            RoomNo.Location = new Point(616, 102);
            RoomNo.Margin = new Padding(3, 2, 3, 2);
            RoomNo.Name = "RoomNo";
            RoomNo.Size = new Size(219, 23);
            RoomNo.TabIndex = 31;
            // 
            // Contact
            // 
            Contact.Location = new Point(616, 72);
            Contact.Margin = new Padding(3, 2, 3, 2);
            Contact.Name = "Contact";
            Contact.Size = new Size(219, 23);
            Contact.TabIndex = 30;
            Contact.KeyPress += textBoxNumeric_KeyPress;
            // 
            // Name
            // 
            Name.Location = new Point(182, 116);
            Name.Margin = new Padding(3, 2, 3, 2);
            Name.Name = "Name";
            Name.Size = new Size(219, 23);
            Name.TabIndex = 29;
            Name.KeyPress += textBoxAlpabatic_KeyPress;
            // 
            // PatientId
            // 
            PatientId.Location = new Point(182, 77);
            PatientId.Margin = new Padding(3, 2, 3, 2);
            PatientId.Name = "PatientId";
            PatientId.Size = new Size(219, 23);
            PatientId.TabIndex = 28;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label10.Location = new Point(486, 107);
            label10.Name = "label10";
            label10.Size = new Size(72, 16);
            label10.TabIndex = 24;
            label10.Text = "Room No";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label9.Location = new Point(486, 77);
            label9.Name = "label9";
            label9.Size = new Size(59, 16);
            label9.TabIndex = 23;
            label9.Text = "Contact";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label3.Location = new Point(52, 121);
            label3.Name = "label3";
            label3.Size = new Size(48, 16);
            label3.TabIndex = 22;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label2.Location = new Point(52, 82);
            label2.Name = "label2";
            label2.Size = new Size(72, 16);
            label2.TabIndex = 21;
            label2.Text = "Patient Id";
            // 
            // SearchButton
            // 
            SearchButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            SearchButton.Location = new Point(284, 161);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(82, 22);
            SearchButton.TabIndex = 32;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            UpdateButton.Location = new Point(402, 161);
            UpdateButton.Margin = new Padding(3, 2, 3, 2);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(82, 22);
            UpdateButton.TabIndex = 33;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            DeleteButton.Location = new Point(521, 161);
            DeleteButton.Margin = new Padding(3, 2, 3, 2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(82, 22);
            DeleteButton.TabIndex = 34;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 222);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(879, 141);
            dataGridView1.TabIndex = 35;
            // 
            // PatientInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 518);
            Controls.Add(dataGridView1);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(SearchButton);
            Controls.Add(RoomNo);
            Controls.Add(Contact);
            Controls.Add(Name);
            Controls.Add(PatientId);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            //Name = "PatientInformation";
            Text = "PatientInformation";
            Load += PatientInformation_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox RoomNo;
        private TextBox Contact;
        private TextBox Name;
        private TextBox PatientId;
        private Label label10;
        private Label label9;
        private Label label3;
        private Label label2;
        private Button SearchButton;
        private Button UpdateButton;
        private Button DeleteButton;
        private DataGridView dataGridView1;
    }
}