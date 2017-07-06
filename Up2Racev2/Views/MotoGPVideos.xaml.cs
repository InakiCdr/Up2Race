using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class MotoGPVideos : ContentPage
	{
		//private MotoGPVideosViewModel ViewModel
		//{
		//	get { return BindingContext as MotoGPVideosViewModel; }
		//}

		//public MotoGPVideos()
		//{
		//	InitializeComponent();
		//	BindingContext = new MotoGpViewModel();

		//	listView.ItemTapped += (sender, e) =>
		//	{
		//		if (listView.SelectedItem == null)
		//			return;
		//		this.Navigation.PushAsync(new PageDetails(listView.SelectedItem
		//												  as PageItems));
		//		listView.SelectedItem = null;
		//	};
		//}

		//protected override void OnAppearing()
		//{
		//	base.OnAppearing();
		//	if (ViewModel == null || !ViewModel.CanLoadMore
		//	   || ViewModel.IsBusy || ViewModel._PageItems.Count > 0)
		//		return;

		//	ViewModel.LoadItemsCommand.Execute(null);
		//}

		public MotoGPVideos()
		{
			InitializeComponent();
			EmbeddedPage();
		}

		public void EmbeddedPage()
		{
			mgpvideos.Source = "https://www.youtube.com/user/MotoGP/feed";
		}
	}
}
