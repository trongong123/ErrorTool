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

namespace ErrorTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _startPoint;
        private Rectangle _currentRectangleOverview;
        private Rectangle _currentRectangleDetail;
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

        private void LoadOverviewImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                OverviewImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                OverviewImage.Width = 590;
                OverviewImage.Height = 355;
            }
        }

        private void LoadDetailImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DetailImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                DetailImage.Width = 295;
                DetailImage.Height = 358;
            }
        }

        private void OverviewImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(OverviewCanvas);
            _currentRectangleOverview = new Rectangle
            {
                Stroke = Brushes.Red,
                StrokeThickness = 3
            };
            Canvas.SetLeft(_currentRectangleOverview, _startPoint.X);
            Canvas.SetTop(_currentRectangleOverview, _startPoint.Y);
            OverviewCanvas.Children.Add(_currentRectangleOverview);
        }

        private void OverviewImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var pos = e.GetPosition(OverviewCanvas);
                var x = Math.Min(pos.X, _startPoint.X);
                var y = Math.Min(pos.Y, _startPoint.Y);
                var w = Math.Max(pos.X, _startPoint.X) - x;
                var h = Math.Max(pos.Y, _startPoint.Y) - y;

                _currentRectangleOverview.Width = w;
                _currentRectangleOverview.Height = h;

                OverviewXTextBlock.Text = x.ToString();
                OverviewYTextBlock.Text = y.ToString();
                OverviewWidthTextBlock.Text = w.ToString();
                OverviewHeightTextBlock.Text = h.ToString();
            }
        }

        private void OverviewImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Kết thúc vẽ hình chữ nhật overview
        }

        private void DetailImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(DetailCanvas);
            _currentRectangleDetail = new Rectangle
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 3
            };
            Canvas.SetLeft(_currentRectangleDetail, _startPoint.X);
            Canvas.SetTop(_currentRectangleDetail, _startPoint.Y);
            DetailCanvas.Children.Add(_currentRectangleDetail);
        }

        private void DetailImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var pos = e.GetPosition(DetailCanvas);
                var x = Math.Min(pos.X, _startPoint.X);
                var y = Math.Min(pos.Y, _startPoint.Y);
                var w = Math.Max(pos.X, _startPoint.X) - x;
                var h = Math.Max(pos.Y, _startPoint.Y) - y;

                _currentRectangleDetail.Width = w;
                _currentRectangleDetail.Height = h;

                DetailXTextBlock.Text = x.ToString();
                DetailYTextBlock.Text = y.ToString();
                DetailWidthTextBlock.Text = w.ToString();
                DetailHeightTextBlock.Text = h.ToString();
            }
        }

        private void DetailImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Kết thúc vẽ hình chữ nhật detail
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            var result = new
            {
                Id = int.Parse(IdTextBox.Text),
                Message = MessageTextBlock.Text,
                AlertOverviewSource = ((BitmapImage)OverviewImage.Source).UriSource.ToString(),
                AlertOverviewHighlightRectangle = new
                {
                    X = double.Parse(OverviewXTextBlock.Text),
                    Y = double.Parse(OverviewYTextBlock.Text),
                    Width = double.Parse(OverviewWidthTextBlock.Text),
                    Height = double.Parse(OverviewHeightTextBlock.Text)
                },
                AlertDetailviewSource = ((BitmapImage)DetailImage.Source).UriSource.ToString(),
                AlertDetailviewHighlightRectangle = new
                {
                    X = double.Parse(DetailXTextBlock.Text),
                    Y = double.Parse(DetailYTextBlock.Text),
                    Width = double.Parse(DetailWidthTextBlock.Text),
                    Height = double.Parse(DetailHeightTextBlock.Text)
                },
                TroubleshootingSteps = new List<string>
                {
                    Step1TextBox.Text,
                    Step2TextBox.Text,
                    Step3TextBox.Text
                }
            };

            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.AppendAllText(@"D:\output.txt", json + Environment.NewLine);
        }
    }
}