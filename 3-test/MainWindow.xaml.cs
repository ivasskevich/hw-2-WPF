using System.Windows;

namespace _3_test
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double[,] matrix = new double[3, 3]
                {
            { ParseCell(Cell00.Text), ParseCell(Cell01.Text), ParseCell(Cell02.Text) },
            { ParseCell(Cell10.Text), ParseCell(Cell11.Text), ParseCell(Cell12.Text) },
            { ParseCell(Cell20.Text), ParseCell(Cell21.Text), ParseCell(Cell22.Text) }
                };

                double determinant = CalculateDeterminant(matrix);
                ResultBox.Text = $"{determinant:F1}";
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Input error: Ensure all fields are filled with valid numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double ParseCell(string cellValue)
        {
            if (double.TryParse(cellValue, out double result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Invalid number format");
            }
        }

        private double CalculateDeterminant(double[,] matrix)
        {
            return matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                 - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                 + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
        }

    }
}