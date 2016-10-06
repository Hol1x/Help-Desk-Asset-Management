using System.IO;

namespace designBIB
{
    internal class Utills
    {
        public static bool FileCheck(string fileToCheck)
        {
            return File.Exists(fileToCheck);
        }
    }
}