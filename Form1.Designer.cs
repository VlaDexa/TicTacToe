namespace TicTacToe
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.ClassicShower = new System.Windows.Forms.Button();
            this.ComplexShower = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Крестики-Нолики";
            // 
            // ClassicShower
            // 
            this.ClassicShower.Location = new System.Drawing.Point(12, 100);
            this.ClassicShower.Name = "ClassicShower";
            this.ClassicShower.Size = new System.Drawing.Size(343, 338);
            this.ClassicShower.TabIndex = 1;
            this.ClassicShower.Text = "Обычный";
            this.ClassicShower.UseVisualStyleBackColor = true;
            this.ClassicShower.Click += new System.EventHandler(this.ClassicShower_Click);
            // 
            // ComplexShower
            // 
            this.ComplexShower.Location = new System.Drawing.Point(449, 100);
            this.ComplexShower.Name = "ComplexShower";
            this.ComplexShower.Size = new System.Drawing.Size(339, 338);
            this.ComplexShower.TabIndex = 2;
            this.ComplexShower.Text = "10 x 10";
            this.ComplexShower.UseVisualStyleBackColor = true;
            this.ComplexShower.Click += new System.EventHandler(this.ComplexShower_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ComplexShower);
            this.Controls.Add(this.ClassicShower);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClassicShower;
        private System.Windows.Forms.Button ComplexShower;
    }
}
