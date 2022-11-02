using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeMagi
{
    [Serializable]
    public class Player
    {
        public Random rand = new Random();

        public string name;
        public int id;
        public int coins = 100;
        public int level = 1;
        public int xp = 0;
        public int health = 15;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;

        public int mods = 0;

        public enum PlayerClass {Mage, Archer, Warrior};
        public PlayerClass currentClass = PlayerClass.Warrior;

        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }

        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }

        public int GetCoins()
        {
            int upper = (15 * mods + 50);
            int lower = (10 * mods + 10);
            return rand.Next(lower, upper);
        }

        public int GetXP()
        {
            int upper = (20 * mods + 50);
            int lower = (15 * mods + 10);
            return rand.Next(lower, upper);
        }

        public int GetLevelUpValue()
        {
            return 100 * level + 120;
        }

        public bool CanLevelUp()
        {
            if (xp >= GetLevelUpValue())
                return true;
            else
                return false;
        }

        public void LevelUp()
        {
            while (CanLevelUp())
            {
                xp -= GetLevelUpValue();
                level++;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Congrats! You have advanced to level " + level + "!");
            Console.ResetColor();
            Console.WriteLine("Wait..something feels wrong");
            ConsoleUtils.WaitForKeyPress();
           Encounters.DemonKingEncounter();
        }

     
    }




}
