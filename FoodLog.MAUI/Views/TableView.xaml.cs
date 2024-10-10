using FoodLog.MAUI.Services;
using FoodLog.Shared.ViewModels;

namespace FoodLog.MAUI.Views;

public partial class TableView : ContentView
{
	public TableView()
	{
		InitializeComponent();
		BindingContext = new TableViewModel(new MauiFileService());
	}
}