using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class AutosportNASCAR : ContentPage
	{
		private AutosportNascarViewModel ViewModel
		{
			get { return BindingContext as AutosportNascarViewModel; }
		}

		public AutosportNASCAR()
		{
			InitializeComponent();

			BindingContext = new AutosportNascarViewModel();

			listView.ItemTapped += (sender, e) =>
			{
				if (listView.SelectedItem == null)
					return;
				this.Navigation.PushAsync(new DetailPageXamlNoImg(listView.SelectedItem as PageItems));
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
