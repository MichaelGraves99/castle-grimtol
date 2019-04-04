using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    private void Initialize()
    {
      //Create Rooms
      Room porch = new Porch("Front Porch", "You are on the front porch of a house in a quiet neighborhood. The Door is to the West");
      Room living = new Living("Living Room", "You are in the living room. There is a room to the west and the front door to the east.");
      Room dining = new Dining("Dining Room", "You are in the dining room. There is a room to the west and one to the east.");
      Room kitchen = new Kitchen("Kitchen", "You are in the kitchen. The only exit is to the east.");
      //Establish Relationships
      porch.AddExits(Direction.west, living);
      living.AddExits(Direction.west, dining);
      living.AddExits(Direction.east, porch);
      dining.AddExits(Direction.west, kitchen);
      dining.AddExits(Direction.east, living);
      kitchen.AddExits(Direction.west, dining);

      CurrLocation = earth;
      Running = true;
    }


    public void Run()
    {
      Initialize();
      Console.Clear();
      while (running)
      {



      }
    }
  }
}