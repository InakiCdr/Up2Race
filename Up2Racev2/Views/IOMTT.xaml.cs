
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class IOMTT : ContentPage
	{
		public IOMTT()
		{
			InitializeComponent();
			EmbeddedPage();
		}

		public void EmbeddedPage()
		{
			ttman.Source = "https://www.iomtt.com/";
		}
	}
}
