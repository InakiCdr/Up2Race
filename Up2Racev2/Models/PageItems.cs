using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Up2Racev2
{
	public class PageItems : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string name)
		{
			if (PropertyChanged == null)
				return;
			PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	
		public string Description { get; set; }
		public string Link { get; set; }
		public string publishDate;
		public string PublishDate
		{
			get { return publishDate; }
			set
			{
				DateTime time;
				if (DateTime.TryParse(value, out time))
					publishDate = time.ToLocalTime().ToString("D");
				else
					publishDate = value;
			}
		}
		//public string Author { get; set; }
		public int Id { get; set; }
		public string Category { get; set; }

		public string Summary { get; set; }

		public string NewImage { get; set; }

		private string title;
		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}
		private string caption;

		public string Caption
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(caption))
					return caption;


				//get rid of HTML tags
				caption = Regex.Replace(Description, "<[^>]*>", string.Empty);


				//get rid of multiple blank lines
				caption = Regex.Replace(caption, @"^\s*$\n", string.Empty, RegexOptions.Multiline);

				caption = caption.Substring(0, caption.Length < 200 ? caption.Length : 200).Trim() + "...";
				return caption;
			}
		}

		public string Length { get; set; }

		private bool showImage = true;

		public bool ShowImage
		{
			get { return showImage; }
			set { showImage = value; }
		}
		//image 
		private string image = @"";

		/// <summary>
		/// When we set the image, mark show image as true
		/// </summary>
		public string Image
		{
			get { return image; }
			set
			{
				image = value;
				showImage = true;
			}

		}

	}
}
