using System;
using System.Collections.Generic;
using Up2Racev2.Utils;
using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class DetailPageXaml : ContentPage
	{
		Uri link;
		RemoveTags rtags = new RemoveTags();
		public DetailPageXaml(PageItems item)
		{
			InitializeComponent();
			BindingContext = item;
			var uri = (new Uri(item.Link));
			link = uri;

			Title.Text = item.Title ;
			Description.Text = rtags.StripTagsRegexCompiled(item.Description);

			//if (Title.Equals("MotoMatters"))
			//{
				webImage.Source = ImageSource.FromFile("motomattersLogo.jpg");
			//}
			//else
			//{ 
				//webImage.Source = ImageSource.FromUri(new Uri(item.Image));			
			//}


		}



		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new PageNew(link));
		}
	}
}
