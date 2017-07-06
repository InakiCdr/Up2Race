using System;
using System.Collections.Generic;
using Up2Racev2.Views;
using Xamarin.Forms;

namespace Up2Racev2
{
		public partial class MenuPage : ContentPage
		{
		RootPage root;
		List<MenuItem> menuItems;

		public MenuPage() { }

		public MenuPage(RootPage root)
			{

				this.root = root;
				InitializeComponent();
				//if (!App.IsWindows10)
				//{
				//	BackgroundColor = Color.FromHex("#03A9F4");
				//	ListViewMenu.BackgroundColor = Color.FromHex("#F5F5F5");
				//}
				BindingContext = new BaseViewModel
				{
					Title = "UP2Race",
					Subtitle = "UP2Race",
					Icon = ""
				};

			ListViewMenu.ItemsSource = menuItems = new List<MenuItem>
				{
				new MenuItem { Title = "Home", MenuItemsTitle = MenuItemsTitle.Home, Image ="" },
				//new MenuItem { Title = "Twitter", MenuItemsTitle = MenuItemsTitle.Twitter, Image = "" },
				new MenuItem { Title = "CrashNet", MenuItemsTitle = MenuItemsTitle.CrashNet, Image = "" },
				new MenuItem { Title = "SoloMoto", MenuItemsTitle = MenuItemsTitle.SoloMoto, Image = "" },
				new MenuItem { Title = "MotoMatters", MenuItemsTitle = MenuItemsTitle.MotoMatters, Image = ""},
				new MenuItem { Title = "MotorSport", MenuItemsTitle = MenuItemsTitle.MotorSport, Image = ""},
				new MenuItem { Title = "MotoGP" , MenuItemsTitle = MenuItemsTitle.MotoGP, Image = ""},
				new MenuItem { Title = "GPone", MenuItemsTitle = MenuItemsTitle.GPOne, Image=""},
				new MenuItem { Title = "MotorLuNews", MenuItemsTitle = MenuItemsTitle.MotorLuNews, Image = ""},
				new MenuItem { Title = "Videos", MenuItemsTitle = MenuItemsTitle.Videos, Image=""},
				new MenuItem { Title = "PecinoGP", MenuItemsTitle = MenuItemsTitle.PecinoGP, Image = ""},
				new MenuItem { Title = "MotoAmerica", MenuItemsTitle = MenuItemsTitle.MotoAmerica, Image=""},
				new MenuItem { Title = "Asphalt and Rubber", MenuItemsTitle = MenuItemsTitle.AsphaltAndRubber, Image=""},
				new MenuItem { Title = "Manziana", MenuItemsTitle = MenuItemsTitle.Manziana, Image=""},
				new MenuItem { Title = "Autosport", MenuItemsTitle = MenuItemsTitle.Autosport, Image =""},
				new MenuItem { Title = "Other Motorsport", MenuItemsTitle = MenuItemsTitle.Other, Image =""},
				new MenuItem { Title = "Contact us!!", MenuItemsTitle = MenuItemsTitle.Contact, Image=""},
				new MenuItem { Title = "About", MenuItemsTitle = MenuItemsTitle.About, Image =""}


				};

				ListViewMenu.SelectedItem = menuItems[0];

				ListViewMenu.ItemSelected += async (sender, e) =>
					{
						if (ListViewMenu.SelectedItem == null)
							return;

				await this.root.NavigateAsync(((MenuItem)e.SelectedItem).MenuItemsTitle);
					};
				
			}
	}
}
