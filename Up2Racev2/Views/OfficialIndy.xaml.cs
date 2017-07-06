using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class OfficialIndy : ContentPage
	{
		public OfficialIndy()
		{
			InitializeComponent();
			EmbeddedPage();
		}

		public void EmbeddedPage()
		{
			indy.Source = "http://www.indycar.com/";
		}
	}
}
