using System;
using System.Threading;

namespace RPGGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Classroom RPG Battle";
            Console.CursorVisible = false;

            while (true)
            {
                DrawTitle();
                if (!StartGame())
                    break;
            }
        }

        static void DrawTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════╗
    ║                 CLASSROOM RPG BATTLE                      ║
    ╚══════════════════════════════════════════════════════════╝

         ┌─┐       ┌─┐
         ┌──┘ ┴───────┘ ┴──┐
         │                 │
         │       ───       │
         │  ─┬┘       └┬─  │
         │                 │
         │       ─┴─       │
         │                 │
         └───┐         ┌───┘
             │         │
             │         │
             │         │
             │         └──────────────┐
             │                        │
             │                        ├─┐
             │                        ┌─┘
             │                        │
             └─┐  ┐  ┌───────┬──┐  ┌─┘
               │ ─┤ ─┤       │ ─┤ ─┤
               └──┴──┘       └──┴──┘
    ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n    1. Start New Battle");
            Console.WriteLine("    2. Exit Game");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static bool StartGame()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.KeyChar != '1' && key.KeyChar != '2');

            if (key.KeyChar == '2')
                return false;

            CharacterBase player1 = CreatePlayer(1);
            CharacterBase player2 = CreatePlayer(2);

            BattleSystem battle = new BattleSystem(player1, player2);
            battle.StartBattle();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            return true;
        }

        static CharacterBase CreatePlayer(int playerNum)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n    Player {playerNum} Setup");
            Console.WriteLine("    ═════════════");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write($"\n    Enter Player {playerNum} Name: ");
            string name = Console.ReadLine().Trim();

            Console.WriteLine("\n    Choose your character:");
            Console.WriteLine("    1. Debugger Dana (Consistent moderate damage)");
            Console.WriteLine("    2. QuizMaster Quincy (Variable damage range)");

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.KeyChar != '1' && key.KeyChar != '2');

            return key.KeyChar == '1' ? new DebuggerDana(name) : new QuizMasterQuincy(name);
        }
    }

    class BattleSystem
    {
        private CharacterBase player1;
        private CharacterBase player2;
        private bool player1Turn = true;

        public BattleSystem(CharacterBase p1, CharacterBase p2)
        {
            player1 = p1;
            player2 = p2;
        }

        public void StartBattle()
        {
            while (player1.IsAlive() && player2.IsAlive())
            {
                DrawBattleScreen();
                ProcessTurn();
                Thread.Sleep(1500);
            }

            DrawBattleScreen();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n    {(player1.IsAlive() ? player1.Name : player2.Name)} wins the battle!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DrawBattleScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n    ╔══════════════════════════════════════╗");
            Console.WriteLine("    ║           CLASSROOM BATTLE           ║");
            Console.WriteLine("    ╚══════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;

            // Player 1 stats
            Console.Write($"\n    {player1.Name}");
            DrawHealthBar(player1);

            // Player 2 stats
            Console.Write($"\n    {player2.Name}");
            DrawHealthBar(player2);

            // Battle scene
            Console.WriteLine("\n");
            Console.WriteLine(@"
         P1    ⚔️     P2
        [^^]  ==||==  [^^]
         ||           ||
        /||\         /||\
         /\           /\
    ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n    {(player1Turn ? player1.Name : player2.Name)}'s turn!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n    Press any key to attack...");
        }

        private void DrawHealthBar(CharacterBase character)
        {
            int healthPercent = (int)((float)character.Health / character.MaxHealth * 20);
            Console.Write(" HP: [");
            Console.ForegroundColor = healthPercent > 10 ? ConsoleColor.Green : 
                                    healthPercent > 5 ? ConsoleColor.Yellow : ConsoleColor.Red;
            Console.Write(new string('█', healthPercent));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new string('░', 20 - healthPercent));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"] {character.Health}/{character.MaxHealth}");
        }

        private void ProcessTurn()
        {
            Console.ReadKey(true);

            int damage;
            if (player1Turn)
            {
                damage = player1.Attack();
                player2.TakeDamage(damage);
                DisplayAttack(player1.Name, player2.Name, damage);
            }
            else
            {
                damage = player2.Attack();
                player1.TakeDamage(damage);
                DisplayAttack(player2.Name, player1.Name, damage);
            }

            player1Turn = !player1Turn;
        }

        private void DisplayAttack(string attacker, string defender, int damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n    {attacker} attacks {defender} for {damage} damage!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
