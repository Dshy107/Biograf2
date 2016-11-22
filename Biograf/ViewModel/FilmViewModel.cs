using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Biograf.ViewModel
{
    public class FilmViewModel : INotifyPropertyChanged //side 660-661
    {
        public Model.FilmList Filmliste { get; set; }
        private Model.FilmNavn selectedFilm;
        //public RelayCommand AddFilmCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Model.FilmNavn SelectedFilm
        {
            get { return selectedFilm; }
            set {
                selectedFilm = value;
                OnPropertyChanged(nameof(SelectedFilm));
                }
        }


        public Model.FilmNavn NewFilm { get; set; }


        public FilmViewModel()
        {
            Filmliste = new Model.FilmList();
            selectedFilm = new Model.FilmNavn();
            AddFilmCommand = new AddFilmCommand(AddNewFilm);
            NewFilm = new Model.FilmNavn();
            //AddFilmCommand = new RelayCommand(AddNewFilm, null);
        }

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        public AddFilmCommand AddFilmCommand { get; set; }


        public void AddNewFilm()
        {
            Filmliste.Add(NewFilm);
        }
    }
}
