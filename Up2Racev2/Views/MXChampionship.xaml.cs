using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class MXChampionship : ContentPage
	{
		public MXChampionship()
		{
			InitializeComponent();
			EmbeddedPage();
		}

		public void EmbeddedPage()
		{
			mxgp.Source = "http://www.mxgp.com/";
		}
	}
}
