using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcqDemoJournal
{
    public static class Constants
    {
        public static string JournalDirectory = 
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create) + @"\AcqDemoJournal\";
        public static string JournalFileName = @"journal.jrl";
    }
}
