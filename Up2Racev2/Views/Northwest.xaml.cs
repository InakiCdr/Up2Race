using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class Northwest : ContentPage
	{
		public Northwest()
		{
			InitializeComponent();

			EmbeddedPage();
		}

		public void EmbeddedPage()
		{
			northwest.Source = "http://northwest200.org/";
		}
	}
}
