using System;
using Xamarin.Forms;


namespace Up2Racev2.Controls
{
	public class Up2RaceNavigationPage :NavigationPage
	{
		public Up2RaceNavigationPage(Page root): base(root)
		{
			Init();
		}

		void Init()
		{ 
			BarBackgroundColor = Color.FromHex("#6a6a6b");
			BarTextColor = Color.White;
		}
	}
}
