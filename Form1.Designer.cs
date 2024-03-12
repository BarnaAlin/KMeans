
namespace KMeans
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Generate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_pointsNr = new System.Windows.Forms.TextBox();
            this.textBox_pointSize = new System.Windows.Forms.TextBox();
            this.labelAge = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(754, 7);
            this.button_Generate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(86, 31);
            this.button_Generate.TabIndex = 0;
            this.button_Generate.Text = "Generate";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(791, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nr Puncte (10000)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(791, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Marime Zgomot (1)";
            // 
            // textBox_pointsNr
            // 
            this.textBox_pointsNr.Location = new System.Drawing.Point(698, 45);
            this.textBox_pointsNr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_pointsNr.Name = "textBox_pointsNr";
            this.textBox_pointsNr.Size = new System.Drawing.Size(85, 27);
            this.textBox_pointsNr.TabIndex = 4;
            this.textBox_pointsNr.Text = "10000";
            // 
            // textBox_pointSize
            // 
            this.textBox_pointSize.Location = new System.Drawing.Point(698, 84);
            this.textBox_pointSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_pointSize.Name = "textBox_pointSize";
            this.textBox_pointSize.Size = new System.Drawing.Size(85, 27);
            this.textBox_pointSize.TabIndex = 5;
            this.textBox_pointSize.Text = "2";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(698, 140);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(51, 20);
            this.labelAge.TabIndex = 7;
            this.labelAge.Text = "Age: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 815);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.textBox_pointSize);
            this.Controls.Add(this.textBox_pointsNr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Generate);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_pointsNr;
        private System.Windows.Forms.TextBox textBox_pointSize;
        private System.Windows.Forms.Label labelAge;
    }
}

