using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace WorldInsurance {

    public partial class Contact : System.Web.UI.Page {
        private EmailModel _model = new EmailModel();

        internal class EmailModel {
            public string Name { get; set; }
            public string Company { get; set; }
            public string FromEmail { get; set; }
            public string Phone { get; set; }
            public string ToEmail { get; set; }

            public bool IsModelValid() {
                bool isValid = true;
                isValid = IsValidEmail(this.ToEmail);
                isValid = IsValidEmail(this.FromEmail);

                if (String.IsNullOrWhiteSpace(Name))
                    isValid = false;

                if (String.IsNullOrWhiteSpace(Phone))
                    isValid = false;

                if (String.IsNullOrWhiteSpace(Company))
                    Company = "No Company Given";

                if (!IsPhoneNumber())                     
                    Phone = String.Format("Invalid phone given: {0}", Phone.Trim());

                return isValid;
            }
            private bool IsPhoneNumber() {
                return Regex.Match(Phone, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").Success;
            }

            private bool IsValidEmail(string email) {
                try {
                    var addr = new MailAddress(email);
                    return true;
                }
                catch {
                    return false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void BookButton_Click(object sender, EventArgs e) {
            _model = new EmailModel();
            _model.Name = this.Name.Text.Trim();
            _model.Company = this.Company.Text.Trim();
            _model.FromEmail = this.Email.Text.Trim();
            _model.Phone = this.Phone.Text.Trim();
            _model.ToEmail = string.Empty;

            if (this.contact1.Checked) {
                _model.ToEmail = contact1.ToolTip;
            }

            if (this.contact2.Checked) {
                _model.ToEmail = contact2.ToolTip;
            }

            if (this.contact3.Checked) {
                _model.ToEmail = contact3.ToolTip;
            }

            if (this.contact4.Checked) {
                _model.ToEmail = contact4.ToolTip;
            }

            if (this.contact5.Checked) {
                _model.ToEmail = contact5.ToolTip;
            }

            if (this.contact6.Checked) {
                _model.ToEmail = contact6.ToolTip;
            }

            if (this.contact7.Checked) {
                _model.ToEmail = contact7.ToolTip;
            }

            if (this.contact8.Checked) {
                _model.ToEmail = contact8.ToolTip;
            }

            if (_model.IsModelValid()) {
                SendEmail();
                this.PanelThankYou.Visible = true;
            }
        }

        private void SendEmail() {
            try {
                string to = _model.ToEmail;
                string from = _model.FromEmail;
                string subject = "World Insurance Website: One-On-One Request";
                string body = String.Format(
                    "Name:{0}{4}" +
                    "Company:{1}{4}" +
                    "Phone: {2}{4}" +
                    "E-Mail:{3}{4}", _model.Name, _model.Company, _model.Phone, _model.FromEmail, Environment.NewLine);

                int port = 0;
                string host = ConfigurationManager.AppSettings["smtp-host"].ToString();
                string username = ConfigurationManager.AppSettings["smtp-username"].ToString();
                string password = ConfigurationManager.AppSettings["smtp-password"].ToString();
                Int32.TryParse(ConfigurationManager.AppSettings["smtp-port"].ToString(), out port);

                var client = new SmtpClient(host, port);
                client.Credentials = new NetworkCredential(username, password);
                client.EnableSsl = false;

                var message = new MailMessage(_model.FromEmail, _model.ToEmail);
                message.Subject = subject;
                message.Body = body;
                client.Send(message);
            }
            catch { // this is intentional.  There is no logging, etc. for this website.

            }
          
        }
    }
}