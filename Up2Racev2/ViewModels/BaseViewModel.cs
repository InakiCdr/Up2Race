using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Up2Racev2
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public BaseViewModel()
		{
		}

		private string title = string.Empty;
		public const string TitlePropertyName = "Title";

		public string Title
		{ 
			get { return title;}
			set { SetProperty(ref title, value);}
		}
		private string subtitle = string.Empty;

		/// <summary>
		/// Gets or sets the "Subtitle" property
		/// </summary>

		public const string SubtitlePropertyName = "Subtitle";
		public string Subtitle
		{
			get { return subtitle; }
			set { SetProperty(ref subtitle, value); }
		}

		private string icon = null;
		public const string IconPropertyName = "Icon";
		public string Icon
		{
			get { return icon; }
			set { SetProperty(ref icon, value); }
		}

		bool isBusy;

		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				if (SetProperty(ref isBusy, value))
					IsNotBusy = !isBusy;
			}
		}

		bool isNotBusy = true;

		public bool IsNotBusy
		{
			get { return isNotBusy; }
			private set { SetProperty(ref isNotBusy, value); }
		}

		private bool loadMore = true;
		public const string CanLoadMorePropertyName = "LoadMore";
		public bool CanLoadMore
		{
			get { return loadMore; }
			set { SetProperty(ref loadMore, value); }
		}

		protected bool SetProperty<T>(
			ref T backingStore, T value,
			[CallerMemberName]string propertyName = "",
			Action onChanged = null)
		{


			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;

			if (onChanged != null)
				onChanged();

			OnPropertyChanged(propertyName);
			return true;
		}

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		public void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
