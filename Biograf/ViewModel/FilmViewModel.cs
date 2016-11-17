using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biograf.ViewModel
{
    public class FilmViewModel 
    {
        public Model.FilmList Filmliste { get; set; }
        private Model.FilmNavn selectedFilm;

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
