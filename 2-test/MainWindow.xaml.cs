using System.Windows;

namespace _2_test
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string Password = "0987654";

        private void OnNumberButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button && InputField != null)
            {
                InputField.Text += button.Content.ToString();
            }
        }

        private void OnClearButtonClick(object sender, RoutedEventArgs e)
        {
            InputField.Text = string.Empty;
        }

        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            if (InputField.Text == Password)
            {
                MessageBox.Show("Correct password!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Incorrect password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            InputField.Text = string.Empty;
        }
    }
}