using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class PecinoGPView : ContentPage
	{
		private PecinoGPViewModel ViewModel
		{ 
			get { return BindingContext as PecinoGPViewModel;}
		}

		public PecinoGPView()
		{
			InitializeComponent();

			BindingContext = new PecinoGPViewModel();

			listView.ItemTapped += (sender, e) =>
			{
				if (listView.SelectedItem == null)
					return;
				this.Navigation.PushAsync(new DetailPecino(listView.SelectedItem
														  as PageItems));
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
