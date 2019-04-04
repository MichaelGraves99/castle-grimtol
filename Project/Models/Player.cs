using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }


    public Player(string PlayerName)
    {
      PlayerName = PlayerName;
      Inventory = new Llist<Item>();

    }
  }
}