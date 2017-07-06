using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ModernHttpClient;
using Xamarin.Forms;

namespace Up2Racev2
{
	public class ME_NascarViewModel : BaseViewModel
	{
		public ME_NascarViewModel()
		{
			Title = "Monster Energy NASCAR";
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
					var feed = "http://www.mrn.com/Race-Series/NASCAR-Sprint-Cup/News.aspx?rss=true";
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
					var xdoc = XDocument.Parse(rss);
					var id = 0;
					return (from item in xdoc.Descendants("item")
							select new PageItems
							{
								Title = RemoveEncoding((string)item.Element("title")),
								Description = RemoveEncoding((string)item.Element("description")),
								Link = (string)item.Element("link"),
								//PublishDate = (string)item.Element("pubDate"),
								//Category = (string)item.Element("category"),
								Id = id++
							}).ToList();
				});
		}
		public PageItems GetFeedItem(int id)
		{
			return _PageItems.FirstOrDefault(i => i.Id == id);
		}

		public static string RemoveEncoding(string text)

		{
			try

			{
				string temp = "";

				temp =

					Regex.Replace

					(text.
					Replace("&ndash;", "-").
					Replace("&nbsp;", " ").
					Replace("&rsquo;", "'").
					Replace("&amp;", "&").
					Replace("&#038;", "&").
					Replace("&#039;", "'").
					Replace("&#8230;", "...").
					Replace("&#8212;", "—").
					Replace("&#8211;", "-").
					Replace("&#8220;", "“").
					Replace("&#8221;", "”").
					Replace("&#8217;", "'").
					Replace("&#160;", " ").
					Replace("&gt;", ">").
					Replace("&lt;", "<").
					Replace("&#215;", "×").
					Replace("&#8242;", "′").
					Replace("&#8243;", "″").
					Replace("&#8216;", "'"),
					"<[^<>]+>", "");

				return temp;
			}
			catch
			{
				return "";
			}
		}
	}
}
