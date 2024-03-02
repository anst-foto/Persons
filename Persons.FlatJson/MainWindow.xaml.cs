using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using Dapper;
using Npgsql;

namespace Persons.FlatJson;

public partial class MainWindow : Window
{
    public ObservableCollection<PersonInfo> Persons { get; set; }
    
    public MainWindow()
    {
        var db = new NpgsqlConnection(
            "Server=127.0.0.1;Port=5432;Database=json_db;User Id=postgres;Password=1234;");
        db.Open();
        var sql = """
                  SELECT * 
                  FROM flat.table_persons;
                  """;
        var result = db.Query<Person>(sql);
        var persons = result.Select(p => JsonSerializer.Deserialize<PersonInfo>(p.Info));
        
        Persons = new ObservableCollection<PersonInfo>(persons);
        
        InitializeComponent();
    }
}