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
    public partial class Waiter : Form
    {
        public Waiter()
        {
            InitializeComponent();
        }

        private void ConsumeButton_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            var outputSeatedTable = client.DownloadData("https://localhost:32839/api/Waiter_Waitress/SeatedTable");
            //var outputReadyToPay = client.DownloadData("https://localhost:32839/api/Waiter_Waitress/ReadyToPay");
            var outputFoodReady = client.DownloadData("https://localhost:32839/api/Waiter_Waitress/FoodReady");
            var outputDrinkReady = client.DownloadData("https://localhost:32839/api/Waiter_Waitress/DrinkReady");

            var convertedst = JToken.Parse(Encoding.UTF8.GetString(outputSeatedTable));
            //var convertedrtp = JToken.Parse(Encoding.UTF8.GetString(outputReadyToPay));
            var convertedfr = JToken.Parse(Encoding.UTF8.GetString(outputFoodReady));
            var converteddr = JToken.Parse(Encoding.UTF8.GetString(outputDrinkReady));

            textBoxOutput.Text = convertedst
                               + Environment.NewLine + convertedfr
                               + Environment.NewLine + converteddr;
        }

    private void HomeButton_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeForm = new Home();
            homeForm.Show();
            Close();
        }

        private void FoodOrderButton_Click(object sender, EventArgs e)
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

            Uri u = new Uri("https://localhost:32839/api/Waiter_Waitress/FoodOrder");

            DateTime time = DateTime.Now;
            //string time = "2020-12-03T03:18:08.070Z";

            string foo = time.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

            string on = FoodOrderNumber.Text;
            string tn = FoodTableNumber.Text;
            string f = Food.Text;



            string payload = "{\"timeStamp\":\"" + foo + "\",\"orderNumber\":" + on + ",\"tableNumber\":\"" + tn + "\",\"food\":{\"" + f + "\":0}}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, c));
            t.Wait();

            Console.WriteLine(t.Result);
            Console.ReadLine();
        }

        private void DrinkOrderButton_Click(object sender, EventArgs e)
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

            Uri u = new Uri("https://localhost:32839/api/Waiter_Waitress/DrinkOrder");

            DateTime time = DateTime.Now;
            //string time = "2020-12-03T03:18:08.070Z";

            string foo = time.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

            string on = DrinkOrderNumber.Text;
            string tn = DrinkTableNumber.Text;
            string f = Drink.Text;



            string payload = "{\"timeStamp\":\"" + foo + "\",\"orderNumber\":" + on + ",\"tableNumber\":\"" + tn + "\",\"drink\":{\"" + f + "\":0}}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, c));
            t.Wait();

            Console.WriteLine(t.Result);
            Console.ReadLine();
        }

        private void CheckPaidButton_Click(object sender, EventArgs e)
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

            Uri u = new Uri("https://localhost:32839/api/Waiter_Waitress/CheckPaid");

            DateTime time = DateTime.Now;
            //string time = "2020-12-03T03:18:08.070Z";

            string foo = time.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

            string on = CheckPaidTableNumber.Text;



            string payload = "{\"timeStamp\":\"2020-12-04T03:52:28.403Z\",\"tableNumber\":\""+on+"\"}";
            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, c));
            t.Wait();

            Console.WriteLine(t.Result);
            Console.ReadLine();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
