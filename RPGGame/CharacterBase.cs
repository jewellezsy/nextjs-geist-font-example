using System;

namespace RPGGame
{
    // Abstract base class representing a character in the RPG game
    // Demonstrates Abstraction by defining abstract Attack method
    // Encapsulation is applied by using properties with private setters
    public abstract class CharacterBase
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public CharacterBase(string name, int maxHealth)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");
            if (maxHealth <= 0)
                throw new ArgumentException("MaxHealth must be positive.");

            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        // Abstract method to be overridden by derived classes to implement attack logic
        public abstract int Attack();

        // Method to reduce health when taking damage, encapsulating health modification
        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Damage cannot be negative.");

            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        // Method to check if character is alive
        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}
