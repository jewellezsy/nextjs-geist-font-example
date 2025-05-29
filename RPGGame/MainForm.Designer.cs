namespace RPGGame
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.TextBox textBoxPlayer2Name;
        private System.Windows.Forms.ComboBox comboBoxPlayer1;
        private System.Windows.Forms.ComboBox comboBoxPlayer2;
        private System.Windows.Forms.Button buttonStartBattle;
        private System.Windows.Forms.ListBox listBoxBattleLog;
        private System.Windows.Forms.Label labelPlayer1Health;
        private System.Windows.Forms.Label labelPlayer2Health;
        private System.Windows.Forms.Label labelWinner;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer2Name;
        private System.Windows.Forms.Label labelPlayer1Character;
        private System.Windows.Forms.Label labelPlayer2Character;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.comboBoxPlayer1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPlayer2 = new System.Windows.Forms.ComboBox();
            this.buttonStartBattle = new System.Windows.Forms.Button();
            this.listBoxBattleLog = new System.Windows.Forms.ListBox();
            this.labelPlayer1Health = new System.Windows.Forms.Label();
            this.labelPlayer2Health = new System.Windows.Forms.Label();
            this.labelWinner = new System.Windows.Forms.Label();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.labelPlayer1Character = new System.Windows.Forms.Label();
            this.labelPlayer2Character = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Location = new System.Drawing.Point(12, 15);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(70, 13);
            this.labelPlayer1Name.TabIndex = 0;
            this.labelPlayer1Name.Text = "Player 1 Name";
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(100, 12);
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer1Name.TabIndex = 1;
            // 
            // labelPlayer1Character
            // 
            this.labelPlayer1Character.AutoSize = true;
            this.labelPlayer1Character.Location = new System.Drawing.Point(12, 45);
            this.labelPlayer1Character.Name = "labelPlayer1Character";
            this.labelPlayer1Character.Size = new System.Drawing.Size(88, 13);
            this.labelPlayer1Character.TabIndex = 2;
            this.labelPlayer1Character.Text = "Player 1 Character";
            // 
            // comboBoxPlayer1
            // 
            this.comboBoxPlayer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayer1.FormattingEnabled = true;
            this.comboBoxPlayer1.Location = new System.Drawing.Point(100, 42);
            this.comboBoxPlayer1.Name = "comboBoxPlayer1";
            this.comboBoxPlayer1.Size = new System.Drawing.Size(150, 21);
            this.comboBoxPlayer1.TabIndex = 3;
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Location = new System.Drawing.Point(300, 15);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(70, 13);
            this.labelPlayer2Name.TabIndex = 4;
            this.labelPlayer2Name.Text = "Player 2 Name";
            // 
            // textBoxPlayer2Name
            // 
            this.textBoxPlayer2Name.Location = new System.Drawing.Point(388, 12);
            this.textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            this.textBoxPlayer2Name.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer2Name.TabIndex = 5;
            // 
            // labelPlayer2Character
            // 
            this.labelPlayer2Character.AutoSize = true;
            this.labelPlayer2Character.Location = new System.Drawing.Point(300, 45);
            this.labelPlayer2Character.Name = "labelPlayer2Character";
            this.labelPlayer2Character.Size = new System.Drawing.Size(88, 13);
            this.labelPlayer2Character.TabIndex = 6;
            this.labelPlayer2Character.Text = "Player 2 Character";
            // 
            // comboBoxPlayer2
            // 
            this.comboBoxPlayer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayer2.FormattingEnabled = true;
            this.comboBoxPlayer2.Location = new System.Drawing.Point(388, 42);
            this.comboBoxPlayer2.Name = "comboBoxPlayer2";
            this.comboBoxPlayer2.Size = new System.Drawing.Size(150, 21);
            this.comboBoxPlayer2.TabIndex = 7;
            // 
            // buttonStartBattle
            // 
            this.buttonStartBattle.Location = new System.Drawing.Point(200, 80);
            this.buttonStartBattle.Name = "buttonStartBattle";
            this.buttonStartBattle.Size = new System.Drawing.Size(150, 30);
            this.buttonStartBattle.TabIndex = 8;
            this.buttonStartBattle.Text = "Start Battle";
            this.buttonStartBattle.UseVisualStyleBackColor = true;
            this.buttonStartBattle.Click += new System.EventHandler(this.buttonStartBattle_Click);
            // 
            // listBoxBattleLog
            // 
            this.listBoxBattleLog.FormattingEnabled = true;
            this.listBoxBattleLog.HorizontalScrollbar = true;
            this.listBoxBattleLog.Location = new System.Drawing.Point(15, 130);
            this.listBoxBattleLog.Name = "listBoxBattleLog";
            this.listBoxBattleLog.Size = new System.Drawing.Size(523, 199);
            this.listBoxBattleLog.TabIndex = 9;
            // 
            // labelPlayer1Health
            // 
            this.labelPlayer1Health.AutoSize = true;
            this.labelPlayer1Health.Location = new System.Drawing.Point(12, 340);
            this.labelPlayer1Health.Name = "labelPlayer1Health";
            this.labelPlayer1Health.Size = new System.Drawing.Size(35, 13);
            this.labelPlayer1Health.TabIndex = 10;
            this.labelPlayer1Health.Text = "Health";
            // 
            // labelPlayer2Health
            // 
            this.labelPlayer2Health.AutoSize = true;
            this.labelPlayer2Health.Location = new System.Drawing.Point(400, 340);
            this.labelPlayer2Health.Name = "labelPlayer2Health";
            this.labelPlayer2Health.Size = new System.Drawing.Size(35, 13);
            this.labelPlayer2Health.TabIndex = 11;
            this.labelPlayer2Health.Text = "Health";
            // 
            // labelWinner
            // 
            this.labelWinner.AutoSize = true;
            this.labelWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinner.Location = new System.Drawing.Point(220, 370);
            this.labelWinner.Name = "labelWinner";
            this.labelWinner.Size = new System.Drawing.Size(60, 17);
            this.labelWinner.TabIndex = 12;
            this.labelWinner.Text = "Winner";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(554, 410);
            this.Controls.Add(this.labelWinner);
            this.Controls.Add(this.labelPlayer2Health);
            this.Controls.Add(this.labelPlayer1Health);
            this.Controls.Add(this.listBoxBattleLog);
            this.Controls.Add(this.buttonStartBattle);
            this.Controls.Add(this.comboBoxPlayer2);
            this.Controls.Add(this.labelPlayer2Character);
            this.Controls.Add(this.textBoxPlayer2Name);
            this.Controls.Add(this.labelPlayer2Name);
            this.Controls.Add(this.comboBoxPlayer1);
            this.Controls.Add(this.labelPlayer1Character);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Controls.Add(this.labelPlayer1Name);
            this.Name = "MainForm";
            this.Text = "Classroom RPG Battle Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
