using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    List<Item> Items { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }


    public void AddExit(Direction direction, IRoom destination)
    {
      Exits.Add(direction, destination);
    }
    public IRoom MoveToRoom(Direction direction)
    {
      if (Exits.ContainsKey(dierection))
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