using FoodLog.Shared.ViewModels;
using FoodLog.WPF.Services;
using System.Windows.Controls;

namespace FoodLog.WPF.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();
            DataContext = new TableViewModel(new WpfFileService());
        }
    }
}
