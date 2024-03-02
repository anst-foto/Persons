using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Persons.RelativeEF;

public partial class MainWindow : Window
{
    public ObservableCollection<Person> Persons { get; set; }
    
    public MainWindow()
    {
        var db = new JsonDbContext();
        var persons = db.TablePersons
            .Include(tablePerson => tablePerson.LastNameNavigation)
            .Include(tablePerson => tablePerson.FirstNameNavigation)
            .Include(tablePerson => tablePerson.DateOfBirthNavigation)
            .Select(p => new Person
            {
                LastName = p.LastNameNavigation.Name,
                FirstName = p.FirstNameNavigation.Name,
                DateOfBirth = p.DateOfBirthNavigation.DateOfBirth.ToDateTime(TimeOnly.MinValue)
            });
        Persons = new ObservableCollection<Person>(persons);
        
        InitializeComponent();
    }
}