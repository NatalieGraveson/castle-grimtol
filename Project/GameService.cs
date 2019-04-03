using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    //public bool playing

    public void GetUserInput()
    {

    }

    public void Go(string direction)
    {

    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }

    public void Setup()
    {
      //create rooms 
      Room SpinFall1 = new Room("SpinFall1", "A fun melody is playing in the darkness around you while you spin in endless circles.");
      Room SpinFall2 = new Room("SpinFall2", "The floor is no longer spinning but it is difficult to see ahead.");
      Room Mirrors1 = new Room("Mirrors1", "The floor beneath you is no longer moving...but everywhere you look you see yourself. As the strobe lights flash you can not tell where to go from here");
      Room Mirrors2 = new Room("Mirrors2", "You continue to see multiples of yourself, There is a quote in front of you that reads: mirror mirror on the wall who is the funniest of all");
      Room Mirrors3 = new Room("Mirrors3", "This room is completely dark...");
      Room Mirrors4 = new Room("Mirrors4", "");
      Room Maze = new Room("Maze", "Music continues to play, but once again you are left in the dark. As you feel around you appear to be in a tight hallway");
      Room Clowns = new Room("Clowns", "Finally you have found yourself in a well lit area. You see a door, lockers, and clowns all around.");
      Room Winner = new Room("Winner", "Althought tramatized, you are appear to be back on the boardwalk breathing in salty air and french fries.");
      //give rooms exists
      SpinFall.Exits.Add("north", (IRoom)Mirrors);
      Mirrors.Exits.Add("east", (IRoom)Maze);
      Maze.Exits.Add("north", (IRoom)Clowns);
      Clowns.Exits.Add("west", (IRoom)Winner);
      //create items
      Item Doll = new Item("Doll", "");
      Item Costume = new Item("Clown Costume", "");
      //give rooms their items
      //set the current room

    }

    public void StartGame()
    {




    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }
  }
}