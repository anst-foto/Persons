using System.Collections.ObjectModel;
using System.Windows;
using Dapper;
using Npgsql;

namespace Persons.Flat;

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
                  SELECT info->> 'last_name' AS last_name,
                         info->> 'first_name' AS first_name,
                         info->> 'date_of_birth' AS date_of_birth
                  FROM flat.table_persons;
                  """;
        var persons = db.Query<Person>(sql);
        Persons = new ObservableCollection<Person>(persons);
        
        InitializeComponent();
    }
}