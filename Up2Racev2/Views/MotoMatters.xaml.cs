using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class MotoMatters : ContentPage
	{
		MotoMattersViewModel ViewModel
		{
			get { return BindingContext as MotoMattersViewModel; }
		}

		public MotoMatters()
		{
			InitializeComponent();

			BindingContext = new MotoMattersViewModel();

			listView.ItemTapped += (sender, e) =>
			{
				if (listView.SelectedItem == null)
					return;
				//this.Navigation.PushAsync(new PageDetailsNImg(listView.SelectedItem as PageItems));
				this.Navigation.PushAsync(new DetailPageXaml(listView.SelectedItem as PageItems));
				listView.SelectedItem = null;
			};

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (ViewModel == null || !ViewModel.CanLoadMore
			   || ViewModel.IsBusy || ViewModel._PageItems.Count > 0)
				return;

			ViewModel.LoadItemsCommand.Execute(null);
		}
	}
}
