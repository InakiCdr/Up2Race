using System;
using System.Collections.Generic;
using Plugin.Share;
using Up2Racev2.Utils;
using Xamarin.Forms;
using Up2Racev2.Models;
using System.Linq;
using System.Text;


namespace Up2Racev2
{
public partial class TwitterPage : ContentPage
	{
		private TwitterViewModel ViewModel
		{
			get { return BindingContext as TwitterViewModel; }
		}

		void OpenBrowser(string url)
		{
			CrossShare.Current.OpenBrowser(url, new Plugin.Share.Abstractions.BrowserOptions
			{
				ChromeShowTitle = true,
				ChromeToolbarColor = new Plugin.Share.Abstractions.ShareColor { R = 3, G = 169, B = 244, A = 255 },
				UseSafariReaderMode = true,
				UseSafariWebViewController = true
			});
		}

		public TwitterPage()
		{
			InitializeComponent();

			BindingContext = new TwitterViewModel();


			listView.ItemTapped += (sender, args) =>
			{
				if (listView.SelectedItem == null)
					return;



				var tweet = listView.SelectedItem as Tweet;

				//try to launch twitter or tweetbot app, else launch browser
				var launch = DependencyService.Get<TwitterFeeds>();
				if (launch == null || !launch.StatusUser(tweet.StatusID.ToString()))
					OpenBrowser("https://mobile.twitter.com/InakiIcr" + tweet.StatusID);

				listView.SelectedItem = null;
			};
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy || ViewModel.Tweets.Count > 0)
				return;

			ViewModel.LoadTweetsCommand.Execute(null);
		}
	}

}
