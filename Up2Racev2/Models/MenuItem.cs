using System;
namespace Up2Racev2
{
	//Menús de aplicación.
	public enum MenuItemsTitle
	{
		Home,
		CrashNet,
		SoloMoto,
		//Twitter,
		MotoMatters,
		MotorSport,
		BikesportNews,
		MotoGP,
		Autosport,
		Videos,
		GPOne,
		MotorLuNews,
		PecinoGP,
		MotoAmerica,
		AsphaltAndRubber,
		Manziana,
		Other,
		Contact,
		About
	}

	public class MenuItem : BaseModel
	{
		public MenuItem()
		{
			MenuItemsTitle = MenuItemsTitle.Home;
		}
		public string Image { get; set; }
		public MenuItemsTitle MenuItemsTitle { get; set; }
	}
}
