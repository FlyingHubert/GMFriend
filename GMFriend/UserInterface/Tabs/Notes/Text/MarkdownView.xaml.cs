using System.Windows;
using System.Windows.Controls;

namespace GMFriend.UserInterface.Tabs.Notes.Text
{
    /// <summary>
    /// Interaktionslogik für MarkdownView.xaml
    /// </summary>
    public partial class MarkdownView : UserControl
    {
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