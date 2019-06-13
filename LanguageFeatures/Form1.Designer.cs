namespace LanguageFeatures
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
            this.SimpleIteratorButton = new System.Windows.Forms.Button();
            this.OutSideTheBoxButton = new System.Windows.Forms.Button();
            this.BuildBurger = new System.Windows.Forms.Button();
            this.ClaimRecordBuilder1 = new System.Windows.Forms.Button();
            this.ClaimRecordBuilder2 = new System.Windows.Forms.Button();
            this.ClaimRecordBuilder3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SimpleIteratorButton
            // 
            this.SimpleIteratorButton.Location = new System.Drawing.Point(24, 47);
            this.SimpleIteratorButton.Name = "SimpleIteratorButton";
            this.SimpleIteratorButton.Size = new System.Drawing.Size(161, 23);
            this.SimpleIteratorButton.TabIndex = 0;
            this.SimpleIteratorButton.Text = "Simple Iterator";
            this.SimpleIteratorButton.UseVisualStyleBackColor = true;
            this.SimpleIteratorButton.Click += new System.EventHandler(this.SimpleIteratorButton_Click);
            // 
            // OutSideTheBoxButton
            // 
            this.OutSideTheBoxButton.Location = new System.Drawing.Point(24, 12);
            this.OutSideTheBoxButton.Name = "OutSideTheBoxButton";
            this.OutSideTheBoxButton.Size = new System.Drawing.Size(161, 23);
            this.OutSideTheBoxButton.TabIndex = 1;
            this.OutSideTheBoxButton.Text = "Outside the box";
            this.OutSideTheBoxButton.UseVisualStyleBackColor = true;
            this.OutSideTheBoxButton.Click += new System.EventHandler(this.OutSideTheBoxButton_Click);
            // 
            // BuildBurger
            // 
            this.BuildBurger.Location = new System.Drawing.Point(24, 82);
            this.BuildBurger.Name = "BuildBurger";
            this.BuildBurger.Size = new System.Drawing.Size(161, 23);
            this.BuildBurger.TabIndex = 2;
            this.BuildBurger.Text = "Build burger";
            this.BuildBurger.UseVisualStyleBackColor = true;
            this.BuildBurger.Click += new System.EventHandler(this.BuildBurger_Click);
            // 
            // ClaimRecordBuilder1
            // 
            this.ClaimRecordBuilder1.Location = new System.Drawing.Point(24, 117);
            this.ClaimRecordBuilder1.Name = "ClaimRecordBuilder1";
            this.ClaimRecordBuilder1.Size = new System.Drawing.Size(161, 23);
            this.ClaimRecordBuilder1.TabIndex = 3;
            this.ClaimRecordBuilder1.Text = "Claim Builder 1";
            this.ClaimRecordBuilder1.UseVisualStyleBackColor = true;
            this.ClaimRecordBuilder1.Click += new System.EventHandler(this.ClaimRecordBuilder1_Click);
            // 
            // ClaimRecordBuilder2
            // 
            this.ClaimRecordBuilder2.Location = new System.Drawing.Point(24, 152);
            this.ClaimRecordBuilder2.Name = "ClaimRecordBuilder2";
            this.ClaimRecordBuilder2.Size = new System.Drawing.Size(161, 23);
            this.ClaimRecordBuilder2.TabIndex = 4;
            this.ClaimRecordBuilder2.Text = "Claim Builder 2";
            this.ClaimRecordBuilder2.UseVisualStyleBackColor = true;
            this.ClaimRecordBuilder2.Click += new System.EventHandler(this.ClaimRecordBuilder2_Click);
            // 
            // ClaimRecordBuilder3
            // 
            this.ClaimRecordBuilder3.Location = new System.Drawing.Point(24, 187);
            this.ClaimRecordBuilder3.Name = "ClaimRecordBuilder3";
            this.ClaimRecordBuilder3.Size = new System.Drawing.Size(161, 23);
            this.ClaimRecordBuilder3.TabIndex = 5;
            this.ClaimRecordBuilder3.Text = "Claim Builder 3";
            this.ClaimRecordBuilder3.UseVisualStyleBackColor = true;
            this.ClaimRecordBuilder3.Click += new System.EventHandler(this.ClaimRecordBuilder3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 277);
            this.Controls.Add(this.ClaimRecordBuilder3);
            this.Controls.Add(this.ClaimRecordBuilder2);
            this.Controls.Add(this.ClaimRecordBuilder1);
            this.Controls.Add(this.BuildBurger);
            this.Controls.Add(this.OutSideTheBoxButton);
            this.Controls.Add(this.SimpleIteratorButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SimpleIteratorButton;
        private System.Windows.Forms.Button OutSideTheBoxButton;
        private System.Windows.Forms.Button BuildBurger;
        private System.Windows.Forms.Button ClaimRecordBuilder1;
        private System.Windows.Forms.Button ClaimRecordBuilder2;
        private System.Windows.Forms.Button ClaimRecordBuilder3;
    }
}

