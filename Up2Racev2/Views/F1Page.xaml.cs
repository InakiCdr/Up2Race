using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class F1Page : ContentPage
	{
		public F1Page()
		{
			InitializeComponent();
		}

		async void GrandPrix(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new GrandPrix());
		}
		async void AutosportF1(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new AutosportF1());
		}

		async void Fanatic(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new Fanatic());
		}
	}
}
