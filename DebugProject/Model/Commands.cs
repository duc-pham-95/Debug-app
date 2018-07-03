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
        public static Result ProcessRunJava(string[] FileInputContent)
        {
            Process process = new Process(); //khoi tao process
            Result result = new Result(); //khoi tao doi tuong de luu tru ket qua tu process
            ProcessStartInfo StartInfo = new ProcessStartInfo();//khoi tao info chay cho process
            StartInfo.FileName = "java.exe";
            StartInfo.Arguments = "-cp "+'"' + Directories.GetMainDir() +'"' +" "+"Main";
            StartInfo.UseShellExecute = false;
            StartInfo.CreateNoWindow = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            process.StartInfo = StartInfo;
            process.Start();//chay process
            /*doc input*/
            StreamWriter sw = process.StandardInput;
            foreach(string Input in FileInputContent)
            {
                sw.WriteLine(Input);
            }
            sw.Close();
            /*kiem tra thoi gian chay*/
            Boolean TimeLimit = process.WaitForExit(2000);
            if (TimeLimit == false)
            {
                process.Kill();
                result.Error = "Time Limit Exceeded";
                return result;          
            }
            /*luu ket qua*/
            StreamReader sr = process.StandardOutput;
            result.Output = sr.ReadToEnd();
            result.Error = process.StandardError.ReadToEnd();           
            return result;
        }
    }
}
