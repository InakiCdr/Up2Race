using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class NascarView : ContentPage
	{
		public NascarView()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new ME_Nascar());
		}

		async void Handle_Clicked2(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new AutosportNASCAR());
		}
	}
}
