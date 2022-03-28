namespace TicTacToe
{
    partial class Classic
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
            this.label2 = new System.Windows.Forms.Label();
            this.First = new System.Windows.Forms.Label();
            this.Second = new System.Windows.Forms.Label();
            this.a1 = new System.Windows.Forms.Button();
            this.a2 = new System.Windows.Forms.Button();
            this.a3 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.c3 = new System.Windows.Forms.Button();
            this.c2 = new System.Windows.Forms.Button();
            this.c1 = new System.Windows.Forms.Button();
            this.NewGame = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FileSaver = new System.Windows.Forms.SaveFileDialog();
            this.Load = new System.Windows.Forms.Button();
            this.FileLoader = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Первый";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Второй";
            // 
            // First
            // 
            this.First.AutoSize = true;
            this.First.Location = new System.Drawing.Point(69, 56);
            this.First.Name = "First";
            this.First.Size = new System.Drawing.Size(22, 25);
            this.First.TabIndex = 2;
            this.First.Text = "0";
            // 
            // Second
            // 
            this.Second.AutoSize = true;
            this.Second.Location = new System.Drawing.Point(451, 56);
            this.Second.Name = "Second";
            this.Second.Size = new System.Drawing.Size(22, 25);
            this.Second.TabIndex = 3;
            this.Second.Text = "0";
            // 
            // a1
            // 
            this.a1.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.a1.Location = new System.Drawing.Point(12, 84);
            this.a1.Name = "a1";
            this.a1.Size = new System.Drawing.Size(166, 161);
            this.a1.TabIndex = 4;
            this.a1.UseVisualStyleBackColor = true;
            this.a1.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // a2
            // 
            this.a2.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.a2.Location = new System.Drawing.Point(221, 84);
            this.a2.Name = "a2";
            this.a2.Size = new System.Drawing.Size(166, 161);
            this.a2.TabIndex = 5;
            this.a2.UseVisualStyleBackColor = true;
            this.a2.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // a3
            // 
            this.a3.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.a3.Location = new System.Drawing.Point(426, 84);
            this.a3.Name = "a3";
            this.a3.Size = new System.Drawing.Size(166, 161);
            this.a3.TabIndex = 6;
            this.a3.UseVisualStyleBackColor = true;
            this.a3.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // b3
            // 
            this.b3.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.b3.Location = new System.Drawing.Point(426, 286);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(166, 161);
            this.b3.TabIndex = 9;
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.b2.Location = new System.Drawing.Point(221, 286);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(166, 161);
            this.b2.TabIndex = 8;
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.b1.Location = new System.Drawing.Point(12, 286);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(166, 161);
            this.b1.TabIndex = 7;
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // c3
            // 
            this.c3.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.c3.Location = new System.Drawing.Point(426, 481);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(166, 161);
            this.c3.TabIndex = 12;
            this.c3.UseVisualStyleBackColor = true;
            this.c3.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // c2
            // 
            this.c2.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.c2.Location = new System.Drawing.Point(221, 481);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(166, 161);
            this.c2.TabIndex = 11;
            this.c2.UseVisualStyleBackColor = true;
            this.c2.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // c1
            // 
            this.c1.Font = new System.Drawing.Font("Segoe UI", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.c1.Location = new System.Drawing.Point(12, 481);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(166, 161);
            this.c1.TabIndex = 10;
            this.c1.UseVisualStyleBackColor = true;
            this.c1.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // NewGame
            // 
            this.NewGame.Location = new System.Drawing.Point(24, 678);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(132, 34);
            this.NewGame.TabIndex = 13;
            this.NewGame.Text = "Новая Игра";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(438, 678);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(141, 34);
            this.ResetButton.TabIndex = 14;
            this.ResetButton.Text = "Сбросить счёт";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(248, 31);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 34);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FileSaver
            // 
            this.FileSaver.DefaultExt = "tttlab";
            this.FileSaver.FileOk += new System.ComponentModel.CancelEventHandler(this.FileSaver_FileOk);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(248, 678);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(112, 34);
            this.Load.TabIndex = 16;
            this.Load.Text = "Загрузить";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // FileLoader
            // 
            this.FileLoader.DefaultExt = "tttlab";
            this.FileLoader.FileName = "openFileDialog1";
            this.FileLoader.FileOk += new System.ComponentModel.CancelEventHandler(this.FileLoader_FileOk);
            // 
            // Classic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 735);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.c3);
            this.Controls.Add(this.c2);
            this.Controls.Add(this.c1);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.a3);
            this.Controls.Add(this.a2);
            this.Controls.Add(this.a1);
            this.Controls.Add(this.Second);
            this.Controls.Add(this.First);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Classic";
            this.Text = "Classic";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Classic_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label First;
        private System.Windows.Forms.Label Second;
        private System.Windows.Forms.Button a1;
        private System.Windows.Forms.Button a2;
        private System.Windows.Forms.Button a3;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button c3;
        private System.Windows.Forms.Button c2;
        private System.Windows.Forms.Button c1;
        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog FileSaver;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.OpenFileDialog FileLoader;
    }
}
