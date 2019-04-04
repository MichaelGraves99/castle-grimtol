using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    List<Item> Items { get; set; }
    Dictionary<Direction, IRoom> Exits { get; set; }

    public void PrintItems()
    {
      Console.WriteLine("Items that are here:");
      Items.ForEach(name =>
      {
        Console.WriteLine(name);
      });
    }

    public void AddRoomItem(Item item)
    {
      Items.Add(item);
    }
    public void RemoveRoomItem(Item item)
    {
      Items.Remove(item);
    }


    public void AddExits(Direction direction, IRoom destination)
    {
      Exits.Add(direction, destination);
    }
    public IRoom MoveToRoom(Direction direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      System.Console.WriteLine("No Exit that direction");
      return (IRoom)this;
    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<Direction, IRoom>();
    }


  }
  public enum Direction
  {
    east,
    west,
    north,
    south
  }

}