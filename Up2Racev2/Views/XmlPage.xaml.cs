using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class XmlPage : ContentPage
	{
		private XmlViewModel ViewModel
		{
			get { return BindingContext as XmlViewModel; }
		}

		public XmlPage(MenuItemsTitle item)
		{
			InitializeComponent();

			BindingContext = new XmlViewModel(item);

			listView.ItemTapped += (sender, args) =>
			{
				if (listView.SelectedItem == null)
					return;
				
				this.Navigation.PushAsync(new DetailSM(listView.SelectedItem as PageItems));
				listView.SelectedItem = null;
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy
			   || ViewModel.PItems.Count > 0) return;

			ViewModel.LoadItemsCommand.Execute(null);
		}
	}
}
