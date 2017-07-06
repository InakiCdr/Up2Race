using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class AsphaltAndRubber : ContentPage
	{
		private AsphaltandrubberViewModel ViewModel
		{
			get { return BindingContext as AsphaltandrubberViewModel; }
		}

		public AsphaltAndRubber()
		{
			InitializeComponent();

			BindingContext = new AsphaltandrubberViewModel();

			//Pasamos el item seleccionado de la lista a una página detalle.
			//en esa página detalle se mostrará la descripción, el título y un botón para ir a la web de la noticia.
			listView.ItemTapped += (sender, e) =>
			{
				if (listView.SelectedItem == null)
					return;
				this.Navigation.PushAsync(new DetailA_R(listView.SelectedItem as PageItems));
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
