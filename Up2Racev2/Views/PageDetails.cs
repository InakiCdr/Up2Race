using System;
using Xamarin.Forms;
using Plugin.Share;
using Up2Racev2.Utils;
using Up2Racev2.Models;

namespace Up2Racev2
{
	public class PageDetails : BaseView
	{
		Uri link;
		RemoveTags removeTags = new RemoveTags();

		public PageDetails(PageItems item)
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
				Html = item.Title + "\n" + removeTags.StripTagsRegexCompiled(item.Description) 
			};

			var webImage = new Image { Aspect = Aspect.AspectFit };
			webImage.Source = ImageSource.FromUri(new Uri(item.Image));

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
					webImage,webView,button
				}
			};
			//var share = new ToolbarItem
			//{
			//	Icon = "logo.png",
			//	Text = "Share",
			//	Command = new Command(() => CrossShare.Current
			//						  .Share(new Plugin.Share.Abstractions.ShareMessage
			//						  {
			//							  Text = "Read @Crash.Net " + item.Title + " " + item.Link,
			//							  Title = "Share",
			//							  Url = item.Link
			//						  }))
			//};
			//ToolbarItems.Add(share);

		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			//Device.OpenUri(link);
			Navigation.PushAsync(new PageNew(link));
		}


	}

}
