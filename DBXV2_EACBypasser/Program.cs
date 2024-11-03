using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBXV2_EACBypasser
{
    internal class Program
    {
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //This is Very Important Code... DON'T CHANGE THIS!!! 

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"F:\TempDBXV2");
            if(!Directory.Exists("F:\\SteamLibrary\\steamapps\\common\\DB Xenoverse 2"))
            {
                Console.WriteLine("Failed to Find Directory of this Game!!!");
            }
            else
            {
                Console.WriteLine("Successfully to Find DBXV 2 Folder(Steam Version)");
                if (!File.Exists("F:\\SteamLibrary\\steamapps\\common\\DB Xenoverse 2\\START.exe"))
                {
                    Console.WriteLine("Not Founded File To Start EAC!!!");
                }
                else
                {
                    Console.WriteLine("Founded File to START EAC for Playing Multiplayer... Trying To Bypass EAC!!!");
                    Thread.Sleep(1200);
                    Extract("DBXV2_EACBypasser", @"F:\TempDBXV2", "Resources", "DBXV2_FakeSTART_EAC.exe");
                    File.Copy("F:\\SteamLibrary\\steamapps\\common\\DB Xenoverse 2\\START.exe", "F:\\SteamLibrary\\steamapps\\common\\DB Xenoverse 2\\STARTCopy.exe");
                    File.Delete("F:\\SteamLibrary\\steamapps\\common\\DB Xenoverse 2\\START.exe");
                    Console.WriteLine("Successfully Bypassed EAC!!!");
                    File.Copy(@"F:\TempDBXV2\DBXV2_FakeSTART_EAC.exe", "F:\\SteamLibrary\\steamapps\\common\\DB Xenoverse 2\\START.exe");
                    File.Delete("F:\\TempDBXV2\\DBXV2_FakeSTART_EAC.exe");
                    Directory.Delete("F:\\TempDBXV2");
                    Environment.Exit(1225);
                }
            }
        }
    }
}
