using System;
using System.Windows.Forms;

namespace RPGGame
{
    public partial class MainForm : Form
    {
        private CharacterBase player1;
        private CharacterBase player2;
        private bool player1Turn;
        private Random random;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
            InitializeCharacterComboBoxes();
        }

        private void InitializeCharacterComboBoxes()
        {
            comboBoxPlayer1.Items.Add("Debugger Dana");
            comboBoxPlayer1.Items.Add("QuizMaster Quincy");
            comboBoxPlayer2.Items.Add("Debugger Dana");
            comboBoxPlayer2.Items.Add("QuizMaster Quincy");
        }

        private void buttonStartBattle_Click(object sender, EventArgs e)
        {
            try
            {
                string name1 = textBoxPlayer1Name.Text.Trim();
                string name2 = textBoxPlayer2Name.Text.Trim();

                if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
                {
                    MessageBox.Show("Please enter names for both players.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxPlayer1.SelectedItem == null || comboBoxPlayer2.SelectedItem == null)
                {
                    MessageBox.Show("Please select character types for both players.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                player1 = CreateCharacter(comboBoxPlayer1.SelectedItem.ToString(), name1);
                player2 = CreateCharacter(comboBoxPlayer2.SelectedItem.ToString(), name2);

                listBoxBattleLog.Items.Clear();
                listBoxBattleLog.Items.Add("Battle started!");

                player1Turn = true;
                UpdateHealthLabels();
                UpdateTurnUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CharacterBase CreateCharacter(string characterType, string name)
        {
            switch (characterType)
            {
                case "Debugger Dana":
                    return new DebuggerDana(name);
                case "QuizMaster Quincy":
                    return new QuizMasterQuincy(name);
                default:
                    throw new ArgumentException("Unknown character type.");
            }
        }

        private void buttonPlayer1Attack_Click(object sender, EventArgs e)
        {
            if (!player1Turn || !player1.IsAlive() || !player2.IsAlive())
                return;

            int damage = player1.Attack();
            player2.TakeDamage(damage);
            listBoxBattleLog.Items.Add($"{player1.Name} attacks {player2.Name} for {damage} damage.");
            UpdateHealthLabels();

            if (!player2.IsAlive())
            {
                listBoxBattleLog.Items.Add($"Battle over! Winner: {player1.Name}");
                labelWinner.Text = $"Winner: {player1.Name}";
                DisableAttackButtons();
                return;
            }

            player1Turn = false;
            UpdateTurnUI();
        }

        private void buttonPlayer2Attack_Click(object sender, EventArgs e)
        {
            if (player1Turn || !player1.IsAlive() || !player2.IsAlive())
                return;

            int damage = player2.Attack();
            player1.TakeDamage(damage);
            listBoxBattleLog.Items.Add($"{player2.Name} attacks {player1.Name} for {damage} damage.");
            UpdateHealthLabels();

            if (!player1.IsAlive())
            {
                listBoxBattleLog.Items.Add($"Battle over! Winner: {player2.Name}");
                labelWinner.Text = $"Winner: {player2.Name}";
                DisableAttackButtons();
                return;
            }

            player1Turn = true;
            UpdateTurnUI();
        }

        private void UpdateTurnUI()
        {
            buttonPlayer1Attack.Enabled = player1Turn && player1.IsAlive() && player2.IsAlive();
            buttonPlayer2Attack.Enabled = !player1Turn && player1.IsAlive() && player2.IsAlive();
            labelTurn.Text = player1Turn ? $"{player1.Name}'s Turn" : $"{player2.Name}'s Turn";
        }

        private void DisableAttackButtons()
        {
            buttonPlayer1Attack.Enabled = false;
            buttonPlayer2Attack.Enabled = false;
        }

        private void UpdateHealthLabels()
        {
            labelPlayer1Health.Text = $"{player1.Name} Health: {player1.Health}/{player1.MaxHealth}";
            labelPlayer2Health.Text = $"{player2.Name} Health: {player2.Health}/{player2.MaxHealth}";
        }
    }
}
