using Microsoft.Win32;
using Newtonsoft.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UTGAutoLoadUnload.Defines;
using System.IO;
using System.ComponentModel;

namespace ErrorTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string selectedImagePathOverview;
        private string selectedImagePathDetail;
        private Point startPointOverview;
        private Point startPointDetail;
        private Rectangle currentRectangleOverview;
        private Rectangle currentRectangleDetail;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(IdTextBox.Text, out int id))
            {
                var message = Enum.GetName(typeof(EWarning), id);
                MessageTextBlock.Text = message ?? "Invalid ID";
            }
        }

        private void SelectOverviewImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePathOverview = openFileDialog.FileName;
                OverviewImage.Source = new BitmapImage(new Uri(selectedImagePathOverview));
            }
        }

        private void SelectDetailImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePathDetail = openFileDialog.FileName;
                DetailImage.Source = new BitmapImage(new Uri(selectedImagePathDetail));
            }
        }

        private void OverviewCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPointOverview = e.GetPosition(OverviewCanvas);
            currentRectangleOverview = new Rectangle
            {
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };
            Canvas.SetLeft(currentRectangleOverview, startPointOverview.X);
            Canvas.SetTop(currentRectangleOverview, startPointOverview.Y);
            OverviewCanvas.Children.Add(currentRectangleOverview);
        }

        private void OverviewCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && currentRectangleOverview != null)
            {
                var pos = e.GetPosition(OverviewCanvas);
                var x = Math.Min(pos.X, startPointOverview.X);
                var y = Math.Min(pos.Y, startPointOverview.Y);
                var w = Math.Abs(pos.X - startPointOverview.X);
                var h = Math.Abs(pos.Y - startPointOverview.Y);

                currentRectangleOverview.Width = w;
                currentRectangleOverview.Height = h;

                Canvas.SetLeft(currentRectangleOverview, x);
                Canvas.SetTop(currentRectangleOverview, y);

                OverviewXTextBlock.Text = Math.Round(x).ToString();
                OverviewYTextBlock.Text = Math.Round(y).ToString();
                OverviewWidthTextBlock.Text = Math.Round(w).ToString();
                OverviewHeightTextBlock.Text = Math.Round(h).ToString();
            }
        }

        private void DetailCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPointDetail = e.GetPosition(DetailCanvas);
            currentRectangleDetail = new Rectangle
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };
            Canvas.SetLeft(currentRectangleDetail, startPointDetail.X);
            Canvas.SetTop(currentRectangleDetail, startPointDetail.Y);
            DetailCanvas.Children.Add(currentRectangleDetail);
        }

        private void DetailCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && currentRectangleDetail != null)
            {
                var pos = e.GetPosition(DetailCanvas);
                var x = Math.Min(pos.X, startPointDetail.X);
                var y = Math.Min(pos.Y, startPointDetail.Y);
                var w = Math.Abs(pos.X - startPointDetail.X);
                var h = Math.Abs(pos.Y - startPointDetail.Y);

                currentRectangleDetail.Width = w;
                currentRectangleDetail.Height = h;

                Canvas.SetLeft(currentRectangleDetail, x);
                Canvas.SetTop(currentRectangleDetail, y);

                DetailXTextBlock.Text = Math.Round(x).ToString();
                DetailYTextBlock.Text = Math.Round(y).ToString();
                DetailWidthTextBlock.Text = Math.Round(w).ToString();
                DetailHeightTextBlock.Text = Math.Round(h).ToString();
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> troubleshootingSteps = new List<string>();

            if (!string.IsNullOrWhiteSpace(Step1TextBox.Text))
            {
                troubleshootingSteps.Add(Step1TextBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(Step2TextBox.Text))
            {
                troubleshootingSteps.Add(Step2TextBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(Step3TextBox.Text))
            {
                troubleshootingSteps.Add(Step3TextBox.Text);
            }

            if (troubleshootingSteps.Count == 0)
            {
                MessageBox.Show("Địt mẹ Hiếu, nhập chữ vào");
                return;
            }

            var result = new
            {
                Id = int.Parse(IdTextBox.Text),
                Message = MessageTextBlock.Text,
                AlertOverviewSource = ConvertToPackUri(selectedImagePathOverview),
                AlertOverviewHighlightRectangle = new
                {
                    X = (int)Math.Round(double.Parse(OverviewXTextBlock.Text)),
                    Y = (int)Math.Round(double.Parse(OverviewYTextBlock.Text)),
                    Width = (int)Math.Round(double.Parse(OverviewWidthTextBlock.Text)),
                    Height = (int)Math.Round(double.Parse(OverviewHeightTextBlock.Text))
                },
                AlertDetailviewSource = ConvertToPackUri(selectedImagePathDetail),
                AlertDetailviewHighlightRectangle = new
                {
                    X = (int)Math.Round(double.Parse(DetailXTextBlock.Text)),
                    Y = (int)Math.Round(double.Parse(DetailYTextBlock.Text)),
                    Width = (int)Math.Round(double.Parse(DetailWidthTextBlock.Text)),
                    Height = (int)Math.Round(double.Parse(DetailHeightTextBlock.Text))
                },
                TroubleshootingSteps = troubleshootingSteps
            };
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                FloatFormatHandling = FloatFormatHandling.Symbol
            };

            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.AppendAllText(@"D:\output.csv", json + Environment.NewLine + ",");
        }

        private string ConvertToPackUri(string filePath)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            return $"/UTGAutoLoadUnload;component/Resources/Images/{fileName}";
        }

        private void ClearRectanglesButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = OverviewCanvas.Children.Count - 1; i >= 0; i--)
            {
                if (OverviewCanvas.Children[i] is Rectangle)
                {
                    OverviewCanvas.Children.RemoveAt(i);
                }
            }

            for (int i = DetailCanvas.Children.Count - 1; i >= 0; i--)
            {
                if (DetailCanvas.Children[i] is Rectangle)
                {
                    DetailCanvas.Children.RemoveAt(i);
                }
            }
        }
    }
}

