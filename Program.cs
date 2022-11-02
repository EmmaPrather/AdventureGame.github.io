/*
 * The Three Magi: Infinite Dreams
 * by: Emma Prather, October 19th, 2022.
 * 
 * This work is a derivate of:
 * "C# Adventure Game" by http://programmingisfun.com, used under CC BY.
 * https://creativecommons.org/licenses/by/4.0/
 * 
 * EnderUnkown's "Text-Based Adventure Ep1: Getting Started!"
 * Combat/Run system used as Framework
 * https://www.youtube.com/watch?v=EURyF4U5OKw&ab_channel=EnderUnknown
 * 
 * Professor Mike Hadley's "Intro to C#: 30 - Adventure Game Architecture Walkthrough"
 * ConsoleUtils Class
 * https://www.youtube.com/watch?v=eBadZxYe6I4&t=289s&ab_channel=MichaelHadley
*/




using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace ThreeMagi
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

        static void Main(string[] args)
        {
            Title = "The Three Magi: Infinite Dreams";
            CursorVisible = false;
           try
            {
                WindowWidth = 230;
                WindowHeight = 65;
            }
           catch
           {
                ConsoleUtils.WaitForKeyPress();
            }

           if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }

            currentPlayer = Load(out bool newP);
            if(newP)
            {
                Encounters.FirstEncounter();
            }
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        
        }

        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

        // Could not figure out how to convert binfrom serialization to xml or json. All the code is there for making savefiles but I keep getting an error saying it is obsolute. https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            //binForm.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
           
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
               // Player player = (Player)binForm.Deserialize(file);
                file.Close();
                //players.Add(player);

            }

            idCount = players.Count;
        
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hello and welcome to 'The Three Magi: Infinite Dreams', before we begin do you have a previous save state?");
                Console.WriteLine("\nChoose your Player Save:\n");

                foreach (Player p in players)
               {
                Console.WriteLine(p.id + ": " + p.name);
               }
                Console.WriteLine("Please input player name or id (id:# or playername).");
                Console.WriteLine("\nAdditionally, typing 'create' will start a new save.\n");
                string[] data = Console.ReadLine().Split(':');
                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1],out int id))
                        {
                            foreach (Player player in players)
                            {
                                if(player.id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("there is no player with that id!");
                            ConsoleUtils.WaitForKeyPress();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number!");
                            ConsoleUtils.WaitForKeyPress();
                        }
                    }
                    else if (data[0] == "create")
                    {
                       game game = new game();
                       //game.NewStart(idCount);

                        Player newPlayer = game.NewStart(idCount);
                        newP = true;
                        return newPlayer;
                        
                    }
                    else if (data[0] == "Create")
                    {
                        game game = new game();
                        //game.NewStart(idCount);

                        Player newPlayer = game.NewStart(idCount);
                        newP = true;
                        return newPlayer;

                    }

                    else
                    {
                        foreach (Player player in players)
                        {
                            if(player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name!");
                        ConsoleUtils.WaitForKeyPress();
                    }
                    
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number! Press any key to continue.");
                    ConsoleUtils.WaitForKeyPress();
                }
            }
           
        }
        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for(int i = 0; i < size; i++)
            {
                if (i < dif)
                    Console.Write(fillerChar);
                else
                    Console.Write(backgroundChar);
            }
        }
    }




}