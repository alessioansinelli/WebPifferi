namespace ImageSender
{
	partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPhotogallery = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFolderImmagini = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitolo = new System.Windows.Forms.TextBox();
            this.selectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgression = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvFileList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotogallery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPhotogallery);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFolderImmagini);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTitolo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Photogallery Manager";
            // 
            // dgvPhotogallery
            // 
            this.dgvPhotogallery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhotogallery.Location = new System.Drawing.Point(372, 50);
            this.dgvPhotogallery.Name = "dgvPhotogallery";
            this.dgvPhotogallery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhotogallery.Size = new System.Drawing.Size(209, 150);
            this.dgvPhotogallery.TabIndex = 11;
            this.dgvPhotogallery.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhotogallery_CellContentClick);
            this.dgvPhotogallery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhotogallery_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(311, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Cerca";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(233, 50);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(71, 20);
            this.txtID.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Salva";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Seleziona";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seleziona Cartella Immagini";
            // 
            // txtFolderImmagini
            // 
            this.txtFolderImmagini.Location = new System.Drawing.Point(6, 167);
            this.txtFolderImmagini.Name = "txtFolderImmagini";
            this.txtFolderImmagini.Size = new System.Drawing.Size(221, 20);
            this.txtFolderImmagini.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrizione Galleria";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 90);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(359, 58);
            this.txtDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Titolo Galleria";
            // 
            // txtTitolo
            // 
            this.txtTitolo.Location = new System.Drawing.Point(6, 50);
            this.txtTitolo.Name = "txtTitolo";
            this.txtTitolo.Size = new System.Drawing.Size(221, 20);
            this.txtTitolo.TabIndex = 0;
            // 
            // selectFolder
            // 
            this.selectFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 350);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(587, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 1;
            // 
            // lblProgression
            // 
            this.lblProgression.AutoSize = true;
            this.lblProgression.Location = new System.Drawing.Point(12, 335);
            this.lblProgression.Name = "lblProgression";
            this.lblProgression.Size = new System.Drawing.Size(29, 13);
            this.lblProgression.TabIndex = 4;
            this.lblProgression.Text = "Prog";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(306, 222);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(293, 110);
            this.textBox1.TabIndex = 5;
            // 
            // dgvFileList
            // 
            this.dgvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileList.Location = new System.Drawing.Point(12, 223);
            this.dgvFileList.Name = "dgvFileList";
            this.dgvFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileList.Size = new System.Drawing.Size(288, 109);
            this.dgvFileList.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 385);
            this.Controls.Add(this.dgvFileList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblProgression);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Photogallery Upload";
            this.Load += new System.EventHandler(this.LoadSender);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotogallery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.FolderBrowserDialog selectFolder;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFolderImmagini;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTitolo;
        private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGridView dgvPhotogallery;
        private System.Windows.Forms.Label lblProgression;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvFileList;
	}
}

