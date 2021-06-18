using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace NavigationApp.GUI.Views
{
    /// <summary>
    /// Interaction logic for SelectIntegerView.xaml
    /// </summary>
    public partial class SelectIntegerView : UserControl
    {
        public SelectIntegerView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Input validation for the textbox
        /// </summary>
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
