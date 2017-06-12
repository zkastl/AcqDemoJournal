using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Utilities;

namespace AcqDemoJournal.ViewModel
{
    public class ReviewEntriesViewModel : ProtoBind
    {
        public ObservableCollection<AcqDemoJournalEntry> JournalEntries
        {
            get { return ObservableGet<ObservableCollection<AcqDemoJournalEntry>>(); }
            set { ObservableSet(value); }
        }

        public string loadedJournalName;
        private AssessmentPeriod asp;

        public ReviewEntriesViewModel()
        {
            loadedJournalName = @".\serializedJournal.jrl";
            asp = SerializationUtilities.DeserializeContract<AssessmentPeriod>(loadedJournalName);
            LoadJournal(loadedJournalName);
        }

        public void LoadJournal(string journal)
        {
            try
            {
                JournalEntries = new ObservableCollection<AcqDemoJournalEntry>(
                SerializationUtilities.DeserializeContract<AssessmentPeriod>(journal)?.PeriodEntries ??
                new System.Collections.Generic.List<AcqDemoJournalEntry>());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
