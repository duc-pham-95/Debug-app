using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugProject.Model
{
    class Messages
    {
        public static readonly string CompileError = "Compile Error! Please make sure that the syntax is correct";
        public static readonly string JdkError = "Missing JDK error! Please make sure that you've installed JDK";
        public static readonly string RunTimeError = "Runtime Error! Exception occurs while running";
        public static readonly string TimeLimitError = "Time Limit Exceed";

        public static string GetErrorType(string error)
        {
            if(error[0] == 'C' && error[1] == ':')
            {
                return CompileError;
            }
            else if(error[0] == 'E')
            {
                return RunTimeError;
            }
            else if(error[0] == 'T')
            {
                return TimeLimitError;
            }
            return JdkError;
        }
    }
}
