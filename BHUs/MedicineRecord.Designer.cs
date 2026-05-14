namespace BHUs
{
    partial class MedicineRecord
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBoxsearch = new TextBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            tquantitytxt = new Label();
            nametxt = new TextBox();
            typetxt = new TextBox();
            totalquantity = new TextBox();
            Rquantitytxt = new TextBox();
            label5 = new Label();
            btnupdate = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(700, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(245, 216);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            button1.Location = new Point(232, 196);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(450, 196);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            button3.Location = new Point(726, 231);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Search";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBoxsearch
            // 
            textBoxsearch.Location = new Point(566, 232);
            textBoxsearch.Name = "textBoxsearch";
            textBoxsearch.Size = new Size(154, 23);
            textBoxsearch.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(66, 272);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(537, 202);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label1.Location = new Point(52, 41);
            label1.Name = "label1";
            label1.Size = new Size(48, 16);
            label1.TabIndex = 6;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label2.Location = new Point(359, 41);
            label2.Name = "label2";
            label2.Size = new Size(43, 16);
            label2.TabIndex = 7;
            label2.Text = "Type";
            // 
            // tquantitytxt
            // 
            tquantitytxt.AutoSize = true;
            tquantitytxt.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            tquantitytxt.Location = new Point(11, 92);
            tquantitytxt.Name = "tquantitytxt";
            tquantitytxt.Size = new Size(103, 16);
            tquantitytxt.TabIndex = 9;
            tquantitytxt.Text = "Total Quantity";
            // 
            // nametxt
            // 
            nametxt.Location = new Point(117, 34);
            nametxt.Name = "nametxt";
            nametxt.Size = new Size(190, 23);
            nametxt.TabIndex = 10;
            nametxt.KeyPress += textBoxAlpabatic_KeyPress;
            // 
            // typetxt
            // 
            typetxt.Location = new Point(436, 39);
            typetxt.Name = "typetxt";
            typetxt.Size = new Size(190, 23);
            typetxt.TabIndex = 11;
            typetxt.KeyPress += textBoxAlpabatic_KeyPress;
            // 
            // totalquantity
            // 
            totalquantity.Location = new Point(117, 85);
            totalquantity.Name = "totalquantity";
            totalquantity.Size = new Size(190, 23);
            totalquantity.TabIndex = 13;
            totalquantity.TextChanged += dosagetxt_TextChanged;
            totalquantity.KeyPress += textBoxNumeric_KeyPress;
            // 
            // Rquantitytxt
            // 
            Rquantitytxt.Location = new Point(436, 90);
            Rquantitytxt.Name = "Rquantitytxt";
            Rquantitytxt.Size = new Size(190, 23);
            Rquantitytxt.TabIndex = 13;
            Rquantitytxt.TextChanged += dosagetxt_TextChanged;
            Rquantitytxt.KeyPress += textBoxNumeric_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label5.Location = new Point(348, 97);
            label5.Name = "label5";
            label5.Size = new Size(82, 16);
            label5.TabIndex = 9;
            label5.Text = "R_Quantity";
            label5.Click += label5_Click;
            // 
            // btnupdate
            // 
            btnupdate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnupdate.Location = new Point(348, 196);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(82, 23);
            btnupdate.TabIndex = 14;
            btnupdate.Text = "UPDATE";
            btnupdate.UseVisualStyleBackColor = true;
            btnupdate.Click += btnupdate_Click;
            // 
            // MedicineRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 510);
            Controls.Add(btnupdate);
            Controls.Add(Rquantitytxt);
            Controls.Add(totalquantity);
            Controls.Add(typetxt);
            Controls.Add(nametxt);
            Controls.Add(label5);
            Controls.Add(tquantitytxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(textBoxsearch);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "MedicineRecord";
            Text = "MedicalRecord";
            Load += MedicineRecord_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBoxsearch;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label tquantitytxt;
        private TextBox nametxt;
        private TextBox typetxt;
        private TextBox totalquantity;
        private TextBox Rquantitytxt;
        private Label label5;
        private Button btnupdate;
    }
}