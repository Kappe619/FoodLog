using System.Collections.ObjectModel;
using FoodLog.ViewModels;

namespace FoodLog.Views
{
    public partial class TableView : ContentView
    {
        // Constructor
        public TableView()
        {
            InitializeComponent();

            // Set BindingContext to ViewModel (best practice)
            BindingContext = new TableViewModel();

            // If you want, you can directly interact with the ViewModel in code-behind as well
            // (This step is optional, better to handle such logic inside ViewModel)
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
        }
    }
}
