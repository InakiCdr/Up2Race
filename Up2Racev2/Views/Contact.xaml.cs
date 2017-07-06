using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Messaging;
using Xamarin.Forms;

namespace Up2Racev2
{
	public partial class Contact : ContentPage
	{
		List<string> contenido = new List<string>();

		public Contact()
		{
			InitializeComponent();
		}

		//Recoge los datos que ingresan en los campos de texto.
		public void getDataForm()
		{
			string name = _name.Text;
			string mail = email.Text;
			string content = message.Text;

			contenido.Add(name);
			contenido.Add(mail);
			contenido.Add(content);

		}

		//Crea el correo.
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			var sendEmail = CrossMessaging.Current.EmailMessenger;
			if (sendEmail.CanSendEmail)
			{
				//if (Device.RuntimePlatform == Device.Android ||
				//   Device.RuntimePlatform == Device.iOS)
				//{
					if (sendEmail.CanSendEmailBodyAsHtml &&
					   sendEmail.CanSendEmailAttachments)
					{
						var emailWhitHtmlBody = new EmailMessageBuilder()
							.To("inaki.cdr@gmail.com") //cambiar a up2race
							.Body("Name: \t" + _name.Text + "\n\n" + "Email: \t" + email.Text + "\n" +
							      "Message: \t " + "\n" + message.Text)
							.Subject(_name.Text)
							.Build();
						sendEmail.SendEmail(emailWhitHtmlBody);
					//}
				}
				_name.Text = "";
				email.Text = "";
				message.Text = "";

				_name.Focus();
			}
		}
	}
}
