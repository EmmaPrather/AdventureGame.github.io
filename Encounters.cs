//This work is a derivate of:
//"EnderUnkown's Text-Based Adventure Ep1: Getting Started!"
 //* Combat / Run system used as Framework"
// * https://www.youtube.com/watch?v=EURyF4U5OKw&ab_channel=EnderUnknown





using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ThreeMagi
{
    public class Encounters
    { 
        static Random rand = new Random();
        // Generic Encounter



        //Encounters
        public static void FirstEncounter()
        {
            Artwork.Sword();
            Console.WriteLine("You dash towards a rusty metal sword in the corner of the room, then you charge toward your self-proclaimed warden.\n");
            Console.WriteLine("He laughs to himself, taking out his daggers. He wasn't phased at all by your escape attempt.\n");

            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleUtils.WaitForKeyPress();
            Console.ResetColor();
            Combat(false, "Human Rouge", 2, 6);
            
            Console.WriteLine("After some time to think you consider that there may be one group of powerful wizards that can cure you of your memory loss.\n\nThe Three Magi of ancient legend were known to use powerful spells to fix any issue.\n\nYou are fortunate that you remembered that fact at least.\n");
            ConsoleUtils.WaitForKeyPress();
            Console.WriteLine("The problem is that no one has seen them in centuries.\n\nHowever, your determination to regain your memories is stronger than any monster you may face in finding them.\n ");
            Console.WriteLine("You leave the prison out the front door and begin your grand quest to find the Three Magi!\n");
            ConsoleUtils.WaitForKeyPress();
            RandomEncounter();

        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("While you were walking you notice an evil force coming toward you!");
            Console.WriteLine("You ready your weapon for combat!");
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleUtils.WaitForKeyPress();
            Console.ResetColor();
            Combat(true, "", 0, 0);

        }
        public static void WizardEncounter()
        {
            Console.Clear();
            Console.WriteLine("While you were walking you see an old withered man\n");
            Console.WriteLine("He has a long white beard and appears to be practicing spells of immense power\n");
            Artwork.Wizard();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ConsoleUtils.WaitForKeyPress();
            Console.ResetColor();
            Combat(false, "Dark Wizard", 2, 8);
        }
        public static void DemonKingEncounter()
        {
            Console.Clear();
            Console.WriteLine("You stumble to the ground as you feel the land trembling around you, the feeling of sweat boiling on your brow.\n");
            Console.WriteLine("A crack in the earth has formed in front of you, a true challenge has come to face you!\n");
            Console.WriteLine("You hear the loud roar of legend, you know this creature from anicent tomes and fairy tales. The king of all demons, master of evil.\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Artwork.Demon();
            ConsoleUtils.WaitForKeyPress();
            Console.ResetColor();
            Combat(false, "Demon King", 4, 15);
            Console.WriteLine("Out of the beast's stomach spills out the three Magi of legend.\n");
            Console.WriteLine("While gross you are happy to free them from the beast's insides.\n");
            Console.WriteLine("They explain that they were swallowed long ago when performing a demon summoning, hence their century long disappearance.\n");
            Console.WriteLine("You realize that you have now found the cure to your memory loss problem!\n");
            ConsoleUtils.WaitForKeyPress();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("YOU DID IT! YOU COMPLETED YOUR QUEST!\n");
            Console.ResetColor();

            Console.WriteLine("You have also completed the game!\n");
            Artwork.End();
            ConsoleUtils.QuitConsole();


        }

        public static void GoldStash()
        {
            Console.Clear();
            Console.WriteLine("While walking you find a toppled trading cart.\n");
            int c = Program.currentPlayer.GetCoins();
            Console.WriteLine("After some searching you uncover " + c + " gold coins!\n");
            Console.WriteLine("While questioning your own morality,\nYou realize you could probably make better use of the gold then someone else who may come along.\n");
            Program.currentPlayer.coins += c;
            ConsoleUtils.WaitForKeyPress();
        }


        public static void PuzzleOneEncounter()
        {
            Console.Clear();
            Artwork.Temple();
            Console.WriteLine("\n" + "Health: " + Program.currentPlayer.health);
            Console.WriteLine("\nYou discover an ancient temple in the forrest, when walking down the stone stairs you see that the floor is covered in different runes.");
            List<char> chars = new char[] { '£', '#', '§', 'X', '√', '∑', '¥', '¢', 'Z', 'Ω' }.ToList();
            List<int> positions = new List<int>();
            char c = chars[rand.Next(0, 10)];     
            chars.Remove(c);
            for (int y = 0; y < 4; y++)
            {
                int pos = rand.Next(0, 4);
                positions.Add(pos);
                Console.Write("\n");
                for (int z = 0; z < 4; z++)
                {
                    if (z == pos)
                    {
                        Console.Write(c);
                       
                    }


                    else
                    {
                        Console.Write(chars[rand.Next(0, 8)]);
                      
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("\nChoose your path:\n\n(Type the numbered position of the rune you want to stand on for each row.\nLeft to right, only number positions 1-4.)\n");
            Console.WriteLine("You theorize that the matching symbols on each row might be the trick.\n");
            for (int i = 0; i < 4; i++ )
            {
                while (true)
                {
                    if(int.TryParse(Console.ReadLine(), out int input) && input < 5 && input > 0)
                    {
                        if (positions[i] == input - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The rune glows slightly, you have made the correct choice. You ready yourself to continue forward.\n");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Darts fly out of the walls! You take 2 damage.");
                            Console.ResetColor();
                            Program.currentPlayer.health -= 2;
                            Console.WriteLine("\n" + "Health: " + Program.currentPlayer.health);
                            Console.WriteLine("\nBest to move forward then to restart, you ready yourself to continue forward.\n");
                           
                         
                            if (Program.currentPlayer.health <= 0)
                            {
                                //Death Code
                                Console.WriteLine("You start to feel sick. The poison from the darts slowly kills you.\n");
                                Console.WriteLine("Game Over");
                                Console.ReadKey();
                                System.Environment.Exit(0);
                            }
                            break;

                        }
                    }
                    else
                        Console.WriteLine("Invalid Input: Whole numbers 1-4 only\n");
                     
                    

                }
                
               
            }
            
            int x = Program.currentPlayer.GetXP();
            Console.WriteLine("You have successfully crossed the hallway!");
            Console.WriteLine("You have gained " + x + " XP!");
            Program.currentPlayer.xp += x;
            if (Program.currentPlayer.CanLevelUp())
                Program.currentPlayer.LevelUp();
            ConsoleUtils.WaitForKeyPress();


        }


        // Encounter Tools
        public static void RandomEncounter()
        {
            switch(rand.Next(0,4))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    WizardEncounter();
                    break;
                case 2:
                    PuzzleOneEncounter();
                    break;
                case 3:
                    GoldStash();
                    break;

            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;

            }
            
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("\n\n=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un    (H)eal   |");
                Console.WriteLine("=====================\n");
                Console.WriteLine(" Potions: " + Program.currentPlayer.potion + "  Health: " + Program.currentPlayer.health);
                Console.WriteLine("\n\n");
               Console.WriteLine("| Type The First Highlighted letter Of The Action To Continue |");
                Console.WriteLine("\n");
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack

                    Console.WriteLine("With haste you surge forward, your sword moving swiftly in your hands! As you strike, the " + n + " hits you back as you pass.");

                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 1;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4) + ((Program.currentPlayer.currentClass== Player.PlayerClass.Warrior)?2:0);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend

                    Console.WriteLine("As the " + n + " prepares to stike, you ready your sword in a defensive stance");

                    int damage = (p/2) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 1;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 3);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run
                    if(Program.currentPlayer.currentClass != Player.PlayerClass.Archer && rand.Next(0,2) == 0)
                    {
                        Console.WriteLine("As you sprint away from the " + n + ", it's strike catches you in the back, sending you to the floor");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 1;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape!");
                        Program.currentPlayer.health -= damage;
                        ConsoleUtils.WaitForKeyPress();
                    }
                    else
                    {
                        Console.WriteLine("you successfully evaded the " + n + " and you escape!");

                        ConsoleUtils.WaitForKeyPress();


                        //go to store
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                    if (Program.currentPlayer.potion==0)
                    {
                        Console.WriteLine("You realize that you are out of usable potions.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 1;
                        Console.WriteLine("The " + n + " strikes you with a mighty blow and you lose " + damage + " health!");
                        Program.currentPlayer.health -= damage;
                    }
                    else
                    {
                        Console.WriteLine("You quickly reach into your bag and pull out a large flask, drinking it in one big gulp!");
                        int potionV = 5 + ((Program.currentPlayer.currentClass == Player.PlayerClass.Mage)?+4:0);
                        Console.WriteLine("you gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        Program.currentPlayer.potion--;
                        Console.WriteLine("As you were occupied, the " + n + " advanced and struck.");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 1;
                        Console.WriteLine("you lose " + damage + " health.");
                    }
                    
                } 
                else
                { 
                    Console.WriteLine("Please choose a valid option! Type the first letters of the action");
                   
                }
                if (Program.currentPlayer.health <= 0)
                {
                    //Death Code
                    Console.WriteLine("As the " + n + " does one final strike to you, you start to tumble to the ground. You have been slayn by the " + n);
                    Console.WriteLine("Game Over");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

                ConsoleUtils.WaitForKeyPress();
            }
            int c = Program.currentPlayer.GetCoins();
            int x = Program.currentPlayer.GetXP();
            Console.WriteLine("As you stand victorius over the defeated " + n + ", you find " + c + " gold coins on it's body! You have gained "+x+" XP!");
            Program.currentPlayer.coins += c;
            Program.currentPlayer.xp += x;

            if (Program.currentPlayer.CanLevelUp())
                Program.currentPlayer.LevelUp();

            ConsoleUtils.WaitForKeyPress();
        }
        public static string GetName()
        {
            switch (rand.Next(0, 7))
            {
                case 0:
                    return "Rat";
                case 1:
                    return "Zombie";
                case 2:
                    return "Evil Cultist";
                case 3:
                    return "Bandit";
                case 4:
                    return "Imp";
                case 5:
                    return "Wolf";
                case 6:
                    return "Ghost";
            }
            return "Evil Rouge";
        }
    }
}
