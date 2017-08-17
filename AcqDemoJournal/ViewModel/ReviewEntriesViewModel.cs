using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using Utilities;

namespace AcqDemoJournal.ViewModel
{
    public class ReviewEntriesViewModel : ProtoBind
    {
        public ObservableCollection<AcqDemoJournalEntry> JournalEntries
        {
            get => ObservableGet<ObservableCollection<AcqDemoJournalEntry>>();
            set => ObservableSet(value);
        }

        public ReviewEntriesViewModel()
        {
        }

        public void LoadJournal()
        {
            // Create the journal file if it doesn't exist
            Directory.CreateDirectory(Constants.JournalDirectory);

            // Deserialize and read in the journal file.
            try
            {
                JournalEntries = new ObservableCollection<AcqDemoJournalEntry>(
                SerializationUtilities.DeserializeContract<AssessmentPeriod>(Constants.JournalDirectory + Constants.JournalFileName)?.PeriodEntries ??
                new System.Collections.Generic.List<AcqDemoJournalEntry>());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
