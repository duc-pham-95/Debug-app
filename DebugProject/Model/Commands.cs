using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace DebugProject.Model
{
    class Commands
    {
        private static readonly string Carries = @"/C ";
        private static readonly string CompileJava = "javac ";
        public static int Time = 2000;
        public static string ProcessCompileJava()
        {
            Process process = new Process();//khoi tao process
            ProcessStartInfo startInfo = new ProcessStartInfo();//khoi tao info chay cho process
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = Carries + CompileJava + '"' + Files.GetJavaFilePath() + '"';
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();//chay process
            /*luu ket qua*/
            string error = "";
            error = process.StandardError.ReadToEnd();
            return error;
        }
        public static Result ProcessRunJava(string FileInputContent)
        {
            Process process = new Process(); //khoi tao process
            Result result = new Result(); //khoi tao doi tuong de luu tru ket qua tu process
            ProcessStartInfo StartInfo = new ProcessStartInfo();//khoi tao info chay cho process
            StartInfo.FileName = "javaw.exe";
            StartInfo.Arguments = "-cp "+'"' + Directories.GetMainDir() +'"' +" "+"Main";
            StartInfo.UseShellExecute = false;
            StartInfo.RedirectStandardError = true;
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            process.StartInfo = StartInfo;
            process.Start();//chay process
            /*doc input*/
            StreamWriter sw = process.StandardInput;
            StreamReader sr = process.StandardOutput;
            sw.WriteLine(FileInputContent);
            sw.Close();
            /*kiem tra thoi gian chay*/
            Boolean TimeLimit = process.WaitForExit(Time);
            if (TimeLimit == false)
            {
                process.Kill();
                result.Error = "Time Limit Exceeded";
                return result;          
            }
            /*luu ket qua*/
            result.Output = sr.ReadToEndAsync().ToString();
            sr.Close();
            result.Error = process.StandardError.ReadToEnd();           
            return result;
        }
        public static void OpenFolder(string path)
        {
            Process process = new Process(); //khoi tao process
            Result result = new Result(); //khoi tao doi tuong de luu tru ket qua tu process
            ProcessStartInfo StartInfo = new ProcessStartInfo();//khoi tao info chay cho process
            StartInfo.FileName = "explorer.exe";
            StartInfo.Arguments = path;
            process.StartInfo = StartInfo;
            process.Start();//chay process
        }
        public static void OpenFile(string path)
        {
            Process process = new Process(); //khoi tao process
            Result result = new Result(); //khoi tao doi tuong de luu tru ket qua tu process
            ProcessStartInfo StartInfo = new ProcessStartInfo();//khoi tao info chay cho process
            StartInfo.FileName = path;
            process.StartInfo = StartInfo;
            process.Start();//chay process
        }
    }
}
