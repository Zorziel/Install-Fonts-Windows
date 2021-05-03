using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InstallFonts
{
    class Program
    {
        static void Main(string[] args)
        {


            ///////////////////////
            // PREPARING CONSOLE //
            ///////////////////////
            

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.Title = "Zorziel's Fonts Installer v1.02";

            Console.WriteLine();
            Console.Write("Starting install of included fonts... ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please be patient!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();

            

            ///////////////////////
            // USING FontReg.exe //
            ///////////////////////
            /*
            var info = new ProcessStartInfo()
            {
                FileName = "Path\to\FontReg.exe",
                Arguments = "/copy",
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden

            };
            Process.Start(info);

            */


            // USING CUSTOM //


            //DirectoryUtilities.ProcessDirectory(".");
            //string[] folders = DirectoryUtilities.ReturnFoldersInDirectory("..\\..\\");
            //string[] files = DirectoryUtilities.ReturnFilesInDirectory("..\\..\\");

            /*
            string[] folders = DirectoryUtilities.ReturnFoldersInDirectory("Fonts");
            string[] files = DirectoryUtilities.ReturnFilesInDirectory("..\\..\\");


            foreach (string folder in folders)
            {
                Console.WriteLine("folder: " + folder);



                foreach (string file in files)
                {
                    Console.WriteLine("file: " + file);
                   
                }

            }
            */


            //DirectoryUtilities.ProcessFonts("Fonts");
            ProcessFonts("Fonts");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("All done!");
            Console.WriteLine();

            // Wait for 5 seconds
            System.Threading.Thread.Sleep(2000);


            //Console.WriteLine();
            //Console.Write("Press any key to quit...");
            //Console.ReadKey();
        }


        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static void ProcessFonts(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            
            foreach (string fileName in fileEntries)
            {
                if (fileName.EndsWith(".ttf") || fileName.EndsWith(".otf"))
                {
                    string fn = Path.GetFileName(fileName);
                    //Console.Write("Font: ");
                    //DirectoryUtilities.ProcessFile(fileName);
                    try
                    {
                        Console.Write("Processing " + fn + "...");
                        FontInstaller.RegisterFont(fn);
                        //Console.ForegroundColor = ConsoleColor.Green;
                        //Console.WriteLine("Success!");
                        //Console.ResetColor();

                    } catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: " + ex.ToString());
                        Console.ResetColor();

                    }
                    
                }

            }


            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessFonts(subdirectory);
        }

    }
}
