using System;
using Xamarin.Forms;
using Plugin.Share;
using Up2Racev2.Utils;
using Up2Racev2.Models;

namespace Up2Racev2
{
	public class PageDetailsNImg : BaseView
	{
		Uri link;
		RemoveTags removeTags = new RemoveTags();

		public PageDetailsNImg(PageItems item)
		{
			BindingContext = item;
			var uri = (new Uri(item.Link));
			link = uri;



			var webView = new WebView
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};


			webView.Source = new HtmlWebViewSource
			{
				Html = item.Title + "\n" + removeTags.StripTagsRegexCompiled(item.Description) + "\n" +
						   removeTags.StripTagsRegexCompiled(item.Description)
			};

			Button button = new Button
			{
				HeightRequest = 50,
				WidthRequest = 150,
				Text = "Read more...",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				TextColor = Color.Black,
				BackgroundColor = Color.Silver,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
			button.Clicked += OnButtonClicked;

			Content = new StackLayout
			{
				Children =
				{
					webView,button
				}
			};


		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			//Device.OpenUri(link);
			Navigation.PushAsync(new PageNew(link));
		}

	}
}
