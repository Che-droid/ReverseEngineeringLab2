using System;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using FlightsProj.DataManagers;

namespace FlightsProj
{
    public partial class Form1 : Form
    {
        private int _pricesContor = 0;
        private bool _sendViaGmail = false;
        private bool _loadingDisplayFlag = true;
        private string _currency;
        
        private IDataManager _dataManager;
        private MailManager mailManager;

        public Form1(IDataManager dataManager)
        {
            InitializeComponent();

            _dataManager = dataManager;
            mailManager = new MailManager(gmailFromTextBox.Text, gmailPasswordTextBox.Text);
            gmailPasswordTextBox.PasswordChar = '*';
            attachementPathTextBox.Text = ConfigurationManager.AppSettings["attachementPath"];
        }

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
            _sendViaGmail = true;
        }

        private void WillDoButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Ev_Will_Do!_Click");

            _pricesContor = 0;

            timer.Interval = (1000);
            timer.Start();
        }

        private void Timer_Tick(object senderz, EventArgs ev)
        {
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted1;

            timer.Interval = (3600000);
            _pricesContor = 0;

            webBrowser1.Navigate("https://www.google.com/");

            void WebBrowser1_DocumentCompleted1(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                Console.WriteLine("Ev_1");

                webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted1;
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted2;

                // Type eSky.
                HtmlElementCollection htmlGoogleCollection1 = webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement htmlGoogleElement in htmlGoogleCollection1)
                {
                    if (htmlGoogleElement.GetAttribute("title").ToString() == "Search")
                    {
                        htmlGoogleElement.InnerText = "eSky";
                        break;
                    }
                }

                // Click on Search Button.
                HtmlElementCollection htmlGoogleCollection2 = webBrowser1.Document.GetElementsByTagName("input");
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

                    webBrowser1.Document.GetElementById("departureRoundtrip0").InnerText = departureLocation.Text;
                    webBrowser1.Document.GetElementById("arrivalRoundtrip0").InnerText = arrivalLocation.Text;
                    webBrowser1.Document.GetElementById("departureDateRoundtrip0").InnerText = departureDate.Value.Date.ToString("yyyy-MM-dd");
                    webBrowser1.Document.GetElementById("departureDateRoundtrip1").InnerText = arrivalDate.Value.Date.ToString("yyyy-MM-dd");

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
                HtmlElementCollection htmleSkyElementsCollection = webBrowser1.Document.GetElementsByTagName("button");
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
                    HtmlElementCollection htmlResultsCollection = webBrowser1.Document.GetElementsByTagName("span");
                    foreach (HtmlElement htmlResultsElement in htmlResultsCollection)
                    {
                        if (htmlResultsElement.GetAttribute("data-tab-id").ToString() == "results")
                        {
                            _loadingDisplayFlag = false;

                            if (totalNumberOfPages == 0)
                            {
                                ++totalNumberOfPages;

                                HtmlElementCollection htmlPages = webBrowser1.Document.GetElementsByTagName("ul");
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

                            HtmlElementCollection htmlCurrencyCollection1 = webBrowser1.Document.GetElementsByTagName("span");
                            foreach (HtmlElement htmlCurrencyElement1 in htmlCurrencyCollection1)
                            {
                                if (htmlCurrencyElement1.GetAttribute("className").ToString() == "current-price")
                                {
                                    HtmlElementCollection htmlCurrencyCollection2 = htmlCurrencyElement1.Children;
                                    foreach (HtmlElement htmlCurrencyElement2 in htmlCurrencyCollection2)
                                    {
                                        if (htmlCurrencyElement2.GetAttribute("className").ToString() == "currency")
                                        {
                                            _currency = htmlCurrencyElement2.InnerText.ToString();
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }

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
                                            ++_pricesContor;
                                            Console.WriteLine($"{_pricesContor}.\t{departureLocation.Text}-{arrivalLocation.Text}\t{htmlSpanElement2.InnerText.ToString()}\t{_currency}");

                                            // Write in database
                                            _dataManager.Save(departureLocation.Text, arrivalLocation.Text, departureDate.Value.Date.ToString("yyyy-MM-dd"),
                                                arrivalDate.Value.Date.ToString("yyyy-MM-dd"), htmlSpanElement2.InnerText, _currency);

                                            if (_pricesContor == 1)
                                            {
                                                using (StreamWriter flightsStreamWriter = new StreamWriter(ConfigurationManager.AppSettings["textFilePath"]))
                                                    flightsStreamWriter.WriteLine($"{_pricesContor}.\t{departureLocation.Text}-{arrivalLocation.Text}\t{htmlSpanElement2.InnerText.ToString()}\t{_currency}");
                                            }
                                            else
                                            {
                                                using (StreamWriter flightsStreamWriter = new StreamWriter(ConfigurationManager.AppSettings["textFilePath"], append: true))
                                                    flightsStreamWriter.WriteLine($"{_pricesContor}.\t{departureLocation.Text}-{arrivalLocation.Text}\t{htmlSpanElement2.InnerText.ToString()}\t{_currency}");
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

                                if (_sendViaGmail)
                                {
                                    mailManager.SendMessage(gmailFromTextBox.Text, gmailToTextBox.Text, attachementPathTextBox.Text);
                                    MessageBox.Show("Mail sent successfully!", "", MessageBoxButtons.AbortRetryIgnore);
                                }
                            }
                        }
                    }

                    if (_loadingDisplayFlag)
                    {
                        Console.WriteLine("Loading...");
                        _loadingDisplayFlag = false;
                    }
                }
            }
        }
    }
}
