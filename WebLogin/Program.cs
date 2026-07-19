using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebLogin
{
    static class Program
    {
        static Task Main(string[] args)
        {
            ChromeDriver driver;
            ChromeOptions Options = new ChromeOptions();

            Options.AddArgument("disable-infobars");
            Options.AddArgument("headless");

            driver = new ChromeDriver(Options); // create a Chrome browser instance

            while (true)
            {

                //driver.Manage().Window.Minimize();

                try
                {
                    driver.Navigate().GoToUrl("http://admin:admin@192.168.1.59/index_cn.html"); // go to the login page.  Format is user:password@IPAddress/Page

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
                Thread.Sleep(1000);
            }
        }
    }
}