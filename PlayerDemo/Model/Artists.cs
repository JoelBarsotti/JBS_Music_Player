using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDemo
{
	[DataContract]
	public class Artists : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _Name;
		[DataMember(Name="name",IsRequired=true)]
		public string Name
		{
			get { return _Name; }
			set
			{
				if (value != _Name)
				{
					_Name = value;
					OnPropertyChanged("Name");
				}
			}
		}

		private ObservableCollection<Album> _Albums;
		[DataMember(Name = "albums", IsRequired = true)]
		public ObservableCollection<Album> Albums
		{
			get { return _Albums; }
			set
			{
				if (value != _Albums)
				{
					_Albums = value;
					OnPropertyChanged("Albums");
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
