using System;

namespace designBIB
{
    public class Logs
    {
        public static string UserNameWhoFuckedItUp { get; private set; }
        public void Logger(string lines)
        {
            UserNameWhoFuckedItUp = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // Write the string to a file.append mode is enabled so that the log
            // lines get appended to  test.txt than wiping content and writing the log

            var file = new System.IO.StreamWriter("log.txt", true);
            file.WriteLine("Done by: "+UserNameWhoFuckedItUp +"{0}"+lines , Environment.NewLine);

            file.Close();

        }
    }
}