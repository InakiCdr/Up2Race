using System;
using System.Collections.Generic;
using Up2Racev2.Views;
using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class PageNew : ContentPage
	{
		//RootPage root;
		Uri link;
		Page page;
		bool _canClose = true;

		public PageNew(Uri link)
		{
			this.link = link;
			InitializeComponent();
			EmbeddedPage(link);
		}
		 
		public void EmbeddedPage(Uri link)
		{
			_viewPage.Source = link;
		}

		protected override bool OnBackButtonPressed()
		{
			return base.OnBackButtonPressed();

		}

		public void CloseApp(object sender, System.EventArgs e)
		{
			CloseAlert(sender, e);
		}

		async void CloseAlert(object sender, EventArgs args)
		{
			var answer = await DisplayAlert("Back to home",
											"Are you sure?",
											"Cancel", "Accept");
			if (_canClose && answer != true)
			{
				//Application.Current.MainPage = new MenuPage();
				//Navigation.PushModalAsync(new Principal());

			}

		}
	}
}
