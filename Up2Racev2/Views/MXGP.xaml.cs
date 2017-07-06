using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class MXGP : ContentPage
	{
		public MXGP()
		{
			InitializeComponent();
		}

		async void MXGP_Evt(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new MXChampionship());
		}

		async void RacerXOnline(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new RacerXOnLine());
		}
	}
}
