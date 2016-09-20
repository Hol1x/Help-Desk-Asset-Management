using System.IO;

namespace designBIB
{
    class Utills
    {
        public static bool FileCheck(string fileToCheck) {
            return File.Exists(fileToCheck);
        }
    }
}
