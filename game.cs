using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeMagi
{
    internal class game
    {
        public string Name { get; internal set; }
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
      
        
        public Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();
            Artwork.Intro();
            Console.WriteLine("Adventure Game By Emma Prather!");
            ConsoleUtils.WaitForKeyPress();
            Console.WriteLine("You awake restless in an unframilar bed, tossing and turning in the darkness.\n");
            Artwork.Bed();
            Console.WriteLine("With eyes opened and delirious you sluggishly take inventory of your new reality, wait what was my name again?\n");
            Console.WriteLine("Type in the name of your Hero character.\n");
            p.name = Console.ReadLine();
            if (p.name == "")
            {
                Console.Clear();
                Console.WriteLine("You cant even remember your own name...");
                Console.WriteLine("Ah yes, I have no name that I can recall.\nMost people have called me Hero or Savior in the past, but that is more of a title.\n");
                p.name = "Hero";
                ConsoleUtils.WaitForKeyPress();
            }
            else
                ConsoleUtils.WaitForKeyPress();
            Console.Clear();
            Console.WriteLine("You ponder to yourself for a brief moment, trying to recall more about yourself.\n");
            Console.WriteLine("But what did I do? What fighting discipline did I ascribe to?\n");
            Artwork.Classes();
            Console.WriteLine("What was my class again?    [Mage]    [Archer]   [Warrior]\n");
            Console.WriteLine("Write out the name of the class to continue.\n");
            bool flag = false;
            while (flag == false)
            {
                flag = true;
                string input = Console.ReadLine().ToLower();
                if (input == "mage")
                    p.currentClass = Player.PlayerClass.Mage;
                else if (input == "Mage")
                    p.currentClass = Player.PlayerClass.Mage;
                else if (input == "archer")
                    p.currentClass = Player.PlayerClass.Archer;
                else if (input == "Archer")
                    p.currentClass = Player.PlayerClass.Archer;
                else if (input == "warrior")
                    p.currentClass = Player.PlayerClass.Warrior;
                else if (input == "Warrior")
                    p.currentClass = Player.PlayerClass.Warrior;
                else
                {
                    Console.WriteLine("Please choose an existing class!");
                    flag = false;
                }
            }
            p.id = i;
            Console.Clear();
            Artwork.Spawn();
            Console.WriteLine("You look around your dark room. It appears to be a hollowed out cave of some kind. Loose rocks and pebbles litter the jagged floor.\nYou feel dazed and are having trouble remembering why you got locked up in the first place.\n");
           
                Console.WriteLine("you can recall that you have been called '" + p.name + "' in the past.\n");
            Console.WriteLine("you can also remember that you are a " + p.currentClass + "\n");
            ConsoleUtils.WaitForKeyPress();
            Console.WriteLine("You search around the dark room with squinted eyes. It is very barren, only the bare essentials like a bed and a small broken chair.\nAs you search around in the darkness you find a sealed and rusty iron door. You were definitely thrown in some decaying prison.\n");
            Artwork.Door();
            ConsoleUtils.WaitForKeyPress();
            Console.WriteLine("After some feeling around you discover a rusted handle! You feel some resistance as you yank it off it's hindges.\n");
            Console.WriteLine("The ancient door now in shambles you are able to lightly swing it open, you have escaped your capture.\n");
            Console.WriteLine("While searching around you take a satchel containing five health potions and some starter gold,\nthis should come in handy for the adventure ahead.\n");
            ConsoleUtils.WaitForKeyPress();
            Console.WriteLine("As you sneak around the darkened compound you finally see your captor, a ruggish rouge counting coins.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("He is standing between you and what you presume to be the outside door!\n");

            Console.ResetColor();
            Console.WriteLine("There is no time to think! you need to get out of here!\n");
            ConsoleUtils.WaitForKeyPress();
            Console.WriteLine("Combat Tutorial\n");
           
            Console.WriteLine("You are about to proceed into your first of many combat encounters.\n\nAs a general tip, the first number under the enemy’s name is ther combative abilities.\nAs in how much damage they can do with some degree of random variation.\n\nTheir amount of health is the second number,\ntry to get this number to zero without losing all of your own health.\n");
            Console.WriteLine("Example Monster");
            Console.WriteLine("1 / 6\n");
            ConsoleUtils.WaitForKeyPress();
            return p;
        }
    }
}
