using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace XamFormsAsyncImageDemo
{
	public class HomePage : ContentPage
	{
		public HomePage () : base()
		{
			base.Title = "Async Images Practice";

			// Load dat dummy data!
			Load ();
		} 

		private async void Load()
		{
			var listView = new ListView ();

			// ImageCell is a pre-existing cell (inheritable for extension)
			var cell = new DataTemplate (typeof(ImageCell));
			cell.SetBinding (TextCell.TextProperty, "Description");
			cell.SetBinding (ImageCell.ImageSourceProperty, "Url");

			// Sets the binding template
			listView.ItemTemplate = cell;

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			this.Content = listView;

			// Async image load
			await LoadImages (listView);
		}

		private async Task LoadImages(ListView listView)
		{
			var images = await GetImages ();
			listView.ItemsSource = images;
		}

		/// <summary>
		/// Gets the images. For simplicity's sake I've only used one image multiple times (without caching). 
		/// Obviously, this can be applied to multiple images.
		/// </summary>
		/// <returns>List of ImageExample objects</returns>
		private async Task<List<ImageExample>> GetImages()
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

			return images;
		}
	}

	public class ImageExample
	{
		public string Url { get; set; }
		public string Description { get; set; }
	}
}

