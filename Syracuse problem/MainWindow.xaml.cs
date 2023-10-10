using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Windows;
using System.Threading.Tasks;

namespace Syracuse_problem
{
    public partial class MainWindow : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection();

            DataContext = this;
        }

        private ChartValues<double> GetNewValues(double number, int maxSteps)
        {
            var values = new ChartValues<double>();

            for (int i = 0; i < maxSteps; i++)
            {
                //3x + 1 problem
                number = number % 2 != 0 ? number * 3 + 1 : number / 2;

                values.Add(number);
            }

            return values;
        }

        private LineSeries GetNewLineSeries(int maxSteps, int minValue, int maxValue)
        {
            var random = new Random();
            double number = random.Next(minValue, maxValue);

            var line = new LineSeries
            {
                Title = $"Start number: {number}",
                Values = GetNewValues(number, maxSteps)
            };

            return line;
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            Generate();
        }

        public void Generate()
        {
            GC.Collect();

            if (ClearCB.IsChecked.Value)
            {
                SeriesCollection.Clear();
            }

            int minValue = int.Parse(minTextBox.Text);
            int maxValue = int.Parse(maxTextBox.Text);
            int steps = int.Parse(stepCountTextBox.Text);

            SeriesCollection.Add(GetNewLineSeries(steps, minValue, maxValue));
        }
    }
}
