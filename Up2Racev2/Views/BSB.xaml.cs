using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class BSB : ContentPage
	{
		public BSB()
		{
			InitializeComponent();
			EmbeddedPage();
		}

		public void EmbeddedPage()
		{
			bsb.Source = "http://www.britishsuperbike.com/";
		}
	}
}
