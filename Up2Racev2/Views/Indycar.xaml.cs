using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class Indycar : ContentPage
	{
		public Indycar()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new OfficialIndy());
		}

		async void Handle_Clicked1(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new AutosportIndycar());
		}
	}
}
