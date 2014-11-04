using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayerDemo.ViewModels
{
	public class PlayerWindowViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public PlayerWindowViewModel()
		{
			LoadLibrary();
		}

		private async void LoadLibrary()
		{
			MusicLibrary = await LibraryLoader.LoadLibraryFromWeb(@"https://gist.githubusercontent.com/edj-boston/77b2cdc0cad5b5d42219/raw/8b1459985230dc46eab1e3d41d94cf31d4c70440/music.json");
		}

		private Library _MusicLibrary;
		public Library MusicLibrary
		{
			get { return _MusicLibrary; }
			set
			{
				if (value != _MusicLibrary)
				{
					_MusicLibrary = value;
					if (MusicLibrary != null && MusicLibrary.Artists != null && MusicLibrary.Artists.Count > 0)
						SelectedArtist = MusicLibrary.Artists[0];
					OnPropertyChanged("MusicLibrary");
				}
			}
		}


		private Artists _SelectedArtist;
		public Artists SelectedArtist
		{
			get { return _SelectedArtist; }
			set
			{
				if (value != _SelectedArtist)
				{
					_SelectedArtist = value;
					if (SelectedArtist != null && SelectedArtist.Albums != null && SelectedArtist.Albums.Count > 0)
						SelectedAlbum = SelectedArtist.Albums[0];
					else
						SelectedAlbum = null;
					OnPropertyChanged("SelectedArtist");
				}
			}
		}

		private Album _SelectedAlbum;
		public Album SelectedAlbum
		{
			get { return _SelectedAlbum; }
			set
			{
				if (value != _SelectedAlbum)
				{
					_SelectedAlbum = value;
					OnPropertyChanged("SelectedAlbum");
				}
			}
		}



		protected void OnPropertyChanged(string propertyName)
		{
			var tempEvent = PropertyChanged;
			if (tempEvent != null)
				tempEvent(this, new PropertyChangedEventArgs(propertyName));
		}
    
	}
}
