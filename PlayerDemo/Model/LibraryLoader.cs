using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayerDemo
{
	public static class LibraryLoader
	{
		public static async Task<Library> LoadLibraryFromWeb(string url)
		{
			Library lib;
			try
			{
				var content = new MemoryStream();

				var webReq = (HttpWebRequest)WebRequest.Create(url);

				using (WebResponse response = await webReq.GetResponseAsync())
				{
					using (Stream responseStream = response.GetResponseStream())
					{
						var deserializer = new DataContractJsonSerializer(typeof(Library));
						lib = (Library)deserializer.ReadObject(responseStream);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Unable to load library from web.\nError: " + e.Message);
				lib = new Library();
			}
			return lib;
		}
	}
}
