using System;

using Xamarin.Forms;

namespace XamFormsAsyncImageDemo
{
	public class App : Application
	{
		public App ()
		{
			//MainPage = new NavigationPage(new HomePage()); //
			MainPage = new RootPage ();
		}
	}
}

