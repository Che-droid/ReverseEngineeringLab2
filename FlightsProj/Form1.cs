using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace FlightsProj
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            gmailPasswordTextBox.PasswordChar = '*';
            attachementPathTextBox.Text = ConfigurationManager.AppSettings["attachementPath"];
        }

        bool sendViaGmail = false;
        bool loadingDisplayFlag = true;
        static int pricesContor = 0;
        string currency;


        // Close when ESC key is pressed
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // If send via Gmail check box is checked.
        private void SendViaGmailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sendViaGmail = true;
        }

        private void WillDoButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Ev_Will_Do!_Click");

            pricesContor = 0;

            timer.Interval = (1000);
            timer.Start();
        }



        private void Timer_Tick(object senderz, EventArgs ev)
        {
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted1;

            timer.Interval = (3600000);
            pricesContor = 0;

            webBrowser1.Navigate("https://www.google.com/");
            


            void WebBrowser1_DocumentCompleted1(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                Console.WriteLine("Ev_1");
                
                webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted1;
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted2;

                // Type eSky.
                HtmlElementCollection htmlGoogleCollection1 
                    = webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement htmlGoogleElement in htmlGoogleCollection1)
                {
                    if (htmlGoogleElement.GetAttribute("title").ToString() == "Search")
                    {
                        htmlGoogleElement.InnerText = "eSky";
                        break;
                    }
                }

                // Click on Search Button.
                HtmlElementCollection htmlGoogleCollection2 
                    = webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement htmlGoogleElement in htmlGoogleCollection2)
                {
                    if (htmlGoogleElement.GetAttribute("name").ToString() == "btnK")
                    {
                        htmlGoogleElement.InvokeMember("Click");
                        break;
                    }
                }
            }

            // Navigate to eSky.
            void WebBrowser1_DocumentCompleted2(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                Console.WriteLine("Ev_2");
                
                webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted2;
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted3;
                
                webBrowser1.Navigate("https://www.esky.ro/");
            }



            // Check round trip.
            void WebBrowser1_DocumentCompleted3(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                Console.WriteLine("Ev_3");
                
                webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted3;
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted4;
                
                webBrowser1.Document.GetElementById("TripTypeRoundtrip").InvokeMember("Click");
            }



            // Read flight data.
            void WebBrowser1_DocumentCompleted4(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                Console.WriteLine("Ev_4");
                
                webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted4;

                Timer event4Timer = new Timer
                {
                    Interval = (1000)
                };
                event4Timer.Start();
                event4Timer.Tick += event4Timer_Tick;
                
                webBrowser1.Document.GetElementById("departureOneway").InnerText = null;
                webBrowser1.Document.GetElementById("arrivalOneway").InnerText = null;
                webBrowser1.Document.GetElementById("departureDateOneway").InnerText = null;
                webBrowser1.Document.GetElementById("returnDateOneway").InnerText = null;
                
                void event4Timer_Tick(object senders, EventArgs es)
                {
                    event4Timer.Tick -= event4Timer_Tick;
                    event4Timer.Stop();

                    webBrowser1.Document.GetElementById("departureRoundtrip0").InnerText =
                            departureLocation.Text;
                        webBrowser1.Document.GetElementById("arrivalRoundtrip0").InnerText =
                            arrivalLocation.Text;
                        webBrowser1.Document.GetElementById("departureDateRoundtrip0").InnerText =
                            departureDate.Value.Date.ToString("yyyy-MM-dd");
                        webBrowser1.Document.GetElementById("departureDateRoundtrip1").InnerText =
                            arrivalDate.Value.Date.ToString("yyyy-MM-dd");

                    webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted5;
                }  
            }


            // Search on eSky.
            void WebBrowser1_DocumentCompleted5(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                Console.WriteLine("Ev_5");
                
                webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted5;
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted6;

                // Click on the eSky search button.
                HtmlElementCollection htmleSkyElementsCollection
                    = webBrowser1.Document.GetElementsByTagName("button");
                foreach (HtmlElement htmleSkyElement in htmleSkyElementsCollection)
                {
                    if (htmleSkyElement.GetAttribute("type") == "submit")
                    {
                        htmleSkyElement.InvokeMember("Click");
                        break;
                    }
                }
            }


             
            void WebBrowser1_DocumentCompleted6(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                Console.WriteLine("Ev_Results");


                webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted6;

                int totalNumberOfPages = 0;
                int numberOfPages = 2;
                int currentPage = 1;

                Timer event6Timer = new Timer
                {
                    Interval = (1000)
                };
                event6Timer.Start();

                event6Timer.Tick += event6Timer_Tick;
                
                void event6Timer_Tick(object senderzz, EventArgs ez)
                {
                    HtmlElementCollection htmlResultsCollection
                       = webBrowser1.Document.GetElementsByTagName("span");
                    foreach (HtmlElement htmlResultsElement in htmlResultsCollection)
                    {
                        if (htmlResultsElement.GetAttribute("data-tab-id").ToString() == "results")
                        {
                            loadingDisplayFlag = false;

                            if (totalNumberOfPages == 0)
                            {
                                ++totalNumberOfPages;

                                HtmlElementCollection htmlPages
                                    = webBrowser1.Document.GetElementsByTagName("ul");
                                foreach (HtmlElement htmlPagesElement in htmlPages)
                                {
                                    if (htmlPagesElement.GetAttribute("className").ToString() == "qa-number-of-all-pages")
                                    {
                                        numberOfPages = Int32.Parse(htmlPagesElement.GetAttribute("data-qa-number-of-all-pages"));
                                        break;
                                    }
                                }
                            }

                            Console.WriteLine("Current page: {0} / {1}", currentPage, numberOfPages);

                            HtmlElementCollection htmlCurrencyCollection1
                                = webBrowser1.Document.GetElementsByTagName("span");
                            foreach (HtmlElement htmlCurrencyElement1 in htmlCurrencyCollection1)
                            {
                                if (htmlCurrencyElement1.GetAttribute("className").ToString() == "current-price")
                                {
                                    HtmlElementCollection htmlCurrencyCollection2
                                        = htmlCurrencyElement1.Children;
                                    foreach (HtmlElement htmlCurrencyElement2 in htmlCurrencyCollection2)
                                    {
                                        if (htmlCurrencyElement2.GetAttribute("className").ToString() == "currency")
                                        {
                                            currency = htmlCurrencyElement2.InnerText.ToString();
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }

                            MySqlCommand sqlCommand = new MySqlCommand();

                            HtmlElementCollection htmlSpanCollection1
                                = webBrowser1.Document.GetElementsByTagName("span");
                            foreach (HtmlElement htmlSpanElement1 in htmlSpanCollection1)
                            {
                                if (htmlSpanElement1.GetAttribute("className").ToString() == "current-price")
                                {
                                    HtmlElementCollection htmlSpanCollection2
                                        = htmlSpanElement1.Children;
                                    foreach (HtmlElement htmlSpanElement2 in htmlSpanCollection2)
                                    {
                                        if (htmlSpanElement2.GetAttribute("className").ToString() == "amount")
                                        {
                                            ++pricesContor;
                                            Console.WriteLine($"{pricesContor}.\t{departureLocation.Text}-{arrivalLocation.Text}\t{htmlSpanElement2.InnerText.ToString()}\t{currency}");

                                            // Write in database
                                            using (MySqlConnection sqlConnection = new MySqlConnection(ConfigurationManager.AppSettings["server"] + ConfigurationManager.AppSettings["user"] + ConfigurationManager.AppSettings["password"] + ConfigurationManager.AppSettings["database"]))
                                            {
                                                sqlConnection.Open();
                                                sqlCommand.Connection = sqlConnection;
                                                sqlCommand.CommandText = "INSERT INTO vs_output(location1, location2, departureDate, arrivalDate, price, currency" + " VALUES(@loc1, @loc2, @departure, @arrival, @price, @currency)";

                                                sqlCommand.Parameters.AddWithValue("loc1", departureLocation.Text);
                                                sqlCommand.Parameters.AddWithValue("loc2", arrivalLocation.Text);
                                                sqlCommand.Parameters.AddWithValue("departure", departureDate.Value.Date.ToString("yyyy-MM-dd"));
                                                sqlCommand.Parameters.AddWithValue("arrival", arrivalDate.Value.Date.ToString("yyyy-MM-dd"));
                                                sqlCommand.Parameters.AddWithValue("price", htmlSpanElement2.InnerText);
                                                sqlCommand.Parameters.AddWithValue("currency", currency);

                                                sqlCommand.ExecuteNonQuery();
                                                sqlCommand.Parameters.Clear();
                                            }
                                            
                                            if (pricesContor == 1)
                                            {
                                                using (StreamWriter flightsStreamWriter = 
                                                    new StreamWriter(ConfigurationManager.AppSettings["textFilePath"]))
                                                    flightsStreamWriter.WriteLine($"{pricesContor}.\t{departureLocation.Text}-{arrivalLocation.Text}\t{htmlSpanElement2.InnerText.ToString()}\t{currency}");
                                            }
                                            else
                                            {
                                                using (StreamWriter flightsStreamWriter = 
                                                    new StreamWriter(ConfigurationManager.AppSettings["textFilePath"], append: true))
                                                    flightsStreamWriter.WriteLine($"{pricesContor}.\t{departureLocation.Text}-{arrivalLocation.Text}\t{htmlSpanElement2.InnerText.ToString()}\t{currency}");
                                            }
                                           
                                        }
                                    }
                                }
                            }

                            // Go to next page
                            if (currentPage < numberOfPages)
                            {
                                HtmlElementCollection htmlPagesCollection
                                = webBrowser1.Document.GetElementsByTagName("span");
                                foreach (HtmlElement htmlPagesElement in htmlPagesCollection)
                                {
                                    if (htmlPagesElement.InnerText == "Next page.")
                                    {
                                        htmlPagesElement.InvokeMember("Click");
                                    }
                                }
                                ++currentPage;
                                Console.WriteLine("");
                            }
                            else
                            {
                                event6Timer.Stop();

                                if (sendViaGmail == true)
                                {
                                    //Overall
                                    MailMessage flightsMessage =
                                        new MailMessage(gmailFromTextBox.Text, gmailToTextBox.Text, "Flights", DateTime.Now.ToShortDateString() + "\t" + DateTime.Now.ToShortTimeString());

                                    SmtpClient smtpClient = new SmtpClient
                                    {
                                        Host = "smtp.gmail.com",
                                        UseDefaultCredentials = false,
                                        Credentials = new System.Net.NetworkCredential(gmailFromTextBox.Text, gmailPasswordTextBox.Text),
                                        Port = 587,
                                        EnableSsl = true
                                    };

                                    //Attachement
                                    Attachment flightsTextFile = new Attachment(attachementPathTextBox.Text);
                                    flightsMessage.Attachments.Add(flightsTextFile);

                                    //Sending
                                    smtpClient.Send(flightsMessage);
                                    MessageBox.Show("Mail sent successfully!", "", MessageBoxButtons.AbortRetryIgnore);

                                    flightsMessage = null;
                                    smtpClient = null;
                                    flightsTextFile = null;
                                }
                            }
                        }
                    }

                    if (loadingDisplayFlag)
                    {
                        Console.WriteLine("Loading...");
                        loadingDisplayFlag = false;
                    }

                } 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
