using System;
using System.Collections.Generic;
using Up2Racev2.Utils;
using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class DetailPageXamlNoImg : ContentPage
	{
		Uri link;
		RemoveTags rtags = new RemoveTags();

		public DetailPageXamlNoImg(PageItems item)
		{
			InitializeComponent();
			BindingContext = item;
			var uri = (new Uri(item.Link));
			link = uri;

			Title.Text = item.Title;
			Description.Text = rtags.StripTagsRegexCompiled(item.Description);

			_image.Source = ImageSource.FromFile("autoLogo.jpg");
		}

		void Handle_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PageNew(link));
		}
	}
}
