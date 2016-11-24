using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using Biograf.Model;
using Windows.Storage;

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

        StorageFolder localfolder = null;

        private readonly string filNavn = "JsonText.json";

        public FilmViewModel()
        {
            Filmliste = new Model.FilmList();
            selectedFilm = new Model.FilmNavn();
            AddFilmCommand = new AddFilmCommand(AddNewFilm);
            SaveFilmCommand = new SaveFilmCommand(GemDataTilDiskAsync);
            RemoveFilmCommand = new RemoveFilmCommand(RemoveFilm);
            HentFilmCommand = new HentFilmCommand(HentDataFraDiskAsync);
            NewFilm = new Model.FilmNavn();
            //AddFilmCommand = new RelayCommand(AddNewFilm, null);
            localfolder = ApplicationData.Current.LocalFolder;
        }
        public AddFilmCommand AddFilmCommand { get; set; }
        public RemoveFilmCommand RemoveFilmCommand { get; set; }
        public SaveFilmCommand SaveFilmCommand { get; set; }
        public HentFilmCommand HentFilmCommand { get; set; }

        public async void HentDataFraDiskAsync()
        {
            this.Filmliste.Clear();

            StorageFile file = await localfolder.GetFileAsync(filNavn);
            string jsonText = await FileIO.ReadTextAsync(file);

            Filmliste.IndsetJson(jsonText);

        }
        /// <summary>
        /// Gemmer json data fra liste i localfolder
        /// </summary>
        public async void GemDataTilDiskAsync()
        {

            string jsonText = this.Filmliste.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filNavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);

        }

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


        public string GetFilmlisteJson()
        {
            string jsonText = JsonConvert.SerializeObject(Filmliste);
            return jsonText;
               
        }


        public void AddNewFilm()
        {
            Filmliste.Add(NewFilm);
        }
        public void RemoveFilm()
        {
            Filmliste.Remove(NewFilm);
        }
     
    }
}
