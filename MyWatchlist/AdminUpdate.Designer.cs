namespace MyWatchlist
{
    partial class AdminUpdate
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
            this.txtSeasons = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnActor = new System.Windows.Forms.Button();
            this.btnCreator = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbActors = new System.Windows.Forms.ListBox();
            this.lbCreators = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSeasons
            // 
            this.txtSeasons.Location = new System.Drawing.Point(22, 64);
            this.txtSeasons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSeasons.Name = "txtSeasons";
            this.txtSeasons.Size = new System.Drawing.Size(208, 27);
            this.txtSeasons.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of seasons:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(22, 142);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(208, 184);
            this.txtDescription.TabIndex = 4;
            // 
            // btnActor
            // 
            this.btnActor.BackColor = System.Drawing.Color.LightBlue;
            this.btnActor.Location = new System.Drawing.Point(331, 79);
            this.btnActor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnActor.Name = "btnActor";
            this.btnActor.Size = new System.Drawing.Size(127, 37);
            this.btnActor.TabIndex = 5;
            this.btnActor.Text = "Add new actor";
            this.btnActor.UseVisualStyleBackColor = false;
            this.btnActor.Click += new System.EventHandler(this.btnActor_Click);
            // 
            // btnCreator
            // 
            this.btnCreator.BackColor = System.Drawing.Color.LightBlue;
            this.btnCreator.Location = new System.Drawing.Point(545, 79);
            this.btnCreator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreator.Name = "btnCreator";
            this.btnCreator.Size = new System.Drawing.Size(142, 37);
            this.btnCreator.TabIndex = 6;
            this.btnCreator.Text = "Add new creator";
            this.btnCreator.UseVisualStyleBackColor = false;
            this.btnCreator.Click += new System.EventHandler(this.btnCreator_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(298, 394);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(109, 44);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lbActors
            // 
            this.lbActors.FormattingEnabled = true;
            this.lbActors.ItemHeight = 19;
            this.lbActors.Location = new System.Drawing.Point(307, 132);
            this.lbActors.Name = "lbActors";
            this.lbActors.Size = new System.Drawing.Size(182, 194);
            this.lbActors.TabIndex = 8;
            // 
            // lbCreators
            // 
            this.lbCreators.FormattingEnabled = true;
            this.lbCreators.ItemHeight = 19;
            this.lbCreators.Location = new System.Drawing.Point(530, 132);
            this.lbCreators.Name = "lbCreators";
            this.lbCreators.Size = new System.Drawing.Size(179, 194);
            this.lbCreators.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Location = new System.Drawing.Point(810, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add award for actor";
            this.button1.UseVisualStyleBackColor = false;
          
            // 
            // AdminUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1103, 482);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbCreators);
            this.Controls.Add(this.lbActors);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreator);
            this.Controls.Add(this.btnActor);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSeasons);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update TV show";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSeasons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnActor;
        private System.Windows.Forms.Button btnCreator;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListBox lbActors;
        private System.Windows.Forms.ListBox lbCreators;
        private System.Windows.Forms.Button button1;
    }
}