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
      Console.WriteLine("\nWhat would you like to do:");
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
        case "l":
          Look();
          break;
        case "inventory":
        case "i":
          Inventory();
          break;
        case "help":
        case "h":
          Help();
          break;
        case "quit":
        case "q":
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
        case "n":
          CurrentRoom = (Room)CurRoom.MoveToRoom(Direction.north);
          break;
        case "south":
        case "s":
          CurrentRoom = (Room)CurRoom.MoveToRoom(Direction.south);
          break;
        case "east":
        case "e":
          CurrentRoom = (Room)CurRoom.MoveToRoom(Direction.east);
          break;
        case "west":
        case "w":
          CurrentRoom = (Room)CurRoom.MoveToRoom(Direction.west);
          break;
        default:
          System.Console.WriteLine("Not a valid direction!\n");
          return;
      }
      Console.Clear();
    }
    public void Get(string itemName)
    {
      if (CurrentPlayer.Inventory.Count == 5)
      {
        System.Console.WriteLine("You can't carry more than 4 Items:");
      }
      else
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
          Console.WriteLine("You can't use a rubber duck.");
          break;
        case "glove":
          Console.WriteLine("You are now wearing a ski glove on your left hand.");
          break;
        case "zune":
          Console.WriteLine("Zunes were junk even if they aren't broken.");
          break;
        case "tape":
          Console.WriteLine("No 8-Track player. Have you even seen an 8-Track?");
          break;
        case "boombox":
          Console.WriteLine("Some Nickleback starts playing, then stops.");
          break;
        case "beaniebaby":
          Console.WriteLine("You can't really use a Darth Vader beanie baby. It is kinda cute.");
          break;
        case "clock":
          Console.WriteLine("Not sure what you want to do with a busted clock.");
          break;
        case "tshirt":
          Console.WriteLine("Now you are wearing an awesome Boise Codeworks T-shirt.");
          break;
        default:
          System.Console.WriteLine("You don't have that item.\n");
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
      }
      else
      {
        Console.WriteLine("You can't have that!");
      }

    }
    public void Setup()
    {
      //Create Rooms
      Room one = new Room("one", "You are in a metal room about 15 feet square, with exit portals to the North, South, and West.");
      Room two = new Room("two", "You are in a metal room about 15 feet square, with exit portals to the West, and South.");
      Room three = new Room("three", "You are in a metal room about 15 feet square, with exit portals to the West, and South.");
      Room four = new Room("four", "You are in a metal room about 15 feet square, with exit portals to the North, and East.");
      Room five = new Room("five", "You are in a metal room about 15 feet square, with exit portals to the North, and East.");
      Room six = new Room("six", "You are in a metal room about 15 feet square, with exit portals to the North, South, and West.");
      Room seven = new Room("seven", "You are in a metal room about 15 feet square, with an exit portal to the South.");
      Room eight = new Room("eight", "You are in a metal room about 15 feet square, with an exit portal to the North.");
      Room nine = new Room("nine", "You are in a metal room about 15 feet square, with exit portals to the North, South and East.");
      Room ten = new Room("ten", "You are in a metal room about 15 feet square, with exit portals to the North, South, and West.");
      Room eleven = new Room("eleven", "You are in a metal room about 15 feet square, with exit portals to the North, South and East.");
      Room twelve = new Room("twelve", "You are in a metal room about 15 feet square, with exit portals to the East and South.");
      Room thirteen = new Room("thirteen", "You are in a metal room about 15 feet square, with exit portals to the East, West, and South.");
      Room fourteen = new Room("fourteen", "You are in a metal room about 15 feet square, with exit portals to the East, West, and South.");
      Room fifteen = new Room("fifteen", "You are in a metal room about 15 feet square, with portals to the North and South.");
      Room sixteen = new Room("sixteen", "You are in a metal room about 15 feet square, with exit portals to the North and West.");
      Room seventeen = new Room("seventeen", "You are in a metal room about 15 feet square, with exit portals to the North and West.");
      Room eighteen = new Room("eighteen", "You are in a metal room about 15 feet square, with no exits.");
      //Create Items
      Item glasses = new Item("Glasses", "A funky pair of thick glasses.");
      Item gun = new Item("Gun", "A loaded gun.");
      Item duck = new Item("Duck", "Yellow Rubber Duck.");
      Item glove = new Item("Glove", "A left hand ski glove.");
      Item zune = new Item("Zune", "A Zune with a broken screen.");
      Item tape = new Item("Tape", "An Iron Maiden 8-Track Tape.");
      Item radio = new Item("BoomBox", "A BoomBox radio in decent shape.");
      Item beaniebaby = new Item("BeanieBaby", "A Darth Vader BeanieBaby.");
      Item clock = new Item("Clock", "A Broken Clock.");
      Item tshirt = new Item("Tshirt", "A Boise CodeWorks T-shirt.");
      two.AddRoomItem(glasses);
      five.AddRoomItem(gun);
      three.AddRoomItem(duck);
      four.AddRoomItem(glove);
      twelve.AddRoomItem(zune);
      eleven.AddRoomItem(tape);
      six.AddRoomItem(radio);
      one.AddRoomItem(beaniebaby);
      fifteen.AddRoomItem(clock);
      eight.AddRoomItem(tshirt);
      //Establish Relationships
      one.AddExits(Direction.west, eleven);
      one.AddExits(Direction.north, two);
      one.AddExits(Direction.south, four);
      two.AddExits(Direction.west, ten);
      two.AddExits(Direction.south, four);
      three.AddExits(Direction.west, two);
      three.AddExits(Direction.south, twelve);
      four.AddExits(Direction.north, two);
      four.AddExits(Direction.east, fifteen);
      five.AddExits(Direction.north, three);
      five.AddExits(Direction.east, six);
      six.AddExits(Direction.north, eight);
      six.AddExits(Direction.west, three);
      six.AddExits(Direction.south, seven);
      seven.AddExits(Direction.south, seventeen);
      eight.AddExits(Direction.north, thirteen);
      nine.AddExits(Direction.north, eight);
      nine.AddExits(Direction.east, three);
      nine.AddExits(Direction.south, seven);
      ten.AddExits(Direction.north, one);
      ten.AddExits(Direction.west, two);
      ten.AddExits(Direction.south, thirteen);
      eleven.AddExits(Direction.north, three);
      eleven.AddExits(Direction.east, two);
      eleven.AddExits(Direction.south, ten);
      twelve.AddExits(Direction.south, eighteen);
      twelve.AddExits(Direction.east, five);
      thirteen.AddExits(Direction.east, ten);
      thirteen.AddExits(Direction.west, fourteen);
      thirteen.AddExits(Direction.south, seventeen);
      fourteen.AddExits(Direction.west, eleven);
      fourteen.AddExits(Direction.east, ten);
      fourteen.AddExits(Direction.south, twelve);
      fifteen.AddExits(Direction.north, two);
      fifteen.AddExits(Direction.south, sixteen);
      sixteen.AddExits(Direction.west, twelve);
      sixteen.AddExits(Direction.north, seven);
      seventeen.AddExits(Direction.north, one);
      seventeen.AddExits(Direction.west, five);



      CurrentRoom = one;
      Running = true;
    }

  }
}