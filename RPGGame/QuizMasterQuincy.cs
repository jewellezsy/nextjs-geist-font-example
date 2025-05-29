using System;

namespace RPGGame
{
    // Character class QuizMasterQuincy inherits from CharacterBase
    // Demonstrates Inheritance and Polymorphism by overriding Attack method
    public class QuizMasterQuincy : CharacterBase
    {
        private Random _random;

        public QuizMasterQuincy(string name) : base(name, 120)
        {
            _random = new Random();
        }

        // Override Attack method with custom logic using randomness
        public override int Attack()
        {
            // Damage between 5 and 25
            return _random.Next(5, 26);
        }
    }
}
