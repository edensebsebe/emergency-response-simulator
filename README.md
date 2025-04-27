Eden Sebsbe 1600029

OOP Concepts Applied
Abstraction:

We define an abstract class EmergencyUnit which outlines the general structure and behavior (methods) that all emergency units must implement. This abstracts away the details of individual unit types (Police, Firefighter, Ambulance), leaving them to implement their specific logic.

The abstract methods CanHandle and RespondToIncident are designed to be implemented by the subclasses.

Inheritance:

Police, Firefighter, and Ambulance all inherit from the EmergencyUnit abstract class. This allows the common functionality to be shared, such as having a Name and Speed for each unit, while each subclass customizes how it handles specific incident types.

Polymorphism:

The method CanHandle and RespondToIncident are used polymorphically. The game loop interacts with the EmergencyUnit reference, allowing any subclass object (Police, Firefighter, or Ambulance) to respond to the incident appropriately. This ensures that we don't need to explicitly call methods on each class but rather handle them through the shared interface provided by EmergencyUnit.

Encapsulation:

The properties Name and Speed of the EmergencyUnit class are encapsulated with public getters and setters, while the internal logic of each unit (such as handling incidents) is hidden from the outside world. This ensures that each unit class has control over its behavior and data.

Class Diagram (Text-Based)
Here's a simple class diagram to represent the structure:

pgsql
Copy
Edit
+----------------------+
|  EmergencyUnit       |
|----------------------|
| - Name: string       |
| - Speed: int         |
|----------------------|
| + CanHandle(): bool  |
| + RespondToIncident()|
+----------------------+
        ^ 
        |
+---------------------+    +---------------------+    +---------------------+
| Police              |    | Firefighter         |    | Ambulance           |
|---------------------|    |---------------------|    |---------------------|
| + CanHandle()       |    | + CanHandle()       |    | + CanHandle()       |
| + RespondToIncident()|   | + RespondToIncident()|   | + RespondToIncident()|
+---------------------+    +---------------------+    +---------------------+

+----------------------+
| Incident            |
|----------------------|
| - Type: string      |
| - Location: string  |
+----------------------+
Lessons Learned / Challenges Faced
Designing the Abstract Class:

One of the challenges was defining the abstract class EmergencyUnit. It needed to capture the common properties and behavior while allowing subclasses to provide specific implementations. Balancing the abstract methods so that the subclasses could customize behavior was a key design decision.

Polymorphism and Dynamic Dispatch:

Utilizing polymorphism with the CanHandle and RespondToIncident methods allowed for clean and extensible code. By treating all units as instances of the EmergencyUnit class, we could easily extend the system with new types of units without modifying the core game loop.

Randomness in the Game Loop:

Ensuring that incidents were generated randomly for each round and that units responded correctly to those incidents based on their capabilities was an interesting challenge. The randomization worked well with the structure of the program, providing a dynamic and unpredictable game experience.

Handling Edge Cases:

A challenge was ensuring that if no unit could handle an incident, the program properly responded with a penalty. This required careful tracking of the units' ability to handle different types of incidents.

README File (Example)
markdown
Copy
Edit
# Emergency Response Simulation

## Description

This project simulates an emergency response system in a city, where different emergency units (Police, Firefighters, Ambulance) respond to various incidents (Crime, Fire, Medical) occurring at random locations. The simulation is implemented in C# using Object-Oriented Programming (OOP) principles like inheritance, polymorphism, abstraction, and encapsulation.

The program runs for 5 rounds, where each round generates a random incident and assigns the appropriate unit to handle it. Points are awarded for correct handling, and deducted if no unit is available.

## OOP Concepts Used

- **Abstraction**: Abstract class `EmergencyUnit` defines shared properties and methods.
- **Inheritance**: `Police`, `Firefighter`, and `Ambulance` inherit from `EmergencyUnit`.
- **Polymorphism**: Methods like `CanHandle` and `RespondToIncident` are polymorphic and handle different types of incidents.
- **Encapsulation**: Properties such as `Name` and `Speed` are encapsulated within the `EmergencyUnit` class.

## Installation and Usage

1. Clone or download the repository.
2. Open the solution in Visual Studio or any C# IDE.
3. Run the project in the console.
4. Follow the on-screen prompts to view the simulation in action.

## Author

- **Name**: [Your Name]
- **Date**: [Date]
Report (Sample Markdown)
markdown
Copy
Edit
# Object-Oriented Programming Report

## OOP Concepts Applied

1. **Abstraction**: We used an abstract class `EmergencyUnit` to define common behaviors for all emergency units.
2. **Inheritance**: The classes `Police`, `Firefighter`, and `Ambulance` inherit from the `EmergencyUnit` class.
3. **Polymorphism**: Methods like `CanHandle` and `RespondToIncident` are called polymorphically, meaning that the correct method for the specific unit type is executed at runtime.
4. **Encapsulation**: We encapsulated the properties of the `EmergencyUnit` class to control how data is accessed and modified.

## Class Diagram

Please refer to the text-based class diagram above.

## Lessons Learned

- Designing the abstract class to allow for flexible extension was challenging, but it ensured the system could grow easily by adding more unit types.
- Implementing polymorphism helped in reducing the complexity of the game loop, as we were able to treat all units as instances of the same abstract class.
- Handling random incidents in the simulation provided a more dynamic and engaging experience, though ensuring the correct unit responded each time required careful implementation.
