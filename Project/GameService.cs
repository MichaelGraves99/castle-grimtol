using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Running { get; set; }

    // public Room CurrentRoom { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    // public Player CurrentPlayer { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Initialize()
    {
      //Create Rooms
      Room one = new Room("One", "You are in a metal room about 15 feet square, with exit protals to the North, South, and West.");
      Room two = new Room("Two", "You are in a metal room about 15 feet square, with exit protals to the North, South, and West.");
      Room three = new Room("Three", "You are in a metal room about 15 feet square, with exit protals to the East, West, and South.");
      Room four = new Room("Four", "You are in a metalroom about 15 feet square, with exit protals to the East, West, and South.");
      Room five = new Room("Five", "You are in a metal room about 15 feet square, with no exits.");
      //Create Items
      Item glasses = new Item("Glasses", "A funky pair of thick glasses.");
      two.AddRoomItem(glasses);
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

      CurrentRoom = one;
      Running = true;
    }


    public void Run()
    {
      Initialize();
      Console.Clear();
      while (Running)
      {



      }
    }

    public void Setup()
    {

    }

    public void Reset()
    {

    }

    public void StartGame()
    {

    }

    public void GetUserInput()
    {

    }

    public void Quit()
    {

    }

    public void Help()
    {

    }

    public void Go(string direction)
    {

    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }
  }
}