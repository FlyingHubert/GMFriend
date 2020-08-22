using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GMFriend.UserInterface.Tabs.Notes
{
    /// <summary>
    /// Interaktionslogik für MarkdownView.xaml
    /// </summary>
    public partial class MarkdownView : UserControl
    {
        // Using a DependencyProperty as the backing store for MarkdownString. This enables
        // animation, styling, binding, etc...
        public static readonly DependencyProperty MarkdownStringProperty =
            DependencyProperty.Register("MarkdownString", typeof(string), typeof(MarkdownView), new FrameworkPropertyMetadata(OnPropertyChanged));

        public MarkdownView()
        {
            InitializeComponent();
        }

        public string MarkdownString
        {
            get { return (string)GetValue(MarkdownStringProperty); }
            set { SetValue(MarkdownStringProperty, value); }
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MarkdownView).DoBrowse(e.NewValue as string);
        }

        private void DoBrowse(string html)
        {
            Browser.NavigateToString(html ?? "");
        }
    }
}