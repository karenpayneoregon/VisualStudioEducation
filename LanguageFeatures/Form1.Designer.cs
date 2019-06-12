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
            this.SuspendLayout();
            // 
            // SimpleIteratorButton
            // 
            this.SimpleIteratorButton.Location = new System.Drawing.Point(24, 16);
            this.SimpleIteratorButton.Name = "SimpleIteratorButton";
            this.SimpleIteratorButton.Size = new System.Drawing.Size(161, 23);
            this.SimpleIteratorButton.TabIndex = 0;
            this.SimpleIteratorButton.Text = "Simple Iterator";
            this.SimpleIteratorButton.UseVisualStyleBackColor = true;
            this.SimpleIteratorButton.Click += new System.EventHandler(this.SimpleIteratorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 277);
            this.Controls.Add(this.SimpleIteratorButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SimpleIteratorButton;
    }
}

