using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class Other_motorsport : ContentPage
	{
		public Other_motorsport()
		{
			InitializeComponent();
		}

		async void f1_News(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new F1Page());
		}

		async void BSB_News(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BSB());
		}

		async void RoadRaces_News(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RoadRaces());
		}

		async void MXGP_News(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MXGP());
		}

		async void WRC_News(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new WRC());
		}

		async void Indy_news(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Indycar());
		}

		async void Handle_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NascarView());
		}
	}
}
