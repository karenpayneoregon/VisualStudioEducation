namespace LinqLambdaStaticSamples
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
            this.NumberLessThanFiveArrayButton = new System.Windows.Forms.Button();
            this.CustomersInWashingtonButton = new System.Windows.Forms.Button();
            this.AggregateCheapPriceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumberLessThanFiveArrayButton
            // 
            this.NumberLessThanFiveArrayButton.Location = new System.Drawing.Point(11, 15);
            this.NumberLessThanFiveArrayButton.Name = "NumberLessThanFiveArrayButton";
            this.NumberLessThanFiveArrayButton.Size = new System.Drawing.Size(198, 23);
            this.NumberLessThanFiveArrayButton.TabIndex = 0;
            this.NumberLessThanFiveArrayButton.Text = "Number less then 5 in array";
            this.NumberLessThanFiveArrayButton.UseVisualStyleBackColor = true;
            this.NumberLessThanFiveArrayButton.Click += new System.EventHandler(this.NumberLessThanFiveArrayButton_Click);
            // 
            // CustomersInWashingtonButton
            // 
            this.CustomersInWashingtonButton.Location = new System.Drawing.Point(12, 46);
            this.CustomersInWashingtonButton.Name = "CustomersInWashingtonButton";
            this.CustomersInWashingtonButton.Size = new System.Drawing.Size(198, 23);
            this.CustomersInWashingtonButton.TabIndex = 1;
            this.CustomersInWashingtonButton.Text = "Customers in Washington state";
            this.CustomersInWashingtonButton.UseVisualStyleBackColor = true;
            this.CustomersInWashingtonButton.Click += new System.EventHandler(this.CustomersInWashingtonButton_Click);
            // 
            // AggregateCheapPriceButton
            // 
            this.AggregateCheapPriceButton.Location = new System.Drawing.Point(12, 75);
            this.AggregateCheapPriceButton.Name = "AggregateCheapPriceButton";
            this.AggregateCheapPriceButton.Size = new System.Drawing.Size(198, 23);
            this.AggregateCheapPriceButton.TabIndex = 2;
            this.AggregateCheapPriceButton.Text = "Aggregate cheap price";
            this.AggregateCheapPriceButton.UseVisualStyleBackColor = true;
            this.AggregateCheapPriceButton.Click += new System.EventHandler(this.AggregateCheapPriceButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 336);
            this.Controls.Add(this.AggregateCheapPriceButton);
            this.Controls.Add(this.CustomersInWashingtonButton);
            this.Controls.Add(this.NumberLessThanFiveArrayButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NumberLessThanFiveArrayButton;
        private System.Windows.Forms.Button CustomersInWashingtonButton;
        private System.Windows.Forms.Button AggregateCheapPriceButton;
    }
}

