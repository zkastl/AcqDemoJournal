using AcqDemoJournal.ViewModel;
using System.Windows.Controls;

namespace AcqDemoJournal.View
{
    /// <summary>
    /// Interaction logic for AddJournalEntryView.xaml
    /// </summary>
    public partial class AddJournalEntryView : UserControl
    {
        private AddJournalEntryViewModel ajevm;

        public AddJournalEntryView()
        {
            InitializeComponent();
            ajevm = new AddJournalEntryViewModel();
            DataContext = ajevm;
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            button1.Command = ajevm.AddEntryCommand;
        }
    }
}
