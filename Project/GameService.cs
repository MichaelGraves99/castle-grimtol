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




    public void Run()
    {

      Setup();
      Console.Clear();
      StartGame();
      while (Running)
      {
        Console.WriteLine($"{CurrentRoom.Description}");
        if (CurrentRoom.Items.Count != 0)
        {
          int numItems = CurrentRoom.Items.Count;
          CurrentRoom.PrintItems(numItems);
        }

        GetUserInput();


      }
    }

    public void Setup()
    {
      //Create Rooms
      Room one = new Room("one", "You are in a metal room about 15 feet square, with exit portals to the North, South, and West.");
      Room two = new Room("two", "You are in a metal room about 15 feet square, with exit portals to the East, West, and South.");
      Room three = new Room("three", "You are in a metal room about 15 feet square, with exit portals to the North, South, and West.");
      Room four = new Room("four", "You are in a metalroom about 15 feet square, with exit portals to the East, West, and South.");
      Room five = new Room("five", "You are in a metal room about 15 feet square, with no exits.");
      //Create Items
      Item glasses = new Item("Glasses", "A funky pair of thick glasses.");
      Item gun = new Item("Gun", "A loaded gun.");
      Item duck = new Item("Duck", "Yellow Rubber Duck");
      two.AddRoomItem(glasses);
      one.AddRoomItem(gun);
      three.AddRoomItem(duck);
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

    public void Reset()
    {

    }

    public void StartGame()
    {
      Console.WriteLine("Welcome to the Portal Room Game");
      Console.WriteLine("The Goal is to Find the Exit.\n");
      Help();
      Console.WriteLine("\nPlease Enter Player Name to Play:");
      string PlayerName = Console.ReadLine().ToUpper();
      CurrentPlayer = new Player(PlayerName);
      Console.WriteLine("You Wake up in a room and you can't remember how you got there.\n");

    }

    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do:");
      string userInput = Console.ReadLine().ToLower();
      string[] input = userInput.Split(" ");
      string command = "";
      string option = "";
      if (input.Length < 2)
      {
        command = input[0];
      }
      else
      {
        command = input[0];
        option = input[1];
      }

      switch (command)
      {

        case "look":
          Look();
          break;
        case "inventory":
          Inventory();
          break;
        case "help":
          Help();
          break;
        case "quit":
          Quit();
          break;
        case "go":
          Go(option);
          break;
        case "get":
          Get(option);
          break;
        case "drop":
          Drop(option);
          break;
        case "use":
          Use(option);
          break;
        default:
          Console.WriteLine("Not a valid command.\n");
          break;
      }


    }

    public void Quit()
    {
      Running = false;
    }

    public void Help()
    {
      Console.WriteLine("Commands used in this game:");
      Console.WriteLine("Help  -  Displays a list of commands used in this game");
      Console.WriteLine("Quit  -  Quits Game");
      Console.WriteLine("Look  -  Displays Room Description and Items in Room");
      Console.WriteLine("Invetory  -  Displays the Items you have");
      Console.WriteLine("Go 'direction'  -  Direction can be north, south, east, west");
      Console.WriteLine("Get 'Item'  -  Gets an Item if it's in the room");
      Console.WriteLine("Drop 'Item'  -  Drops an Item you have");
      Console.WriteLine("Use 'Item'  -  Uses an Item you have\n");


    }

    public void Look()
    {
      Console.Clear();
      return;
    }
    public void Inventory()
    {
      if (CurrentPlayer.Inventory.Count != 0)
      {
        int numItems = CurrentPlayer.Inventory.Count;
        CurrentPlayer.PrintInventory(numItems);
      }
      else
      {
        Console.WriteLine("You have nothing.");
      }
    }


    public void Go(string dir)
    {
      Room CurRoom = (Room)CurrentRoom;
      switch (dir)
      {
        case "north":
          CurrentRoom = (Room)CurRoom.MoveToRoom(Direction.north);
          break;
        case "south":
          CurrentRoom = (Room)CurRoom.MoveToRoom(Direction.south);
          break;
        case "east":
          CurrentRoom = (Room)CurRoom.MoveToRoom(Direction.east);
          break;
        case "west":
          CurrentRoom = (Room)CurRoom.MoveToRoom(Direction.west);
          break;
        default:
          System.Console.WriteLine("Not a valid direction!\n");
          return;
      }
      Console.Clear();

    }


    public void TakeItem(string itemName)
    { }
    public void UseItem(string itemName)
    { }

    public void Get(string itemName)
    {
      Item item = CurrentRoom.Items.Find(thing =>
      {
        return thing.Name.ToLower() == itemName;
      });
      if (item != null)
      {
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        Console.WriteLine("You now have an item\n");
      }
      else
      {
        Console.WriteLine("You can't have that!");
      }

    }

    public void Use(string itemName)
    {
      Item item = CurrentPlayer.Inventory.Find(thing =>
      {
        return thing.Name.ToLower() == itemName;
      });
      switch (itemName)
      {
        case "glasses":
          if (CurrentRoom.Name == "five")
          {
            Console.WriteLine("Putting on the glasses here reveals the secret hidden exit.\n");
            Console.WriteLine("Congratulations. You Survived.  You Won.");
            Running = false;
            return;
          }
          else
          {
            Console.WriteLine("You get a massave headache and quickly remove the glasses");
          }
          break;
        case "gun":
          Console.WriteLine("You shoot the gun, the bullet richochets off the walls and you die!!");
          Running = false;
          return;
        case "duck":
          Console.WriteLine("You can't use a rubber duck");
          break;
        default:
          System.Console.WriteLine("You don't havae that item.\n");
          break;
      }
    }


    public void Drop(string itemName)
    {
      Item item = CurrentPlayer.Inventory.Find(thing =>
      {
        return thing.Name.ToLower() == itemName;
      });
      if (item != null)
      {
        CurrentRoom.Items.Add(item);
        CurrentPlayer.Inventory.Remove(item);
        Console.WriteLine("You now have an item\n");
      }
      else
      {
        Console.WriteLine("You can't have that!");
      }

    }
  }
}