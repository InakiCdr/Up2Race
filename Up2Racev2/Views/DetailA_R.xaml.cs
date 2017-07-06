using System;
using System.Collections.Generic;
using Up2Racev2.Utils;
using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class DetailA_R : ContentPage
	{
		Uri link;
		RemoveTags rtags = new RemoveTags();

		public DetailA_R(PageItems item)
		{
			InitializeComponent();
			BindingContext = item;
			var uri = (new Uri(item.Link));
			link = uri;

			Title.Text = item.Title;
			Description.Text = rtags.StripTagsRegexCompiled(item.Description);

			webImage.Source = ImageSource.FromFile("AsRuLogo.png");

		}
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new PageNew(link));
		}
	}
}
