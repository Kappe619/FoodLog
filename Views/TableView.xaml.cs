using System.Collections.ObjectModel;
using FoodLog.ViewModels;

namespace FoodLog.Views
{
    public partial class TableView : ContentView
    {
        // ObservableCollection, um die Daten zu binden
        public ObservableCollection<string> Items { get; set; }

        public TableView()
        {
            InitializeComponent();

            BindingContext = new TableViewModel();

            // Beispiel-Daten
            Items = new ObservableCollection<string>
            {
                "Eintrag 1", "Eintrag 2", "Eintrag 3"
            };

            // Daten an die ListView binden
            DataList.ItemsSource = Items;
        }
    }
}
