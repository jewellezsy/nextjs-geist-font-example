# Classroom RPG Battle

A console-based RPG battle game featuring classroom-themed characters with ASCII art and interactive turn-based combat.

## Characters

### Debugger Dana
- Health: 100
- Attack: 10-20 damage (Consistent moderate damage)
- Special Trait: Reliable debugging skills translate to consistent attack power

### QuizMaster Quincy
- Health: 120
- Attack: 5-25 damage (Variable damage range)
- Special Trait: Unpredictable quiz questions result in varying attack power

## Features

- ASCII art battle scenes
- Colored text and health bars
- Interactive turn-based combat
- Visual battle animations
- Character selection system
- Health tracking with visual indicators
- Battle log with attack results

## How to Play

1. Run the game
2. Choose "Start New Battle" from the main menu
3. Enter names and select characters for both players
4. Take turns attacking by pressing any key when prompted
5. Watch the health bars and battle animations
6. The battle ends when one character's health reaches 0

## Controls

- Use number keys (1, 2) to make menu selections
- Press any key to perform attacks during battle
- Press any key to continue after battle ends

## Technical Details

- Built using C# (.NET 6.0)
- Implements OOP principles:
  - Inheritance (Character classes inherit from CharacterBase)
  - Polymorphism (Override Attack method)
  - Encapsulation (Private fields, public properties)
  - Abstraction (Abstract base class)
- Console manipulation for UI effects
- Random number generation for attack damage
