using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class MotoAmerica : ContentPage
	{
		//MotoAmericaViewModel ViewModel
		//{ 
		//	get { return BindingContext as MotoAmericaViewModel;}
		//}

		public MotoAmerica()
		{
			InitializeComponent();

			EmbeddedPage();
		}

		public void EmbeddedPage()
		{
			motoamerica.Source = "http://www.motoamerica.com/news";
		}
	}
}
