namespace RPGGame
{
    partial class BattleSetupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPlayer1Name;
        private System.Windows.Forms.TextBox txtPlayer2Name;
        private System.Windows.Forms.ComboBox cmbPlayer1Character;
        private System.Windows.Forms.ComboBox cmbPlayer2Character;
        private System.Windows.Forms.Button btnStartBattle;
        private System.Windows.Forms.TextBox txtBattleLog;
        private System.Windows.Forms.Label lblPlayer1Health;
        private System.Windows.Forms.Label lblPlayer2Health;
        private System.Windows.Forms.Label lblWinner;

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
            this.txtPlayer1Name = new System.Windows.Forms.TextBox();
            this.txtPlayer2Name = new System.Windows.Forms.TextBox();
            this.cmbPlayer1Character = new System.Windows.Forms.ComboBox();
            this.cmbPlayer2Character = new System.Windows.Forms.ComboBox();
            this.btnStartBattle = new System.Windows.Forms.Button();
            this.txtBattleLog = new System.Windows.Forms.TextBox();
            this.lblPlayer1Health = new System.Windows.Forms.Label();
            this.lblPlayer2Health = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.Location = new System.Drawing.Point(12, 12);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(150, 23);
            this.txtPlayer1Name.TabIndex = 0;
            this.txtPlayer1Name.PlaceholderText = "Player 1 Name";
            // 
            // txtPlayer2Name
            // 
            this.txtPlayer2Name.Location = new System.Drawing.Point(12, 41);
            this.txtPlayer2Name.Name = "txtPlayer2Name";
            this.txtPlayer2Name.Size = new System.Drawing.Size(150, 23);
            this.txtPlayer2Name.TabIndex = 1;
            this.txtPlayer2Name.PlaceholderText = "Player 2 Name";
            // 
            // cmbPlayer1Character
            // 
            this.cmbPlayer1Character.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer1Character.FormattingEnabled = true;
            this.cmbPlayer1Character.Location = new System.Drawing.Point(180, 12);
            this.cmbPlayer1Character.Name = "cmbPlayer1Character";
            this.cmbPlayer1Character.Size = new System.Drawing.Size(150, 23);
            this.cmbPlayer1Character.TabIndex = 2;
            // 
            // cmbPlayer2Character
            // 
            this.cmbPlayer2Character.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer2Character.FormattingEnabled = true;
            this.cmbPlayer2Character.Location = new System.Drawing.Point(180, 41);
            this.cmbPlayer2Character.Name = "cmbPlayer2Character";
            this.cmbPlayer2Character.Size = new System.Drawing.Size(150, 23);
            this.cmbPlayer2Character.TabIndex = 3;
            // 
            // btnStartBattle
            // 
            this.btnStartBattle.Location = new System.Drawing.Point(350, 12);
            this.btnStartBattle.Name = "btnStartBattle";
            this.btnStartBattle.Size = new System.Drawing.Size(100, 52);
            this.btnStartBattle.TabIndex = 4;
            this.btnStartBattle.Text = "Start Battle";
            this.btnStartBattle.UseVisualStyleBackColor = true;
            this.btnStartBattle.Click += new System.EventHandler(this.btnStartBattle_Click);
            // 
            // txtBattleLog
            // 
            this.txtBattleLog.Location = new System.Drawing.Point(12, 80);
            this.txtBattleLog.Multiline = true;
            this.txtBattleLog.Name = "txtBattleLog";
            this.txtBattleLog.ReadOnly = true;
            this.txtBattleLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBattleLog.Size = new System.Drawing.Size(438, 200);
            this.txtBattleLog.TabIndex = 5;
            // 
            // lblPlayer1Health
            // 
            this.lblPlayer1Health.AutoSize = true;
            this.lblPlayer1Health.Location = new System.Drawing.Point(12, 290);
            this.lblPlayer1Health.Name = "lblPlayer1Health";
            this.lblPlayer1Health.Size = new System.Drawing.Size(95, 15);
            this.lblPlayer1Health.TabIndex = 6;
            this.lblPlayer1Health.Text = "Player 1 Health: ";
            // 
            // lblPlayer2Health
            // 
            this.lblPlayer2Health.AutoSize = true;
            this.lblPlayer2Health.Location = new System.Drawing.Point(12, 315);
            this.lblPlayer2Health.Name = "lblPlayer2Health";
            this.lblPlayer2Health.Size = new System.Drawing.Size(95, 15);
            this.lblPlayer2Health.TabIndex = 7;
            this.lblPlayer2Health.Text = "Player 2 Health: ";
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWinner.Location = new System.Drawing.Point(12, 345);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(0, 15);
            this.lblWinner.TabIndex = 8;
            // 
            // BattleSetupForm
            // 
            this.ClientSize = new System.Drawing.Size(462, 375);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lblPlayer2Health);
            this.Controls.Add(this.lblPlayer1Health);
            this.Controls.Add(this.txtBattleLog);
            this.Controls.Add(this.btnStartBattle);
            this.Controls.Add(this.cmbPlayer2Character);
            this.Controls.Add(this.cmbPlayer1Character);
            this.Controls.Add(this.txtPlayer2Name);
            this.Controls.Add(this.txtPlayer1Name);
            this.Name = "BattleSetupForm";
            this.Text = "Battle Setup";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
</create_file>
