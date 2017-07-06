using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Up2Racev2.Views;
using Xamarin.Forms;

namespace Up2Racev2
{
		public class App : Application
		{
			public static bool IsWindows10 { get; set; }
			public App()
			{
				// The root page of your application
				MainPage = new RootPage();
			}

			protected override void OnStart()
			{
				// Handle when your app starts
			}

			protected override void OnSleep()
			{
				// Handle when your app sleeps
			}

			protected override void OnResume()
			{
				// Handle when your app resumes
			}
		}

}
