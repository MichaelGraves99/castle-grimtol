using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public void AddInventoryItem(Item item)
    {
      Inventory.Add(item);
    }
    public void RemoveInventoryItem(Item item)
    {
      Inventory.Remove(item);
    }
    public void PrintInventory(int numItems)
    {
      Console.WriteLine("\nThings you are carrying:");
      for (int i = 0; i < numItems; i++)
      {
        Item CurInventory = Inventory[i];
        Console.WriteLine($"{CurInventory.Name} - {CurInventory.Description}");
      }
      Console.WriteLine("\n");
    }

    public Player(string playerName)
    {
      PlayerName = playerName;
      Inventory = new List<Item>();

    }
  }
}