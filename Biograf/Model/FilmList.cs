using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Biograf.Model
{
    public class FilmList : ObservableCollection<FilmNavn>
    {
        public FilmList() : base()
        {
            
            this.Add(new FilmNavn() { filmNavn = "Poul", pris = 20.9, releaseDato = new DateTime(2016,12, 24), description = "Poul er mand", sal = "Sal 99", rating = 10 });
            this.Add(new FilmNavn() { filmNavn = "There is noway my little sister can be this cute", pris = 20.5, releaseDato = new DateTime(2017, 10, 20), description = "Oh my god why", sal = "Sal 10", rating = 10 });

        }
    }
}
