using System;
using System.Collections.ObjectModel;

namespace Up2Racev2
{
	public class ViewMenuItem : BaseViewModel
	{
		public ObservableCollection<MenuItem> MenuItems { get; set; }
		public ViewMenuItem()
		{
			CanLoadMore = true;
			Title = "Principal";
			MenuItems = new ObservableCollection<MenuItem>();
			MenuItems.Add(new MenuItem
			{
				Id = 0,
				Title = "Principal",
				MenuItemsTitle = MenuItemsTitle.Home,
				Image = ""
			});
			MenuItems.Add(new MenuItem
			{
				Id = 1,
				Title = "Crash.Net",
				MenuItemsTitle = MenuItemsTitle.CrashNet,
				Image = ""
			});
			//MenuItems.Add(new MenuItem
			//{
			//	Id = 2,
			//	Title = "Twitter",
			//	MenuItemsTitle = MenuItemsTitle.Twitter,
			//	Image = ""
			//});
			MenuItems.Add(new MenuItem
			{
				Id = 3,
				Title = "GPOne",
				MenuItemsTitle = MenuItemsTitle.GPOne,
				Image = ""
			});
			MenuItems.Add(new MenuItem
			{
				Id = 4,
				Title = "MotoMatters",
				MenuItemsTitle = MenuItemsTitle.MotoMatters,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{
				Id = 5,
				Title = "MotoGP",
				MenuItemsTitle = MenuItemsTitle.MotoGP,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{
				Id = 6,
				Title = "SoloMoto",
				MenuItemsTitle = MenuItemsTitle.SoloMoto,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{
				Id = 7,
				Title = "MotorSport",
				MenuItemsTitle = MenuItemsTitle.MotorSport,
				Image = ""
			});
		
			MenuItems.Add(new MenuItem
			{
				Id = 8,
				Title = "BikesportNews",
				MenuItemsTitle = MenuItemsTitle.BikesportNews,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{
				Id = 9,
				Title = "MotoGP",
				MenuItemsTitle = MenuItemsTitle.MotoGP,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{
				Id = 10,
				Title = "MotorLuNews",
				MenuItemsTitle = MenuItemsTitle.MotorLuNews,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{
				Id = 11,
				Title = "PecinoGP",
				MenuItemsTitle = MenuItemsTitle.PecinoGP,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{ 
				Id = 12,
				Title = "Credits",
				MenuItemsTitle = MenuItemsTitle.About,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{ 
				Id = 13,
				Title = "MotoAmerica",
				MenuItemsTitle = MenuItemsTitle.MotoAmerica,
				Image = ""
			
			});

			MenuItems.Add(new MenuItem
			{
				Id = 14,
				Title = "Asphalt and Rubber",
				MenuItemsTitle = MenuItemsTitle.AsphaltAndRubber,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{ 
				Id = 15,
				Title = "Manziana Blog",
				MenuItemsTitle = MenuItemsTitle.Manziana,
				Image  = ""
			});

			MenuItems.Add(new MenuItem
			{ 
				Id = 16,
				Title = "Videos",
				MenuItemsTitle = MenuItemsTitle.Videos,
				Image = ""
			});
			MenuItems.Add(new MenuItem
			{ 
				Id = 17,
				Title = "Other motorsport",
				MenuItemsTitle = MenuItemsTitle.Other,
				Image = ""
			});

			MenuItems.Add(new MenuItem
			{
				Id = 18,
				Title = "Contact us!",
				MenuItemsTitle = MenuItemsTitle.Contact,
				Image = ""
			});
		}	
	
	}
}
