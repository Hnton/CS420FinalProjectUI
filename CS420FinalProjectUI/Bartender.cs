using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS420FinalProjectUI
{
    public partial class Bartender : Form
    {
        public Bartender()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeForm = new Home();
            homeForm.Show();
            Close();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var client = new WebClient();
            var output = client.DownloadData("https://localhost:32834/api/Bartenders/DrinkOrder");
            var converted = JToken.Parse(Encoding.UTF8.GetString(output));
            textBoxOutput.Text = Environment.NewLine + converted;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            static async Task<string> PostURI(Uri u, HttpContent c)
            {
                var response = string.Empty;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage result = await client.PostAsync(u, c);
                    if (result.IsSuccessStatusCode)
                    {
                        response = result.StatusCode.ToString();
                    }
                }
                return response;
            }

            Uri u = new Uri("https://localhost:32834/api/Bartenders/DrinkReady");

            DateTime time = DateTime.Now;
            //string time = "2020-12-03T03:18:08.070Z";

            string foo = time.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

            string on = OrderNumber.Text;
            string tn = TableNumber.Text;
            string d = Drink.Text;


            string payload = "{\"timeStamp\":\""+foo+"\",\"orderNumber\":"+on+",\"tableNumber\":\""+tn+"\",\"drink\":{\""+d+"\":0}}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, c));
            t.Wait();

            Console.WriteLine(t.Result);
            Console.ReadLine();



            //client.UploadStringTaskAsync("https://localhost:32837/api/Host_Hostess/NewReservation", inputText);

            //client.UploadData("https://localhost:32837/api/Host_Hostess/NewReservation", byteInput);
        }
    }
}
