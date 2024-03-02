using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;

namespace Persons.FlatEF;

public partial class MainWindow : Window
{
    public ObservableCollection<Person> Persons { get; set; }
    
    public MainWindow()
    {
        var db = new JsonDbContext();
        var persons = db.TablePersons
            .ToList()
            .Select(p => JsonSerializer.Deserialize<Person>(p.Info));
        Persons = new ObservableCollection<Person>(persons);
        
        InitializeComponent();
    }
}