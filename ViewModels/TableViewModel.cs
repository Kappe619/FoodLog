using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FoodLog.ViewModels
{
    // TableViewModel wird als ViewModel verwendet
    public class TableViewModel : INotifyPropertyChanged
    {
        // Beispiel-Datenquelle für die Tabelle
        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        // Konstruktor, um Beispiel-Daten zu initialisieren
        public TableViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "Eintrag 1", "Eintrag 2", "Eintrag 3"
            };
        }

        // Event, um die View über Änderungen zu informieren
        public event PropertyChangedEventHandler PropertyChanged;

        // Methode, um das PropertyChanged-Event auszulösen
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
