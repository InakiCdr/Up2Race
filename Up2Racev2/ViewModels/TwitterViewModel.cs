using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using LinqToTwitter;
using Up2Racev2.Utils;
using System.Linq;
using Up2Racev2.Models;

namespace Up2Racev2
{

		public class TwitterViewModel : BaseViewModel
		{

			public ObservableCollection<Tweet> Tweets { get; set; }

			public TwitterViewModel()
			{
				Title = "Twitter";
				Icon = "";
				Tweets = new ObservableCollection<Tweet>();
			}

			private Command loadTweetsCommand;

			public Command LoadTweetsCommand
			{
				get
				{
					return loadTweetsCommand ??
					  (loadTweetsCommand = new Command(async () =>
					  {
						  await ExecuteLoadTweetsCommand();
					  }, () =>
					  {
						  return !IsBusy;
					  }));
				}
			}

			public async Task ExecuteLoadTweetsCommand()
			{
				if (IsBusy)
					return;

				IsBusy = true;
				LoadTweetsCommand.ChangeCanExecute();
				var error = false;
				try
				{
					Tweets.Clear();
				var auth = new ApplicationOnlyAuthorizer()
				{
					CredentialStore = new InMemoryCredentialStore()
					{
						//No consigo la autenticación de la cuenta de twitter.
						ConsumerKey = "", 
							ConsumerSecret =  "",
						},
					};
					await auth.AuthorizeAsync();

					var twitterContext = new TwitterContext(auth);

					var queryResponse = await
					(from tweet in  twitterContext.Status
					   where tweet.Type == StatusType.User &&
						 tweet.ScreenName == "Up2Race" &&
						 tweet.Count == 100 &&
						 tweet.IncludeRetweets == true &&
						 tweet.ExcludeReplies == true
					   select tweet).ToListAsync();

					var tweets =
					  (from tweet in queryResponse
					   select new Tweet
					   {
						   StatusID = tweet.StatusID,
						   ScreenName = tweet.User.ScreenNameResponse,
						   Text = tweet.Text,
						   CurrentUserRetweet = tweet.CurrentUserRetweet,
						   CreatedAt = tweet.CreatedAt,
						   Image = tweet.RetweetedStatus != null && tweet.RetweetedStatus.User != null ?
										  tweet.RetweetedStatus.User.ProfileImageUrl.Replace("http://", "https://") : (tweet.User.ScreenNameResponse == "InakiIcr" ? "logo.png" : tweet.User.ProfileImageUrl.Replace("http://", "https://"))
					   }).ToList();
					foreach (var tweet in tweets)
					{
						Tweets.Add(tweet);
					}

					if (Device.OS == TargetPlatform.iOS)
					{
					//para el watch
					DependencyService.Get<TweetList>().Save(tweets);
					}
				}
				catch
				{
					error = true;
				}

				if (error)
				{
					var page = new ContentPage();
					await page.DisplayAlert("Error", "Unable to load tweets.", "OK");
				}

				IsBusy = false;
				LoadTweetsCommand.ChangeCanExecute();
			}
		}
}
