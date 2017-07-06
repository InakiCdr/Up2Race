using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class MotoGP : ContentPage
	{
		private MotoGpViewModel ViewModel
		{ 
			get { return BindingContext as MotoGpViewModel;}
		}

		public MotoGP()
		{
			InitializeComponent();
			BindingContext = new MotoGpViewModel();

			listView.ItemTapped += (sender, e) =>
			{
				if (listView.SelectedItem == null)
					return;
				this.Navigation.PushAsync(new DetailMGP(listView.SelectedItem
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
