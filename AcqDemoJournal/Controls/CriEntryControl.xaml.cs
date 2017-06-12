using System.Windows;
using System.Windows.Controls;

namespace AcqDemoJournal.Controls
{
    /// <summary>
    /// Interaction logic for CriEntryControl.xaml
    /// </summary>
    public partial class CriEntryControl : UserControl
    {
        public string CriLabelText
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string CriContentText
        {
            get { return (string)GetValue(CriContentProperty); }
            set { SetValue(CriContentProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("CriLabelText", typeof(string),
                typeof(CriEntryControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty CriContentProperty =
            DependencyProperty.Register("CriContentText", typeof(string),
                typeof(CriEntryControl), new PropertyMetadata(string.Empty));

        public CriEntryControl()
        {
            InitializeComponent();
            CriEntryRoot.DataContext = this;
        }
    }
}
