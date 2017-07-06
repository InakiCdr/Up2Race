using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class RoadRaces : ContentPage
	{
		public RoadRaces()
		{
			InitializeComponent();
		}

		async void northwest200(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new Northwest());
		}

		async void IOMTT(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new IOMTT());
		}
	}
}
