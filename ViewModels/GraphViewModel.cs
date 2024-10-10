using Microcharts;
using SkiaSharp;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FoodLog.ViewModels
{
    public class GraphViewModel : INotifyPropertyChanged
    {
        // The Chart that the view will bind to
        private Chart _chart;
        public Chart Chart
        {
            get => _chart;
            set
            {
                _chart = value;
                OnPropertyChanged();
            }
        }

        // Constructor: Load initial chart data
        public GraphViewModel()
        {
            LoadChart();
        }

        // Method to load the chart data
        private void LoadChart()
        {
            var entries = new[] //TODO: replace example data with stuff from json
            {
                new ChartEntry(200)
                {
                    Label = "Apple", ValueLabel = "200", Color = SKColor.Parse("#266489")
                },
                new ChartEntry(400)
                {
                    Label = "Banana", ValueLabel = "400", Color = SKColor.Parse("#68B9C0")
                },
                new ChartEntry(100)
                {
                    Label = "Orange", ValueLabel = "100", Color = SKColor.Parse("#90D585")
                },
            };

            // Set the chart data
            Chart = new BarChart { Entries = entries };
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
