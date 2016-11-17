using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Biograf.ViewModel
{
    public class FilmViewModel : INotifyPropertyChanged
    {
        public Model.FilmList Filmliste { get; set; }
        private Model.FilmNavn selectedFilm;

        public event PropertyChangedEventHandler PropertyChanged;

        public Model.FilmNavn SelectedFilm
        {
            get { return selectedFilm; }
            set { selectedFilm = value; }
        }


        public FilmViewModel()
        {
            Filmliste = new Model.FilmList();
            selectedFilm = new Model.FilmNavn();
        }
    }
}
