using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<Direction, IRoom> Exits { get; set; }

    public void PrintItems(int numItems)
    {
      Console.WriteLine("Items in the Room:");
      for (int i = 0; i < numItems; i++)
      {
        Item CurrentItem = Items[i];
        Console.WriteLine($"{CurrentItem.Name} - {CurrentItem.Description}");
      }
      // Items.ForEach(name =>
      // {
      //   Console.WriteLine(name.Name);
      // });
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