using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            MailMessage msg = new MailMessage();

                String reciver = reciverTextBox.Text;
                msg.To.Add(reciver);

                String adress = yourMail.Text;
                String password = yourPassword.Text;

                MailAddress address = new MailAddress(adress);
                msg.From = address;

                msg.Subject = txtName.Text;
                msg.Body = lblResult.Text;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true; //only enable this if your provider requires it
                                         //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential(adress, password);
                client.Credentials = credentials;

  
                client.Send(msg);

                //Display some feedback to the user to let them know it was sent
                MessageBox.Show("Your message was sent!", "Message sent");

                //Clear the form
                reciverTextBox.Text = "";
                yourMail.Text = "";
                yourPassword.Text = "";
                lblResult.Text = "";
                txtName.Text = "";
            }
            catch
            {
                //If the message failed at some point, let the user know
                MessageBox.Show("Your message failed to send, please try again.", "Sending error");
            }
        }
    }
}
