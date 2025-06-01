using System;
using System.Threading;

namespace RPGGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "Classroom RPG Battle";
            Console.CursorVisible = false;

            // Launch BattleSetupForm for player setup
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BattleSetupForm setupForm = new BattleSetupForm();

            string player1Name = null;
            string player2Name = null;
            string player1Character = null;
            string player2Character = null;

            bool startBattle = false;

            setupForm.StartBattleClicked += (sender, e) =>
            {
                player1Name = setupForm.Player1Name;
                player2Name = setupForm.Player2Name;
                player1Character = setupForm.Player1Character;
                player2Character = setupForm.Player2Character;
                startBattle = true;
                setupForm.Hide();
            };

            Application.Run(setupForm);

            if (!startBattle)
                return;

            CharacterBase player1 = player1Character == "Debugger" ? new Debugger(player1Name) : new QuizMaster(player1Name);
            CharacterBase player2 = player2Character == "Debugger" ? new Debugger(player2Name) : new QuizMaster(player2Name);

            while (true)
            {
                DrawTitle();
                if (!StartGame(player1, player2, setupForm))
                    break;
            }
        }

        static void DrawTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════╗
    ║                 CLASSROOM RPG BATTLE                     ║
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
            Console.WriteLine("\n\n    1. Start New Game");
            Console.WriteLine("    2. Exit Game");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static bool StartGame(CharacterBase player1, CharacterBase player2, BattleSetupForm setupForm)
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.KeyChar != '1' && key.KeyChar != '2');

            if (key.KeyChar == '2')
                return false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n    Character setup complete!");
            Console.WriteLine($"    Player 1: {player1.Name} ({player1.GetType().Name})");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n    Press any key to start exploring...");
            Console.ReadKey(true);

            // Initialize map and movement
            MapSystem mapSystem = new MapSystem();
            bool battleTriggered = false;

            while (!battleTriggered)
            {
                mapSystem.DrawMap();
                ConsoleKeyInfo moveKey = Console.ReadKey(true);

                if (moveKey.Key == ConsoleKey.Q)
                    return true;

                battleTriggered = mapSystem.MovePlayer(moveKey.Key);
            }

            // Show story introduction when enemy is encountered
            StorySystem.ShowStory();

            // Start battle
            BattleSystem battle = new BattleSystem(player1, player2, setupForm);
            battle.StartBattle();

            // Show appropriate ending dialogue
            if (player1.IsAlive())
                StorySystem.ShowVictoryDialogue();
            else
                StorySystem.ShowDefeatDialogue();

            Console.WriteLine("\nPress any key to return to main menu...");
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
            string name = Console.ReadLine()?.Trim() ?? $"Player{playerNum}";

            Console.WriteLine("\n    Choose your character:");
            Console.WriteLine("    1. Debugger (Consistent moderate damage)");
            Console.WriteLine("    2. QuizMaster (Variable damage range)");

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.KeyChar != '1' && key.KeyChar != '2');

            return key.KeyChar == '1' ? new Debugger(name) : new QuizMaster(name);
        }
    }

    class BattleSystem
    {
        private readonly CharacterBase player1;
        private readonly CharacterBase player2;
        private readonly BattleSetupForm setupForm;
        private bool player1Turn = true;
        private Random random = new Random();

        private readonly string[] danaDialogues = new string[]
        {
            "Debugging this code like a pro!",
            "Let's squash some bugs!",
            "Syntax errors won't save you!",
            "Time to refactor your health away!",
            "Watch out for my breakpoint!"
        };

        private readonly string[] quincyDialogues = new string[]
        {
            "Quiz time! Can you answer this attack?",
            "Think fast, here comes a question!",
            "Better study harder!",
            "This attack is multiple choice!",
            "Prepare for a pop quiz!"
        };

        // Character sprites
        private readonly string[] normalCharacter = new string[]
        {
            "  o  ",
            " /|\\ ",
            " / \\ "
        };

        private readonly string[] victoryCharacter = new string[]
        {
            "\\o/  ",
            " |  ",
            "/ \\ "
        };

        private readonly string[] defeatedCharacter = new string[]
        {
            "     ",
            "     ",
            " o/|\\"
        };

        private readonly string rightSword = "===>";
        private readonly string leftSword = "<===";

        public BattleSystem(CharacterBase p1, CharacterBase p2, BattleSetupForm form)
        {
            player1 = p1 ?? throw new ArgumentNullException(nameof(p1));
            player2 = p2 ?? throw new ArgumentNullException(nameof(p2));
            setupForm = form ?? throw new ArgumentNullException(nameof(form));
        }

        public void StartBattle()
        {
            while (player1.IsAlive() && player2.IsAlive())
            {
                DrawBattleScreen();
                ProcessTurn();
                // Wait for player to see the result and press a key
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n    Press any key for next turn...");
                while (Console.KeyAvailable) Console.ReadKey(true);
                Console.ReadKey(true);
            }

            DrawBattleScreen();
            bool player1Won = player1.IsAlive();
            PlayVictoryDefeatAnimation(player1Won);

            // Update battle log and winner display on form
            setupForm.AppendBattleLog($"\n{(player1Won ? player1.Name : player2.Name)} is victorious! {(player1Won ? player2.Name : player1.Name)} has been defeated!");
            setupForm.DisplayWinner(player1Won ? player1.Name : player2.Name, player1Won ? player2.Name : player1.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            string winner = player1Won ? player1.Name : player2.Name;
            string loser = player1Won ? player2.Name : player1.Name;
            Console.WriteLine($"\n    {loser} has been defeated!");
            Console.WriteLine($"    {winner} is victorious!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n    Press any key to continue...");
            Console.ReadKey(true);
        }

        private void DrawBattleScreen()
        {
            Console.Clear();
            // Draw classroom background
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n    ╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("    ║                 CLASSROOM BATTLE                     ║");
            Console.WriteLine("    ╚══════════════════════════════════════════════════════╝");

            // Player 1 stats
            Console.Write("\n    ");
            if (player1Turn)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write(player1.Name);
            DrawHealthBar(player1);

            // Player 2 stats
            Console.Write("\n    ");
            if (!player1Turn)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write(player2.Name);
            DrawHealthBar(player2);

            // Draw blackboard
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n    ┌──────────────────────────────────────────────────────┐");
            Console.WriteLine("    │                                                      │");
            Console.WriteLine("    │     MATH CLASS                                       │");
            Console.WriteLine("    │     2 + 2 = 4            sana mabigyan ng uno        │");
            Console.WriteLine("    │     x + y = z                                        │");
            Console.WriteLine("    └──────────────────────────────────────────────────────┘");

            // Draw classroom elements
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("    ┌─┐  ┌─┐  ┌─┐    Teacher's     ┌─┐  ┌─┐  ┌─┐");
            Console.WriteLine("    └─┘  └─┘  └─┘      Desk        └─┘  └─┘  └─┘");
            Console.WriteLine("     Δ    Δ    Δ        ▄▄          Δ    Δ    Δ");
            Console.ForegroundColor = ConsoleColor.White;

            // Draw more classroom elements
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("    Windows: ▒▒▒▒▒▒  ▒▒▒▒▒▒  ▒▒▒▒▒▒");
            
            // Battle scene with stickmen
            Console.WriteLine();
            DrawStickmen();

            // Draw floor tiles
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("    ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {(player1Turn ? player1.Name : player2.Name)}'s turn!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // ... [Rest of the code remains unchanged] ...
    }
}
