using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Up2Racev2.Utils;
using ModernHttpClient;

namespace Up2Racev2
{
	public class XmlViewModel : BaseViewModel
	{
		MenuItemsTitle item;
		RemoveTags removeTags = new RemoveTags();
		private string image;

		public XmlViewModel(MenuItemsTitle item)
		{
			this.item = item;

			switch (item)
			{
				case MenuItemsTitle.SoloMoto:
					image = "";
					Title = "SoloMoto";
					break;
			}
		}

		private ObservableCollection<PageItems> pageItems = new ObservableCollection<PageItems>();

		//recogemos los menu items;

		public ObservableCollection<PageItems> PItems
		{
			get { return pageItems; }
			set { pageItems = value; OnPropertyChanged(); }
		}

		private PageItems selectedPageItems;

		public PageItems SelectedPageItems
		{
			get { return selectedPageItems; }
			set
			{
				selectedPageItems = value;
				OnPropertyChanged();
			}
		}

		private Command loadItemsCommand;

		public Command LoadItemsCommand
		{
			get
			{
				return loadItemsCommand ?? (loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand()));
			}
		}

		private async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;
			IsBusy = true;
			var error = false;
			try
			{
				//ModernHttpClient más rápido que el HttpClient()
				var httpClient = new HttpClient(new NativeMessageHandler());
				var feed = string.Empty;

				switch (item)
				{
					case MenuItemsTitle.SoloMoto:
						feed = "http://solomoto.es/taxonomy/term/1/feed";
						break;
				}
				var respString = await httpClient.GetStringAsync(feed);

				PItems.Clear();
				var items = await ParseFeed(respString);
				foreach (var item in items)
				{
					item.Image = "";
					PItems.Add(item);
				}

				}
				catch
				{
					error = true;
				}
				if (error)
				{
					var page = new ContentPage();
					var result = page.DisplayAlert("Error", "Cant load news.....", "Ok");
				}

				IsBusy = false;
			}

		private async Task<List<PageItems>> ParseFeed(string rss)
		{
			//string caption = Regex.Replace(Description, "<[^>]*>", string.Empty);
			return await Task.Run(() =>
				{
					var xdoc = XDocument.Parse(rss);
					var id = 0;

					return (from item in xdoc.Descendants("item")
							select new PageItems
							{
								Title = (string)item.Element("title"),
								Description = removeTags.StripTagsRegexCompiled((string)item.Element("description")),
								Link = (string)item.Element("link"),

								Id = id++
							}).ToList();
				});
		}
		public PageItems GetFeedItem(int id)
		{
			return PItems.FirstOrDefault(i => i.Id == id);
		}

	}
}
