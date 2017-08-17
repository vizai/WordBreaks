using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class WorkItemPostData
    {
        public string op;
        public string path;
        public string value;
    }
    public static class MyExtensions
    {
        public async static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };
            return await client.SendAsync(request);
        }
    }
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Title">Work Item Title</param>
        /// <param name="Description">Work Item Description</param>
        /// <param name="WorkItemType">task / bug</param>
        /// <param name="Project">VSO Project</param>
        /// <param name="VSOUrl">VSO URL till Collection</param>
        /// <param name="PAT">Personal Acces Token for Authentication</param>
        static async void CreateWorkItem(String Title, string Description,string WorkItemType,string Project, String VSOUrl,string PAT)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new
           System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
           ("application/json-patch+json"));

                    client.DefaultRequestHeaders.Authorization = new

             // Check system Security Settings in VSO to configure Personal Access Tokens.. This token is valid for 1 Year
             AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                           System.Text.ASCIIEncoding.ASCII.GetBytes(
                           string.Format("{0}:{1}", "", PAT)))); 

                    List<WorkItemPostData> lwiPostData = new List<WorkItemPostData>();
                    lwiPostData.Add(new WorkItemPostData() { op = "add", path = "/fields/System.Title", value = Title });
                    lwiPostData.Add(new WorkItemPostData() { op = "add", path = "/fields/System.Description", value = Description });

                    List<WorkItemPostData> wiPostDataArr = lwiPostData;
                    string wiPostDataString = JsonConvert.SerializeObject(wiPostDataArr);
                    HttpContent wiPostDataContent = new StringContent(wiPostDataString,Encoding.UTF8, "application/json-patch+json");

                    string Url = VSOUrl + "/" + Project +  "/_apis/wit/workitems/$" + WorkItemType + "?api-version=1.0";
                 
                    //Sample Final URLUrl = "https://testkaushik.visualstudio.com/DefaultCollection/MyFirstProject/_apis/wit/workitems/$task?api-version=1.0";



                    using (HttpResponseMessage response = client.PatchAsync(Url, wiPostDataContent).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string ResponseContent = await
                        response.Content.ReadAsStringAsync();
                        Console.WriteLine("SUCCESS");
                      
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                Console.WriteLine("ERROR");
            }
        }


        static void Main(string[] args)
        {
            //Title
            // Check system Security Settings in VSO to configure Personal Access Tokens.. This token is valid for 1 Year
            
            CreateWorkItem("Test FROM Vijay", "Test FROM Vijay as requested by Gopi","task", "MyFirstProject", "https://testkaushik.visualstudio.com/DefaultCollection", "rzesxy2hav5exaoyebnoijcxzdeixyswunohqzgksjxibnunjd5q");
            Console.ReadLine();
        }
    }
}