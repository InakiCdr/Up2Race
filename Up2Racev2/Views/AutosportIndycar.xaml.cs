using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class AutosportIndycar : ContentPage
	{
		private AutosportIndycarViewModel ViewModel
		{
			get { return BindingContext as AutosportIndycarViewModel; }
		}

		public AutosportIndycar()
		{
			InitializeComponent();

			BindingContext = new AutosportIndycarViewModel();

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
