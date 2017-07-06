using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Up2Racev2.Controls;

namespace Up2Racev2.Views
{
	public class RootPage : MasterDetailPage
	{
		public static bool IsUWPDesktop { get; set; }
		Dictionary<MenuItemsTitle, NavigationPage> Pages { get; set; }
		public RootPage()
		{

			Pages = new Dictionary<MenuItemsTitle, NavigationPage>();
			Master = new MenuPage(this);
			BindingContext = new BaseViewModel
			{
				Title = "Principal",
				Icon = ""
			};
			//setup home page
			NavigateAsync(MenuItemsTitle.Home);

			InvalidateMeasure();
		}



		public async Task NavigateAsync(MenuItemsTitle id)
		{

			if (Detail != null)
			{
				if (IsUWPDesktop || Device.Idiom != TargetIdiom.Tablet)
					IsPresented = false;

				if (Device.OS == TargetPlatform.Android)
					await Task.Delay(300);
			}

			Page newPage;
			if (!Pages.ContainsKey(id))
			{

				switch (id)
				{
					case MenuItemsTitle.Home:
						Pages.Add(id, new Up2RaceNavigationPage(new Principal()));
						break;
					//case MenuItemsTitle.Twitter:
					//	Pages.Add(id, new Up2RaceNavigationPage(new TwitterPage()));
					//	break;
					case MenuItemsTitle.CrashNet:
						Pages.Add(id, new Up2RaceNavigationPage(new CrashNet()));
						break;
					case MenuItemsTitle.SoloMoto:
						Pages.Add(id, new Up2RaceNavigationPage(new XmlPage(id)));
						break;
					case MenuItemsTitle.MotoMatters:
						Pages.Add(id, new Up2RaceNavigationPage(new MotoMatters()));
						break;
					case MenuItemsTitle.MotorSport:
						Pages.Add(id, new Up2RaceNavigationPage(new MotorSport()));
						break;
						
					case MenuItemsTitle.MotoGP:
						Pages.Add(id, new Up2RaceNavigationPage(new MotoGP()));
						break;
					
					case MenuItemsTitle.GPOne:
						Pages.Add(id, new Up2RaceNavigationPage(new GPOne()));
						break;

					case MenuItemsTitle.MotorLuNews:
						Pages.Add(id, new Up2RaceNavigationPage(new MotorLuNewsView()));
						break;

					case MenuItemsTitle.PecinoGP:
						Pages.Add(id, new Up2RaceNavigationPage(new PecinoGPView()));
						break;
					
					case MenuItemsTitle.MotoAmerica:
						Pages.Add(id, new Up2RaceNavigationPage(new MotoAmerica()));
						break;

					case MenuItemsTitle.AsphaltAndRubber:
						Pages.Add(id, new Up2RaceNavigationPage(new AsphaltAndRubber()));
						break;
					
					case MenuItemsTitle.About:
						Pages.Add(id, new Up2RaceNavigationPage(new Credits()));
						break;
					case MenuItemsTitle.Manziana:
						Pages.Add(id, new Up2RaceNavigationPage(new ManzianaBlog()));
						break;

					case MenuItemsTitle.Autosport:
						Pages.Add(id, new Up2RaceNavigationPage(new Autosport()));
						break;
					case MenuItemsTitle.Other:
						Pages.Add(id, new Up2RaceNavigationPage(new Other_motorsport()));
						break;
					case MenuItemsTitle.Contact:
						Pages.Add(id, new Up2RaceNavigationPage(new Contact()));
						break;
					case MenuItemsTitle.Videos:
						Pages.Add(id, new Up2RaceNavigationPage(new MotoGPVideos()));
						break;
				}
			}

			newPage = Pages[id];
			if (newPage == null)
				return;

			//pop to root for Windows Phone
			if (Detail != null && Device.OS == TargetPlatform.WinPhone)
			{
				await Detail.Navigation.PopToRootAsync();
			}

			Detail = newPage;
		}
	}
}

