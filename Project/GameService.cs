using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Player CurrentPlayer { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Initialize()
    {
      //Create Rooms
      Room one = new Room("One", "You are in a metal room about 15 feet square, with exit protals to the North, South, and West.");
      Room two = new Room("Two", "You are in a metal room about 15 feet square, with exit protals to the North, South, and West.");
      Room three = new Room("Three", "You are in a metal room about 15 feet square, with exit protals to the East, West, and South.");
      Room four = new Room("Four", "You are in a metalroom about 15 feet square, with exit protals to the East, West, and South.");
      Room five = new Room("Five", "You are in a metal room about 15 feet square, with no exits.");
      //Establish Relationships
      one.AddExits(Direction.west, two);
      one.AddExits(Direction.north, two);
      one.AddExits(Direction.south, four);
      two.AddExits(Direction.west, three);
      two.AddExits(Direction.east, one);
      two.AddExits(Direction.south, four);
      three.AddExits(Direction.west, two);
      three.AddExits(Direction.north, one);
      three.AddExits(Direction.south, five);
      four.AddExits(Direction.west, three);
      four.AddExits(Direction.east, one);
      four.AddExits(Direction.south, two);

      CurrRoom = one;
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

    public void Setup()
    {
      throw new System.NotImplementedException();
    }

    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void StartGame()
    {
      throw new System.NotImplementedException();
    }

    public void GetUserInput()
    {
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }

    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Go(string direction)
    {
      throw new System.NotImplementedException();
    }

    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }
  }
}