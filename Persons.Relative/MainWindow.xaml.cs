using System.Collections.ObjectModel;
using System.Windows;
using Dapper;
using Npgsql;

namespace Persons.Relative;

public partial class MainWindow : Window
{
    public ObservableCollection<Person> Persons { get; set; }
    
    public MainWindow()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        var db = new NpgsqlConnection(
            "Server=127.0.0.1;Port=5432;Database=json_db;User Id=postgres;Password=1234;");
        db.Open();
        var sql = """
                  SELECT last_name, first_name, date_of_birth
                  FROM relative.view_persons;
                  """;
        var persons = db.Query<Person>(sql);
        
        Persons = new ObservableCollection<Person>(persons);
        
        InitializeComponent();
    }
}