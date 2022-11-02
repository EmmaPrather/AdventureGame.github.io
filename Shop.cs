//This work is a derivate of:
//EnderUnkown's "C# Tutorial Text-Based Adventure Ep3: Adding a Shop!"
//* Shop system used as Framework"
// * https://www.youtube.com/watch?v=o5CZuUBIFq0&t=2158s&ab_channel=EnderUnknown



using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ThreeMagi
{
    public class Shop
    {
      
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }
        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;

            while (true)
            {
                potionP = 20 + 10 * p.mods;
                armorP = 100 * (p.armorValue + 1);
                weaponP = 100 * p.weaponValue;
                difP = 50 + 100 * p.mods;

                Console.Clear();
                Console.WriteLine("          Shop         ");
                Console.WriteLine("=======================");
                Console.WriteLine("(W)eapon:         $" + weaponP);
                Console.WriteLine("Increases Your Damage");
                Console.WriteLine("(A)rmor:          $" + armorP);
                Console.WriteLine("Increases Your Armor Rating");
                Console.WriteLine("(P)otion:         $" + potionP);
                Console.WriteLine("Increases Your Potion Amount");
                Console.WriteLine("(D)ifficulty Mod: $" + difP);
                Console.WriteLine("Increases The Difficulty");
                Console.WriteLine("Note: Enemies Do More Damage And Have Better Armor Ratings.");
                Console.WriteLine("=======================\n\n");
                Console.WriteLine("(E)xit Shop?");
               
                Console.WriteLine("\n");
                Console.WriteLine("(Q)uit Game?");
                Console.WriteLine("\n");

                Console.WriteLine( p.name +"'s Current Stats");
                Console.WriteLine("=======================");
                Console.WriteLine("Current Health: " + p.health);
                Console.WriteLine("Class: " + p.currentClass);
                Console.WriteLine("Coins: " + p.coins);
                Console.WriteLine("Weapon Strength: " + p.weaponValue);
                Console.WriteLine("Armor Strength: " + p.armorValue);
                Console.WriteLine("Potions: " + p.potion);
                Console.WriteLine("Difficulty Mods: " + p.mods);

                Console.WriteLine("Xp:");
                Console.Write("[");
                Program.ProgressBar("+", " ", ((decimal)p.xp / (decimal)p.GetLevelUpValue()),25);
                Console.Write("]");

                Console.WriteLine("level: " + p.level);
                Console.WriteLine("=======================\n\n");

                Console.WriteLine("| Type The First Highlighted letter Of The Action To Continue |");

                //Wait for input
                string input = Console.ReadLine().ToLower();
                if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }

                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }

                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorP, p);
                }

                else if (input == "d" || input == "difficulty mod")
                {
                    TryBuy("dif", difP, p);
                }
                else if(input == "q" || input == "quit")
                {
                    Program.Quit();
                }
                else if(input == "e" || input == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose a valid option! Type the first highlighted letter of the action");

                }
            }
        
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if(p.coins >= cost)
            {
                if (item == "potion")
                    p.potion++;
                else if (item == "weapon")
                    p.weaponValue++;
                else if (item == "armor")
                    p.armorValue++;
                else if (item == "dif")
                    p.mods++;

                p.coins -= cost;
            }
            else
            {
                Console.WriteLine("You dont have enough gold!");
                Console.ReadKey();
            }

        }
    } 

   
}
