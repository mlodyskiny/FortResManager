using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ResolutionManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FortResManager | made by parkie#3604 for FMod");
            Console.WriteLine("Join discord.gg/fmod for OG Fortnite!");

            string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + 
                                            "\\FortniteGame\\Saved\\Config\\WindowsClient\\GameUserSettings.ini");

            int Width = 0; int Height = 0;

            Console.Write("Enter the width of your new resolution: ");
            string WidthString = Console.ReadLine();
            if (!Int32.TryParse(WidthString, out Width)) 
            {
                Console.WriteLine("The width you have provided is not an integer, exiting...");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }

            Console.Write("Enter the height of your new resolution: ");
            string HeightString = Console.ReadLine();
            if (!Int32.TryParse(HeightString, out Height))
            {
                Console.WriteLine("The height you have provided is not an integer, exiting...");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }

            if (Width > 0 && Height > 0)
            {
                IniFile ini = new IniFile(ConfigPath);
                string FortniteINIKey = "/Script/FortniteGame.FortGameUserSettings";

                ini.Write("ResolutionSizeX", Width.ToString(), FortniteINIKey);
                ini.Write("LastUserConfirmedResolutionSizeX", Width.ToString(), FortniteINIKey);
                ini.Write("DesiredScreenWidth", Width.ToString(), FortniteINIKey);
                ini.Write("LastUserConfirmedDesiredScreenWidth", Width.ToString(), FortniteINIKey);

                ini.Write("ResolutionSizeY", Height.ToString(), FortniteINIKey);
                ini.Write("LastUserConfirmedResolutionSizeY", Height.ToString(), FortniteINIKey);
                ini.Write("DesiredScreenHeight", Height.ToString(), FortniteINIKey);
                ini.Write("LastUserConfirmedDesiredScreenHeight", Height.ToString(), FortniteINIKey);
            }
        }
    }
}
