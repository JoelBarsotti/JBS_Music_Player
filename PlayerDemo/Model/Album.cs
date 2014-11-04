using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDemo
{
	[DataContract]
	public class Album : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _Title;
		[DataMember(Name="title",IsRequired=true)]
		public string Title
		{
			get { return _Title; }
			set
			{
				if (value != _Title)
				{
					_Title = value;
					OnPropertyChanged("Title");
				}
			}
		}

		private string _Description;
		[DataMember(Name="description")]
		public string Description
		{
			get { return _Description; }
			set
			{
				if (value != _Description)
				{
					_Description = value;
					OnPropertyChanged("Description");
				}
			}
		}

		private string _ImageURL;
		[DataMember(Name="image")]
		public string ImageURL
		{
			get { return _ImageURL; }
			set
			{
				if (value != _ImageURL)
				{
					_ImageURL = value;
					OnPropertyChanged("ImageURL");
				}
			}
		}

		private DateTime _ReleaseDate;
		public DateTime ReleaseDate
		{
			get { return _ReleaseDate; }
			set
			{
				if (value != _ReleaseDate)
				{
					_ReleaseDate = value;
					OnPropertyChanged("ReleaseDate");
				}
			}
		}

		[DataMember(Name="date")]
		private string DateString
		{
			get { return ReleaseDate.ToString("O"); }
			set
			{
				DateTime newTime;
				if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out newTime))
					ReleaseDate = newTime;
			}
		}

		private ObservableCollection<Song> _Songs;
		[DataMember(Name="songs")]
		public ObservableCollection<Song> Songs
		{
			get { return _Songs; }
			set
			{
				if (value != _Songs)
				{
					_Songs = value;
					OnPropertyChanged("Songs");
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
