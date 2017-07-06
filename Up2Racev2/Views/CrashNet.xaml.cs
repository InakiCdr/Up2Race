using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;


using Xamarin.Forms;
using System.Net.Http;

namespace Up2Racev2
{
	public partial class CrashNet : ContentPage
	{

		private CrashViewModel ViewModel
		{ 
			get { return BindingContext as CrashViewModel;}
		}

		public CrashNet()
		{
			InitializeComponent();

			BindingContext = new CrashViewModel();

			listView.ItemTapped += (sender, e) =>
			{
				if (listView.SelectedItem == null)
					return;
				this.Navigation.PushAsync(new DetailCrash(listView.SelectedItem as PageItems));
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
