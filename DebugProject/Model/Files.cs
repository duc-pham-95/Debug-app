﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugProject.Model
{
    class Files
    {   //general  
        public static readonly string PathFormat = @"\";
        public static readonly string TextFileType = ".txt";
        //java
        public static readonly string JavaFileName = "Main";
        public static readonly string JavaFileType = ".java";        
        //c#
        public static readonly string CSharpFileName = "Main";
        public static readonly string CSharpFileType = ".java";


        public Files()
        {

        }
        //java
        public static string GetJavaFilePath()
        {
            return Directories.GetMainDir() + PathFormat + JavaFileName + JavaFileType;
        }
        //c#

        //general
        public static void CreateFile(string path)
        {
            File.Create(path);
        }
        public static void DeleteFile(string Path)
        {
            File.Delete(Path);
        }
        public static void WriteTextToFile(string Path, string[] Text)
        {
            File.WriteAllLines(Path, Text);
        }
        public static string[] GetFileContent(string Path)
        {

            return File.ReadAllLines(Path);
        }       
        public static string[] GetInputFilePaths(string Path)
        {

            DirectoryInfo Dir = new DirectoryInfo(Path);
            string[] FilePaths = new string[Dir.GetFiles().Length];
            int i = 0;
            foreach (FileInfo File in Dir.GetFiles())
            {
                string Name = Path + @"\" + File.Name;
                FilePaths[i++] = Name;
            }
            return FilePaths;
        }
        public static string[] GetOutputFilePaths(string Path)
        {

            DirectoryInfo Dir = new DirectoryInfo(Path);
            string[] FilePaths = new string[Dir.GetFiles().Length];
            int i = 0;
            foreach (FileInfo File in Dir.GetFiles())
            {
                int Index = File.Name.LastIndexOf('.');
                string Temp = File.Name.Substring(0, Index);
                string Name = Directories.GetOutDir() + @"\" + Temp + ".out";
                FilePaths[i++] = Name;
            }
            return FilePaths;
        }
        public static Boolean IsFileExist(string Path)
        {
            if (File.Exists(Path))
            {
                return true;
            }
            return false;
        }
        public static Boolean IsFileEmpty(string Path)
        {
            if(new FileInfo(Path).Length > 0)
            {
                return false;
            }
            return true;
        }
        
    }
}