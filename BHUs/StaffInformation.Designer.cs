namespace BHUs
{
    partial class StaffInformation
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
            contacttext = new TextBox();
            positiontext = new TextBox();
            nametext = new TextBox();
            staffidtext = new TextBox();
            label12 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Add = new Button();
            Rest = new Button();
            pictureBox1 = new PictureBox();
            Lable7 = new Label();
            lablr8 = new Label();
            usernametext = new TextBox();
            passwordtext = new TextBox();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            searchtxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(382, 7);
            label1.Name = "label1";
            label1.Size = new Size(158, 24);
            label1.TabIndex = 0;
            label1.Text = "Staff Information";
            // 
            // contacttext
            // 
            contacttext.Location = new Point(512, 85);
            contacttext.Margin = new Padding(3, 2, 3, 2);
            contacttext.Name = "contacttext";
            contacttext.Size = new Size(219, 23);
            contacttext.TabIndex = 28;
            contacttext.KeyPress += textBoxNumeric_KeyPress;
            // 
            // positiontext
            // 
            positiontext.Location = new Point(512, 46);
            positiontext.Margin = new Padding(3, 2, 3, 2);
            positiontext.Name = "positiontext";
            positiontext.Size = new Size(219, 23);
            positiontext.TabIndex = 27;
            positiontext.KeyPress += textBoxAlpabatic_KeyPress;
            // 
            // nametext
            // 
            nametext.Location = new Point(140, 85);
            nametext.Margin = new Padding(3, 2, 3, 2);
            nametext.Name = "nametext";
            nametext.Size = new Size(219, 23);
            nametext.TabIndex = 26;
            nametext.KeyPress += textBoxAlpabatic_KeyPress;
            // 
            // staffidtext
            // 
            staffidtext.Location = new Point(140, 46);
            staffidtext.Margin = new Padding(3, 2, 3, 2);
            staffidtext.Name = "staffidtext";
            staffidtext.Size = new Size(219, 23);
            staffidtext.TabIndex = 25;
            staffidtext.TextChanged += staffidtext_TextChanged;
            staffidtext.KeyPress += textBoxNumeric_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label12.Location = new Point(10, 171);
            label12.Name = "label12";
            label12.Size = new Size(58, 16);
            label12.TabIndex = 24;
            label12.Text = "Gender";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            radioButton2.Location = new Point(230, 170);
            radioButton2.Margin = new Padding(3, 2, 3, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(77, 20);
            radioButton2.TabIndex = 23;
            radioButton2.TabStop = true;
            radioButton2.Text = "Female";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            radioButton1.Location = new Point(140, 170);
            radioButton1.Margin = new Padding(3, 2, 3, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(59, 20);
            radioButton1.TabIndex = 22;
            radioButton1.TabStop = true;
            radioButton1.Text = "Male";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label6.Location = new Point(382, 87);
            label6.Name = "label6";
            label6.Size = new Size(59, 16);
            label6.TabIndex = 21;
            label6.Text = "Contact";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label4.Location = new Point(382, 50);
            label4.Name = "label4";
            label4.Size = new Size(63, 16);
            label4.TabIndex = 20;
            label4.Text = "Position";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label3.Location = new Point(10, 90);
            label3.Name = "label3";
            label3.Size = new Size(48, 16);
            label3.TabIndex = 19;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label2.Location = new Point(10, 52);
            label2.Name = "label2";
            label2.Size = new Size(55, 16);
            label2.TabIndex = 18;
            label2.Text = "Staff Id";
            // 
            // Add
            // 
            Add.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            Add.Location = new Point(237, 205);
            Add.Margin = new Padding(3, 2, 3, 2);
            Add.Name = "Add";
            Add.Size = new Size(82, 22);
            Add.TabIndex = 29;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Rest
            // 
            Rest.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            Rest.Location = new Point(431, 205);
            Rest.Margin = new Padding(3, 2, 3, 2);
            Rest.Name = "Rest";
            Rest.Size = new Size(82, 22);
            Rest.TabIndex = 32;
            Rest.Text = "Reset";
            Rest.UseVisualStyleBackColor = true;
            Rest.Click += Rest_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(764, 7);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(248, 218);
            pictureBox1.TabIndex = 33;
            pictureBox1.TabStop = false;
            // 
            // Lable7
            // 
            Lable7.AutoSize = true;
            Lable7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            Lable7.Location = new Point(10, 128);
            Lable7.Name = "Lable7";
            Lable7.Size = new Size(78, 16);
            Lable7.TabIndex = 34;
            Lable7.Text = "Username";
            // 
            // lablr8
            // 
            lablr8.AutoSize = true;
            lablr8.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            lablr8.Location = new Point(382, 128);
            lablr8.Name = "lablr8";
            lablr8.Size = new Size(75, 16);
            lablr8.TabIndex = 35;
            lablr8.Text = "Password";
            // 
            // usernametext
            // 
            usernametext.Location = new Point(140, 125);
            usernametext.Margin = new Padding(3, 2, 3, 2);
            usernametext.Name = "usernametext";
            usernametext.Size = new Size(219, 23);
            usernametext.TabIndex = 36;
            usernametext.KeyPress += textBoxAlpabatic_KeyPress;
            // 
            // passwordtext
            // 
            passwordtext.Location = new Point(512, 125);
            passwordtext.Margin = new Padding(3, 2, 3, 2);
            passwordtext.Name = "passwordtext";
            passwordtext.PasswordChar = '*';
            passwordtext.Size = new Size(219, 23);
            passwordtext.TabIndex = 37;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 267);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(909, 141);
            dataGridView1.TabIndex = 38;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label5.Location = new Point(630, 241);
            label5.Name = "label5";
            label5.Size = new Size(56, 16);
            label5.TabIndex = 39;
            label5.Text = "Search";
            // 
            // searchtxt
            // 
            searchtxt.Location = new Point(707, 238);
            searchtxt.Margin = new Padding(3, 2, 3, 2);
            searchtxt.Name = "searchtxt";
            searchtxt.Size = new Size(237, 23);
            searchtxt.TabIndex = 40;
            searchtxt.TextChanged += textBox1_TextChanged;
            // 
            // StaffInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 526);
            Controls.Add(searchtxt);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(passwordtext);
            Controls.Add(usernametext);
            Controls.Add(lablr8);
            Controls.Add(Lable7);
            Controls.Add(pictureBox1);
            Controls.Add(Rest);
            Controls.Add(Add);
            Controls.Add(contacttext);
            Controls.Add(positiontext);
            Controls.Add(nametext);
            Controls.Add(staffidtext);
            Controls.Add(label12);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "StaffInformation";
            Text = "StaffInformation";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox contacttext;
        private TextBox positiontext;
        private TextBox nametext;
        private TextBox staffidtext;
        private Label label12;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button Add;
        private Button update;
        private Button Rest;
        private PictureBox pictureBox1;
        private Label Lable7;
        private Label lablr8;
        private TextBox usernametext;
        private TextBox passwordtext;
        private DataGridView dataGridView1;
        private Label label5;
        private TextBox searchtxt;
    }
}