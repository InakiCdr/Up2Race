using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class WRC : ContentPage
	{
		public WRC()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new OfficialWRC());
		}

		async void Handle_Clicked2(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new AutosportWRC());
		}

		//async void Handle_Clicked3(object sender, System.EventArgs e)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
