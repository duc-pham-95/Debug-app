using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DebugProject.Model
{
    class Directories
    {
        
        private static readonly string Root = Directory.GetCurrentDirectory();
        private static readonly string BaseDir = @"\BASE";
        private static readonly string MainDir = @"\MAIN";
        private static readonly string OutputDir = @"\OUT";
        public static string CustomOutputDir { get; set; }
        public static string InputDir { get; set; }
        public static string TestOutputDir { get; set; }

         

        //create directory
        public static void CreateMainDir()
        {
            Directory.CreateDirectory(Root + BaseDir + MainDir);
                
        }
        public static void CreateOutDir()
        {
            Directory.CreateDirectory(Root + BaseDir + OutputDir);
        }
        public static void CreateAll()
        {
            CreateMainDir();
            CreateOutDir();
        }
        //delete directory
        public static void DeleteMainDir()
        {
            Directory.Delete(Root + BaseDir + MainDir, true);
        }
        public static void DeleteOutDir()
        {
            Directory.Delete(Root + BaseDir + OutputDir, true);
        }
        public static void DeleteAll()
        {
            DeleteMainDir();
            DeleteOutDir();
        }
        //clear directory
        public static void ClearMainDir()
        {
            DirectoryInfo dir = new DirectoryInfo(GetMainDir());
            for(int i = 0; i < dir.GetFiles().Length; i++)
            {
                FileInfo file = (FileInfo)dir.GetFiles().GetValue(i);
                file.Delete();
            }
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
        }
        public static void ClearOutDir()
        {
            
            DirectoryInfo dir = new DirectoryInfo(GetOutDir());
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }    
        }
        public static void ClearCustomDir()
        {
            if(CustomOutputDir != null)
            {
                DirectoryInfo dir = new DirectoryInfo(CustomOutputDir);
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }
            }
        }
        public static void ClearAll()
        {
            ClearMainDir();
            ClearOutDir();
            ClearCustomDir();
        }
        //get directory
        public static string GetMainDir()
        {
            return Root + BaseDir + MainDir;
        }
        public static string GetOutDir()
        {
            if(CustomOutputDir == null)
                return Root + BaseDir + OutputDir;
            return CustomOutputDir;
        }
        //check directory
        public static Boolean isDirEmpty(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(@path);
            if(dir.GetFiles().Length > 0)
            {
                return false;
            }
            return true;
        }
    }
}
