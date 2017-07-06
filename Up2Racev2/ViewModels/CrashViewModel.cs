using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using ModernHttpClient;
using Xamarin.Forms;

namespace Up2Racev2
{
	public class CrashViewModel : BaseViewModel
	{
		public CrashViewModel()
		{
			Title = "Crash.Net";
			Icon = "";
		}
		private ObservableCollection<PageItems> pageItems = new ObservableCollection<PageItems>();

		/// <summary>
		/// gets or sets the feed items
		/// </summary>
		public ObservableCollection<PageItems> _PageItems
		{
			get { return pageItems; }
			set { pageItems = value; OnPropertyChanged(); }
		}

		private PageItems selectedPageItem;
		/// <summary>
		/// Gets or sets the selected feed item
		/// </summary>
		public PageItems SelectedPageItem
		{
			get { return selectedPageItem; }
			set
			{
				selectedPageItem = value;
				OnPropertyChanged();
			}
		}

		private Command loadItemsCommand;
		/// <summary>
		/// Command to load/refresh items
		/// </summary>
		public Command LoadItemsCommand
		{
			get { return loadItemsCommand ?? (loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand())); }
		}

		private async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			var error = false;
			try
			{
				var responseString = string.Empty;
				//using (var httpClient = new HttpClient())
				using (var httpClient = new HttpClient(new NativeMessageHandler()))	
				{
					var feed = "http://rss.crash.net/crash_motorsports.xml";
					//var feed = "http://motomatters.com/feed/";
					responseString = await httpClient.GetStringAsync(feed);
				}

				_PageItems.Clear();
				var items = await ParseFeed(responseString);
				foreach (var item in items)
				{
					_PageItems.Add(item);
				}
			}
			catch
			{
				error = true;
			}

			if (error)
			{
				var page = new ContentPage();
				await page.DisplayAlert("Error", "Unable to load page.", "OK");

			}

			IsBusy = false;
		}

		private async Task<List<PageItems>> ParseFeed(string rss)
		{
			return await Task.Run(() =>
				{
					XNamespace media = "http://search.yahoo.com/mrss/";
					var xdoc = XDocument.Parse(rss);
					var id = 0;
					return (from item in xdoc.Descendants("item")
							select new PageItems
							{
								Title = (string)item.Element("title"),
								Description = (string)item.Element("description"),
								Link = (string)item.Element("link"),
								Image = (string)item.Element(media+"thumbnail").Attribute("url"),

								Id = id++
							}).ToList();
				});
		}
		public PageItems GetFeedItem(int id)
		{
			return _PageItems.FirstOrDefault(i => i.Id == id);
		}
	}
}
