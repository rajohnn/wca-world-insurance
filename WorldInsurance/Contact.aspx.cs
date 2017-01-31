using System;
using System.Net.Mail;
using System.Configuration;

namespace WorldInsurance {

    public partial class Contact : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void BookButton_Click(object sender, EventArgs e) {
            string name = this.Name.Text;
            string company = this.Company.Text;
            string email = this.Email.Text;
            string phone = this.Phone.Text;
            string toEmail = string.Empty;    

            if (this.contact1.Checked) {
                toEmail = contact1.ToolTip;
            }

            if (this.contact2.Checked) {
                toEmail = contact2.ToolTip;
            }

            if (this.contact3.Checked) {
                toEmail = contact3.ToolTip;
            }

            if (this.contact4.Checked) {
                toEmail = contact4.ToolTip;
            }

            if (this.contact5.Checked) {
                toEmail = contact5.ToolTip;
            }

            if (this.contact6.Checked) {
                toEmail = contact6.ToolTip;
            }

            if (this.contact7.Checked) {
                toEmail = contact7.ToolTip;
            }

            if (!String.IsNullOrWhiteSpace(toEmail)) {
                SendEmail(name, company, email, phone, toEmail);
            }
            
        }

        private void SendEmail(string name, string company, string email, string phone, string toEmail) {
            string to = toEmail;
            string from = email;
            string subject = "World Insurance Website: One-On-One Request";
            string body = String.Format(
                "Name:{0}{4}" +
                "Company:{1}{4}" +
                "Phone: {2}{4}" +
                "E-Mail:{3}{4}", name, company, phone, email, Environment.NewLine);

            int port = 0;
            string host = ConfigurationManager.AppSettings["smtp-host"].ToString();
            Int32.TryParse(ConfigurationManager.AppSettings["smtp-port"].ToString(), out port);
           
            SmtpClient smtpClient = new SmtpClient(host, port);
            smtpClient.UseDefaultCredentials = true;


            MailMessage message = new MailMessage(email, toEmail);
            message.Subject = subject;
            message.Body = body;
            smtpClient.Send(message);
        }
    }
}