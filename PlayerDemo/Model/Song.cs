using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDemo
{
	[DataContract]
	public class Song : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _Title;
		[DataMember(Name="title", IsRequired=true)]
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

		private TimeSpan _Length;
		public TimeSpan Length
		{
			get { return _Length; }
			set
			{
				if (value != _Length)
				{
					_Length = value;
					OnPropertyChanged("Length");
				}
			}
		}

		[DataMember(Name = "length", IsRequired = true)]
		private string LengthString
		{
			get { return Length.ToString(); }
			set
			{
				TimeSpan length;
				if (TimeSpan.TryParse(value, out length))
					Length = length;
			}
		}

		private bool _Favorite;
		[DataMember(Name = "favorite", IsRequired = false)]
		public bool Favorite
		{
			get { return _Favorite; }
			set
			{
				if (value != _Favorite)
				{
					_Favorite = value;
					OnPropertyChanged("Favorite");
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
