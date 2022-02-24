using ListasXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListasXamarin
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { get; set; }

        public Command ReloadStudentsCommand { get; set; }

        private bool busy;
        public bool Busy
        {
            get 
            { 
                return busy; 
            }
            set 
            { 
                busy = value;
                NotifyPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();

            ReloadStudentsCommand = new Command(()=> {
                Busy = true;

                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });
                Students.Add(new Student { FirstName = "nuevo", Lastname = "Nuevo", Email = "nuevo@cecar" });

                Busy = false;
            });

            Students = new ObservableCollection<Student>
            {
                new Student {FirstName = "Andres", Lastname= "Bertel", Email = "andres.bertel@cecar.com" },
                new Student {FirstName = "Maria", Lastname= "Perez", Email = "maria@cecdar" },
                new Student {FirstName = "Pepe", Lastname= "Ruiz", Email = "pepe" },
                new Student {FirstName = "Lina", Lastname= "Gonzalez", Email = "lina@cecar" },
                new Student {FirstName = "Andres", Lastname= "Bertel", Email = "andres.bertel@cecar.com" },
                new Student {FirstName = "Maria", Lastname= "Perez", Email = "maria@cecdar" },
                new Student {FirstName = "Pepe", Lastname= "Ruiz", Email = "pepe" },
                new Student {FirstName = "Lina", Lastname= "Gonzalez", Email = "lina@cecar" },
                new Student {FirstName = "Andres", Lastname= "Bertel", Email = "andres.bertel@cecar.com" },
                new Student {FirstName = "Maria", Lastname= "Perez", Email = "maria@cecdar" },
                new Student {FirstName = "Pepe", Lastname= "Ruiz", Email = "pepe" },
                new Student {FirstName = "Lina", Lastname= "Gonzalez", Email = "lina@cecar" }
            };

            this.BindingContext = this;
        }


        /* public class ObservableProperty : INotifyPropertyChanged
         {
             public event PropertyChangedEventHandler PropertyChanged;
             protected void OnPropertyChanged(string propertyName)
             {
                 var handler = PropertyChanged;
                 if (handler != null)
                     handler(this, new PropertyChangedEventArgs(propertyName));
             }
         }*/

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void ReloadStudents()
        {
           
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student student = (Student)e.CurrentSelection.FirstOrDefault();
            DisplayAlert("Selección", student.FirstName, "Cerra");
        }
    }
}
