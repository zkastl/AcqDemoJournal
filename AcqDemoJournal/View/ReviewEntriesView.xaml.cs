using AcqDemoJournal.ViewModel;
using System.Windows.Controls;

namespace AcqDemoJournal.View
{
    /// <summary>
    /// Interaction logic for ReviewEntriesView.xaml
    /// </summary>
    public partial class ReviewEntriesView : UserControl
    {
        ReviewEntriesViewModel revm;

        public ReviewEntriesView()
        {
            revm = new ReviewEntriesViewModel();
            DataContext = revm;
            InitializeComponent();
        }

        private void ReviewEntriesView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            revm.LoadJournal(revm.loadedJournalName);
        }
    }
}
