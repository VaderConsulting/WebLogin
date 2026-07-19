using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.Net;

namespace WebLogin
{
    class program
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                ChromeDriver driver;

                while (true)
                {
                    driver = new ChromeDriver(); // create a Chrome browser instance

                    driver.Manage().Window.Minimize();

                    try
                    {
                        driver.Navigate().GoToUrl("http://admin:admin@10.1.1.62/index_cn.html"); // go to the login page.  Format is user:password@IPAddress/Page

                        // Allow the page to load
                        Thread.Sleep(500);

                        // Switch to the status frame
                        IWebDriver Frame = driver.SwitchTo().Frame("child_page");
                        // Allow the page to load
                        Thread.Sleep(500);

                        IWebElement CurrentPowerUsageElement = Frame.FindElement(By.Id("webdata_now_p"));

                        string Value = CurrentPowerUsageElement.Text; // Format = "1234 W"
                        int Watts = Convert.ToInt32(CurrentPowerUsageElement.Text.Replace("W", "").Trim()); // Format = "1234 W"

                        Console.WriteLine($"Realtime PV generation: {Watts} W");
                    }
                    catch
                    {
                        // Just in case the window is closed inadvertently
                    }

                    // Close the page
                    driver.Quit();

                    // Pause
                    Thread.Sleep(5000);
                }
            }

            private async void LoginUsingHttpClient()
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