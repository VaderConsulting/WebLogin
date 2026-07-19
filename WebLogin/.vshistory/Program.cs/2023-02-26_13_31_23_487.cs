using System.Net;

namespace WebLogin
{
    class program
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                // Create a HttpClientHandler with NetworkCredential
                HttpClientHandler handler = new HttpClientHandler();
                handler.Credentials = new NetworkCredential("admin", "admin");

                // Create a HttpClient with the handler
                HttpClient client = new HttpClient(handler);

                // Set the base address of the website
                client.BaseAddress = new Uri("http://10.1.1.62");

                // Send a GET request and get the response
                HttpResponseMessage response = await client.GetAsync("/index_cn.html");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Login successful!");

                    // Read and display the response content
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);

                    // Send another GET request to another page on the same website
                    //HttpResponseMessage StatusResponse = await client.GetAsync("/status.html");

                    //// Check if the other request was successful
                    //if (StatusResponse.IsSuccessStatusCode)
                    //{
                    //    Console.WriteLine("Status page loaded!");

                    //    // Read and display the response content
                    //    string content = await response.Content.ReadAsStringAsync();
                    //    Console.WriteLine(content);
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"Status page request failed: {StatusResponse.StatusCode}");
                    //}
                }
                else
                {
                    Console.WriteLine("Login failed!");
                    // Display the status code and reason phrase
                    Console.WriteLine($"Status code: {response.StatusCode}");
                    Console.WriteLine($"Reason phrase: {response.ReasonPhrase}");
                }
            }
        }
    }
}