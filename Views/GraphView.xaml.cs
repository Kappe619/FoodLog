using Microcharts;
using Microsoft.Maui.Controls;
using SkiaSharp;
using Microcharts.Maui;
using FoodLog.ViewModels;

namespace FoodLog.Views
{
    public partial class GraphView : ContentPage
    {
        public GraphView()
        {
            InitializeComponent();
            BindingContext = new GraphViewModel();
        }
    }
}
