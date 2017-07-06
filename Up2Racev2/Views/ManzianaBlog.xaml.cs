using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class ManzianaBlog : ContentPage
	{
		//ManzianaViewModel ViewModel
		//{ 
		//	get { return BindingContext as ManzianaViewModel;}
		//}

		public ManzianaBlog()
		{
			InitializeComponent();
			EmbeddedPage();
		}

		public void EmbeddedPage()
		{
			manzi.Source = "http://manziananews.blogspot.com.es/";
		}
	}
}
