using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class ME_Nascar : ContentPage
	{
		private ME_NascarViewModel ViewModel
		{
			get { return BindingContext as ME_NascarViewModel; }
		}

		public ME_Nascar()
		{
			InitializeComponent();

			BindingContext = new ME_NascarViewModel();

			listView.ItemTapped += (sender, e) =>
			{
				if (listView.SelectedItem == null)
					return;
				this.Navigation.PushAsync(new DetailNascarME(listView.SelectedItem as PageItems));
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
