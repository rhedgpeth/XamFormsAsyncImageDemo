using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamFormsAsyncImageDemo
{
	public partial class HomePage2 : ContentPage
	{
		public ObservableCollection<ImageExample> ImageExamples = new ObservableCollection<ImageExample>();

		public HomePage2 ()
		{
			InitializeComponent ();
			Load ();
		}

		private async void Load()
		{
			list.ItemsSource = await GetImages();
		}

		/// <summary>
		/// Gets the images. For simplicity's sake I've only used one image multiple times (without caching). 
		/// Obviously, this can be applied to multiple images.
		/// </summary>
		/// <returns>List of ImageExample objects</returns>
		private async Task<ObservableCollection<ImageExample>> GetImages()
		{
			var url = "http://hedgpethconsulting.com/images/xamarin-certified-mobile-developer.png";

			var images = new List<ImageExample> ();

			for (int i = 0; i < 100; i++)
			{
				var image = new ImageExample {
					Url = url,
					Description = string.Format("Image No.: {0}", i.ToString())
				};

				images.Add (image);
			}

			return new ObservableCollection<ImageExample>(images);
		}
	}
}

