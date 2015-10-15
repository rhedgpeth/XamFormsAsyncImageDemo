using System;
using Xamarin.Forms;

namespace XamFormsAsyncImageDemo
{
	public class RootPage : MasterDetailPage
	{
		public RootPage ()
		{
			var master = new Page {
				Title = "Master"
			};

			Master = master;

			//Detail = new NavigationPage (new HomePage ());
			Detail = new NavigationPage (new HomePage2 ());
		}
	}
}

