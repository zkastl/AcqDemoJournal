using System.Windows;
using System.Windows.Controls;

namespace AcqDemoJournal.Controls
{
    /// <summary>
    /// Interaction logic for ContributionFactorControl.xaml
    /// </summary>
    public partial class ContributionFactorControl : UserControl
    {
        public string FactorLabelText
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public bool BoxChecked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("FactorLabelText", typeof(string), 
                typeof(ContributionFactorControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty CheckedProperty =
            DependencyProperty.Register("BoxChecked", typeof(bool),
                typeof(ContributionFactorControl), new PropertyMetadata(default(bool)));

        public ContributionFactorControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
    }
}
