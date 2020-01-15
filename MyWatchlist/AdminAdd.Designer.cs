namespace MyWatchlist
{
    partial class AdminAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReleased = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStreamingService = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSeasons = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbActors = new System.Windows.Forms.ListBox();
            this.btnActors = new System.Windows.Forms.Button();
            this.lbCreators = new System.Windows.Forms.ListBox();
            this.btnCreators = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbGenres = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(105, 39);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(178, 27);
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Released:";
            // 
            // txtReleased
            // 
            this.txtReleased.Location = new System.Drawing.Point(105, 112);
            this.txtReleased.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReleased.Name = "txtReleased";
            this.txtReleased.Size = new System.Drawing.Size(178, 27);
            this.txtReleased.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 380);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(304, 103);
            this.txtDescription.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 545);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Streaming";
            // 
            // txtStreamingService
            // 
            this.txtStreamingService.Location = new System.Drawing.Point(105, 545);
            this.txtStreamingService.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStreamingService.Name = "txtStreamingService";
            this.txtStreamingService.Size = new System.Drawing.Size(304, 27);
            this.txtStreamingService.TabIndex = 10;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpload.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(578, 368);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(150, 43);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload image";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 616);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Number of";
            // 
            // txtSeasons
            // 
            this.txtSeasons.Location = new System.Drawing.Point(105, 616);
            this.txtSeasons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSeasons.Name = "txtSeasons";
            this.txtSeasons.Size = new System.Drawing.Size(304, 27);
            this.txtSeasons.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(479, 39);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 281);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightBlue;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(531, 666);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(197, 44);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add to database";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(460, 433);
            this.txtImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(367, 27);
            this.txtImage.TabIndex = 17;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbActors
            // 
            this.lbActors.FormattingEnabled = true;
            this.lbActors.ItemHeight = 19;
            this.lbActors.Location = new System.Drawing.Point(888, 39);
            this.lbActors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbActors.Name = "lbActors";
            this.lbActors.Size = new System.Drawing.Size(317, 270);
            this.lbActors.TabIndex = 18;
            // 
            // btnActors
            // 
            this.btnActors.BackColor = System.Drawing.Color.LightBlue;
            this.btnActors.Location = new System.Drawing.Point(999, 325);
            this.btnActors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnActors.Name = "btnActors";
            this.btnActors.Size = new System.Drawing.Size(120, 48);
            this.btnActors.TabIndex = 19;
            this.btnActors.Text = "Add actor";
            this.btnActors.UseVisualStyleBackColor = false;
            this.btnActors.Click += new System.EventHandler(this.btnActors_Click);
            // 
            // lbCreators
            // 
            this.lbCreators.FormattingEnabled = true;
            this.lbCreators.ItemHeight = 19;
            this.lbCreators.Location = new System.Drawing.Point(888, 397);
            this.lbCreators.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbCreators.Name = "lbCreators";
            this.lbCreators.Size = new System.Drawing.Size(317, 232);
            this.lbCreators.TabIndex = 20;
            // 
            // btnCreators
            // 
            this.btnCreators.BackColor = System.Drawing.Color.LightBlue;
            this.btnCreators.Location = new System.Drawing.Point(996, 637);
            this.btnCreators.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreators.Name = "btnCreators";
            this.btnCreators.Size = new System.Drawing.Size(123, 45);
            this.btnCreators.TabIndex = 21;
            this.btnCreators.Text = "Add creator";
            this.btnCreators.UseVisualStyleBackColor = false;
            this.btnCreators.Click += new System.EventHandler(this.btnCreators_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 564);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 19);
            this.label6.TabIndex = 22;
            this.label6.Text = "service:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 637);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 23;
            this.label8.Text = "seasons:";
            // 
            // lbGenres
            // 
            this.lbGenres.FormattingEnabled = true;
            this.lbGenres.ItemHeight = 19;
            this.lbGenres.Location = new System.Drawing.Point(105, 183);
            this.lbGenres.Name = "lbGenres";
            this.lbGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbGenres.Size = new System.Drawing.Size(304, 175);
            this.lbGenres.TabIndex = 24;
            // 
            // AdminAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1218, 724);
            this.Controls.Add(this.lbGenres);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCreators);
            this.Controls.Add(this.lbCreators);
            this.Controls.Add(this.btnActors);
            this.Controls.Add(this.lbActors);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSeasons);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtStreamingService);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtReleased);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminHome";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReleased;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStreamingService;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSeasons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox lbActors;
        private System.Windows.Forms.Button btnActors;
        private System.Windows.Forms.ListBox lbCreators;
        private System.Windows.Forms.Button btnCreators;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbGenres;
    }
}