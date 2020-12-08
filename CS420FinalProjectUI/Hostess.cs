using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS420FinalProjectUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            var outputreservation = client.DownloadData("https://localhost:32837/api/Host_Hostess/GetReservation");
            var outputtableready = client.DownloadData("https://localhost:32837/api/Host_Hostess/TableReady");

            var convertedreservation = JToken.Parse(Encoding.UTF8.GetString(outputreservation));
            var convertedtableready = JToken.Parse(Encoding.UTF8.GetString(outputtableready));

            textBoxOutput.Text = convertedreservation + Environment.NewLine + convertedtableready;
        }

        private void button2_Click(object sender, EventArgs e)
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

            Uri u = new Uri("https://localhost:32837/api/Host_Hostess/NewReservation");

            DateTime time = DateTime.Now;
            //string time = "2020-12-03T03:18:08.070Z";

            string foo = time.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

            string tg = TotalGuest.Text;
            string ln = LastName.Text;
            string phone = PhoneNumber.Text;



            string payload = "{\"timeStamp\":\"" +foo +"\",\"totalGuest\":"+ tg +",\"lastName\":\""+ ln +"\",\"phoneNumber\":\""+phone+"\"}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, c));
            t.Wait();

            Console.WriteLine(t.Result);
            Console.ReadLine();



            //client.UploadStringTaskAsync("https://localhost:32837/api/Host_Hostess/NewReservation", inputText);

            //client.UploadData("https://localhost:32837/api/Host_Hostess/NewReservation", byteInput);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeForm = new Home();
            homeForm.Show();
            Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SeatedTablePublish_Click(object sender, EventArgs e)
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

            Uri u = new Uri("https://localhost:32837/api/Host_Hostess/SeatedTable");

            DateTime time = DateTime.Now;
            //string time = "2020-12-03T03:18:08.070Z";

            string foo = time.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

            string tg = SeatedTableTotalGuest.Text;
            string tn = TableNumber.Text;



            string payload = "{\"timeStamp\":\""+foo+"\",\"tableNumber\":\""+tn+"\",\"totalGuests\":"+tg+"}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, c));
            t.Wait();

            Console.WriteLine(t.Result);
            Console.ReadLine();
        }
    }
}
