using System;

namespace RPGGame
{
    // Character class DebuggerDana inherits from CharacterBase
    // Demonstrates Inheritance and Polymorphism by overriding Attack method
    public class DebuggerDana : CharacterBase
    {
        private Random _random;

        public DebuggerDana(string name) : base(name, 100)
        {
            _random = new Random();
        }

        // Override Attack method with custom logic using randomness
        public override int Attack()
        {
            // Damage between 10 and 20
            return _random.Next(10, 21);
        }
    }
}
