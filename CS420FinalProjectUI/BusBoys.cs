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
    public partial class BusBoys : Form
    {
        public BusBoys()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            var output = client.DownloadData("https://localhost:32835/api/BusBoys/CheckPaid");
            var converted = JToken.Parse(Encoding.UTF8.GetString(output));
            textBoxOutput.Text = Environment.NewLine + converted;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeForm = new Home();
            homeForm.Show();
            Close();

        }

        private void Publish_Click(object sender, EventArgs e)
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

            Uri u = new Uri("https://localhost:32835/api/BusBoys/TableReady");

            DateTime time = DateTime.Now;
            //string time = "2020-12-03T03:18:08.070Z";

            string foo = time.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

            string tn = TableNumber.Text;
            string sc = SeatCount.Text;


            string payload = "{\"timeStamp\":\""+foo+"\",\"tableNumber\":\""+tn+"\",\"seatCount\":"+sc+"}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, c));
            t.Wait();

            Console.WriteLine(t.Result);
            Console.ReadLine();



            //client.UploadStringTaskAsync("https://localhost:32837/api/Host_Hostess/NewReservation", inputText);

            //client.UploadData("https://localhost:32837/api/Host_Hostess/NewReservation", byteInput);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SeatCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void TableNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
