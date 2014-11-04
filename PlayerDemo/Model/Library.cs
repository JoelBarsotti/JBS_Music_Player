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
	public class Library : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		private ObservableCollection<Artists> _Artists;
		[DataMember(Name="artists",IsRequired=true)]
		public ObservableCollection<Artists> Artists
		{
			get { return _Artists; }
			set
			{
				if (value != _Artists)
				{
					_Artists = value;
					OnPropertyChanged("Artists");
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
