using Microsoft.Extensions.Configuration;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.Configuration;

namespace WebLogin
{
    class program
    {
        class Program
        {
            /// <summary>
            /// specifies if hangfire job run or not 
            /// </summary>
            protected bool HangFireEnabled
            {
                get
                {
                    return Configuration.GetSection("GeneralApplicationSettings").GetValue<bool>("HangFireEnabled");
                }
            }

            static async Task Main(string[] args)
            {
                ChromeDriver driver;
                driver = new ChromeDriver(); // create a Chrome browser instance

                while (true)
                {

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
                        int Watts = Convert.ToInt32(CurrentPowerUsageElement.Text.Replace("W", "").Trim());

                        Console.WriteLine($"Realtime PV generation: {Watts} W");
                    }
                    catch
                    {
                        // Just in case the window is closed inadvertently
                    }

                    // Close the page
                    //driver.Quit();

                    // Pause
                    Thread.Sleep(5000);
                }
            }
        }
    }
}