using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Windows;

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

        private LineSeries GetNewLineSeries(int maxSteps, int maxValue)
        {
            var random = new Random();
            double number = random.Next(0, maxValue);

            var line = new LineSeries
            {
                Title = $"Start number: {number}",
                Values = GetNewValues(number, maxSteps)
            };

            return line;
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClearCB.IsChecked.Value)
            {
                SeriesCollection.Clear();
            }

            SeriesCollection.Add(GetNewLineSeries(150, 1000));
        }
    }
}
