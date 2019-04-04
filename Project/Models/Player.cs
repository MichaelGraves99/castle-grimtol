using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }

    public void AddInvetoryItem(Item item)
    {
      Inventory.Add(item);
    }
    public void RemoveInventoryItem(Item item)
    {
      Inventory.Remove(item);
    }


    public Player(string playerName)
    {
      PlayerName = playerName;
      Inventory = new List<Item>();

    }
  }
}