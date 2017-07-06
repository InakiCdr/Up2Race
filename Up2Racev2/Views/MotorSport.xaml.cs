using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class MotorSport : ContentPage
	{
		private MotorsportViewModel ViewModel
		{
			get { return BindingContext as MotorsportViewModel; }
		}

		public MotorSport()
		{
			InitializeComponent();

			BindingContext = new MotorsportViewModel();

			listView.ItemTapped += (sender, e) =>
			{
				if (listView.SelectedItem == null)
					return;
				this.Navigation.PushAsync(new DetailMotorSport(listView.SelectedItem as PageItems));
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
