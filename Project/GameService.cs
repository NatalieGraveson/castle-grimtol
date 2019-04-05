using System;
using System.Collections.Generic;
using System.Linq;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public Room LockedRoom1 { get; set; }
    public Room LockedRoom2 { get; set; }
    //public bool playing

    public void GetUserInput()
    {
      string[] Command = Console.ReadLine().Split(" ");
      string choice = Command[0].ToLower();
      string option = "";
      if (Command.Length > 1)
      {
        option = Command[1].ToLower();
      }



      switch (choice)
      {
        case "go":
          Go(option);
          break;
        case "use":
          UseItem(option);
          break;
        case "take":
          TakeItem(option);
          break;
        case "look":
          Look();
          break;
        case "help":
          Help();
          break;
        case "quit":
          Quit();
          break;
        case "inventory":
          Inventory();
          break;
        default:
          System.Console.WriteLine("command is unknown");
          break;

      }
    }



    public void Go(string direction)
    {

      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = (Room)CurrentRoom.Exits[direction];
        Look();
      }
      else
      {
        System.Console.WriteLine("You hit a wall");

      }
    }

    public void Help()
    {
      System.Console.WriteLine(" please type: go, look, take, use, inventory, or quit");

    }

    public void Inventory()
    {
      if (CurrentPlayer.Inventory.Count > 0)
      {
        System.Console.WriteLine($"{CurrentPlayer.Inventory}");
        CurrentPlayer.Inventory.ForEach(i =>
       {
         Console.WriteLine(i.Description);
       });
      }
      else
      {
        System.Console.WriteLine("No inventory");
      }


    }

    public void Look()
    {
      System.Console.WriteLine($"{CurrentRoom.Description}");
      CurrentRoom.Items.ForEach(item =>
      {
        Console.WriteLine(item.Description);
      });

    }

    public void Quit()
    {
      return;

    }

    public void Reset()
    {
      Console.Clear();
      Setup();

    }

    public void Setup()
    {
      //create rooms 
      Room Door = new Room("Door", "go north to enter door.");
      Room SpinFall1 = new Room("SpinFall1", "A fun melody is playing in the darkness around you while you spin in endless circles.");
      Room SpinFall2 = new Room("SpinFall2", "The floor is no longer spinning but it is difficult to see ahead.");
      Room Mirrors1 = new Room("Mirrors1", "The floor beneath you is no longer moving...but everywhere you look you see yourself. As the strobe lights flash you can not tell where to go from here");
      Room Mirrors2 = new Room("Mirrors2", "You continue to see multiples of yourself, There is a quote in front of you that reads: mirror mirror on the wall who is the funniest of all");
      Room Mirrors3 = new Room("Mirrors3", "This room is completely dark but you can see two switches blinking on the wall in front of you...please type 'use' and select and switch");
      Room Mirrors4 = new Room("Mirrors4", "There appears to be nothing in this room");//how do i make this change after correct switch is flipped 
      Room Maze1 = new Room("Maze1", "Music continues to play, but once again you are left in the dark. As you feel around you appear to be in a tight hallway");
      Room Maze2 = new Room("Maze2", "Music continues to play, but once again you are left in the dark. As you feel around you appear to be in a tight hallway");
      Room Maze3 = new Room("Maze3", "Music continues to play, but once again you are left in the dark. As you feel around you appear to be in a tight hallway");
      Room Maze4 = new Room("Maze4", "Music continues to play, but once again you are left in the dark. As you feel around you appear to be in a tight hallway");
      Room Maze5 = new Room("Maze5", "Music continues to play, but once again you are left in the dark. As you feel around you appear to be in a tight hallway");
      Room Maze6 = new Room("Maze6", "Music continues to play, but once again you are left in the dark. As you feel around you appear to be in a tight hallway");
      Room Clowns1 = new Room("Clowns1", "Finally you have found yourself in a well lit area. There is a metal door to the east and a clown in front of you.");
      Room Clowns2 = new Room("Clowns2", "You find yourself face to face with a clown who states: some joke?. While he's talking you notice some lockers.");
      Room Clowns3 = new Room("Clowns3", "The lockers surround you on all sides as you walk up to one it asks you for a pin.");//should i put this here?
      Room Clowns4 = new Room("Clowns4", "This clown in front of you is different then the last it states:  blah blah blah.");
      Room Clowns5 = new Room("Clowns5", "You've bumped into ANOTHER clown. it quickly says: riddle");
      Room Winner = new Room("Winner", "Althought tramatized and dressed as a clown, you appear to be back on the boardwalk breathing in salty air and french fries.");

      LockedRoom1 = Maze1;
      LockedRoom2 = Winner;
      //give rooms exists
      Door.Exits.Add("north", (IRoom)SpinFall1);
      SpinFall1.Exits.Add("east", (IRoom)SpinFall2);
      SpinFall2.Exits.Add("north", (IRoom)Mirrors1);
      SpinFall2.Exits.Add("west", (IRoom)SpinFall1);
      Mirrors1.Exits.Add("south", (IRoom)SpinFall2);
      Mirrors1.Exits.Add("north", (IRoom)Mirrors2);
      Mirrors2.Exits.Add("south", (IRoom)Mirrors1);
      Mirrors2.Exits.Add("west", (IRoom)Mirrors3);
      Mirrors2.Exits.Add("east", (IRoom)Mirrors4);
      Mirrors3.Exits.Add("east", (IRoom)Mirrors2);
      Mirrors4.Exits.Add("west", (IRoom)Mirrors2);
      Maze1.Exits.Add("north", (IRoom)Maze2);
      Maze2.Exits.Add("west", (IRoom)Maze3);
      Maze2.Exits.Add("south", (IRoom)Maze1);
      Maze3.Exits.Add("south", (IRoom)Maze4);
      Maze3.Exits.Add("east", (IRoom)Maze2);
      Maze4.Exits.Add("west", (IRoom)Maze5);
      Maze4.Exits.Add("north", (IRoom)Maze3);
      Maze5.Exits.Add("north", (IRoom)Maze6);
      Maze5.Exits.Add("east", (IRoom)Maze4);
      Maze6.Exits.Add("north", (IRoom)Clowns1);
      Maze6.Exits.Add("south", (IRoom)Maze5);
      Clowns1.Exits.Add("north", (IRoom)Clowns2);
      Clowns1.Exits.Add("south", (IRoom)Maze6);
      Clowns2.Exits.Add("east", (IRoom)Clowns3);
      Clowns2.Exits.Add("south", (IRoom)Clowns1);
      Clowns3.Exits.Add("west", (IRoom)Clowns2);
      Clowns3.Exits.Add("east", (IRoom)Clowns4);
      Clowns4.Exits.Add("west", (IRoom)Clowns3);
      Clowns4.Exits.Add("south", (IRoom)Clowns5);
      Clowns5.Exits.Add("north", (IRoom)Clowns4);

      //create items
      Item Doll = new Item("Doll", "There appears to be an old glass DOLL with long blonde hair and blood dripping down it's chin in the corner. The blood appears to come from it's mouth...");
      Item Costume = new Item("Costume", "You see a COSTUME. It is bright red, yellow, blue. It includes a clown nose, and rainbow hair");
      Item switch1 = new Item("switch1", "switch1");
      Item switch2 = new Item("switch2", "switch2");
      //give rooms their items
      Maze5.Items.Add(Doll);
      Clowns3.Items.Add(Costume);
      Mirrors3.Items.Add(switch1);
      Mirrors3.Items.Add(switch2);

      //set the current room
      CurrentRoom = Door;
      CurrentPlayer = new Player("BOB");
    }

    //look
    //print description
    //print items on loop
    //seperate dictionary called hidden exits


    public void StartGame()
    {
      System.Console.WriteLine("You're walking along a beach and wondered up onto the board walk to check out some shops and games. As you are eating some ice cream you find a fun house and think to yourself ....'hmm that looks pretty fun' You decide to walk in. Please type 'go north' to enter");
      bool playing = true;
      Setup();
      while (playing)
      {
        GetUserInput();

      }

    }



    public void TakeItem(string itemName)
    {

      Item item = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (item != null)
      {
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        if (item.Name == "Doll")
        {
          System.Console.WriteLine("Your neck has been bit and you die... GAME OVER. Do you want to try again? 'yes' or 'no'");
          string Selection = Console.ReadLine().ToLower();
          if (Selection == "yes")
          {
            Console.WriteLine("Please select a direction or look");
            Reset();

          }
          else
          {
            return;
          }
        }
      }
      else
      {
        System.Console.WriteLine("There is not an item here, or you have not entered item's name");

      }

    }


    public void UseItem(string itemName)
    {
      System.Console.WriteLine($"Using item in {CurrentRoom.Name}");
      Item i = CurrentRoom.Items.Find(items => items.Name.ToLower() == itemName.ToLower());
      if (i != null)
      {
        if (i.Name == "switch2" && CurrentRoom.Name == "Mirrors3")
        {
          CurrentRoom.Exits["east"].Exits["east"].Exits.Add("north", LockedRoom1);
          CurrentRoom.Exits["east"].Exits["east"].Description = "This room seemed to have nothing before.. but now i see a giant hole in the floor to the north";
          System.Console.WriteLine("There appears to be faint noise and light to the east");
        }
        else if (i.Name == "switch1" && CurrentRoom.Name == "Mirrors3")
        {
          System.Console.WriteLine("You have been electricuted... GAME OVER. Do you want to try again? 'yes' or 'no'");
          string Selection = Console.ReadLine().ToLower();
          if (Selection == "yes")
          {
            Console.WriteLine("Please select a direction or look");
            Reset();

          }

        }
        Item item = CurrentPlayer.Inventory.Find(itemc => itemc.Name.ToLower() == itemName.ToLower());
        if (itemName == "costume" && CurrentRoom.Name == "Clowns1")
        {
          CurrentRoom.Exits["north"].Exits["west"].Exits["west"].Exits["south"].Exits.Add("west", LockedRoom2);




        }

      }
      else
      {
        System.Console.WriteLine("item does not exsist..try again");
      }
    }





  }

}

