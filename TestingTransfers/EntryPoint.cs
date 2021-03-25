using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingTransfers
{
    public class EntryPoint
    {

        public static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run();

            //now you need to download the driver according of the versión of your web browser
            //In Chrome you can go to Chrome > About Google Chrome and check the version
            //and then you need to download the driver in...
            //http://chromedriver.storage.googleapis.com/index.html
            //the path in the ChromeDriver('path') is refer to the path when you downloaded 
            IWebDriver driver = new ChromeDriver("C:/Users/julio/Downloads/chromedriver_win32");
            //then you now can navigate
            driver.Navigate().GoToUrl("http://localhost:4200/");
            //and await to the page to loadit
            Thread.Sleep(3000);
            //when you need to handle certains elements in the DOM you can access to them with...
            var loginElement = driver.FindElement(By.Id("loginFormIn"));
            //now lets check if the driver can see this element, if the element is it visible on the page
            if (loginElement.Displayed){
                //now we can see the element
                var emailElement = driver.FindElement(By.Name("email"));
                var passwordElement = driver.FindElement(By.Name("password"));
                emailElement.SendKeys("jj@jj.com");
                passwordElement.SendKeys("123");
                var loginButton = driver.FindElement(By.XPath("//*[@id='loginFormIn']/div[3]/div/button"));
                loginButton.Click();
                //now lets the page a chance to load
                Thread.Sleep(3000);
                //if we can see the next button, we are in!
                var okButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
                if (okButton.Displayed)
                    okButton.Click();
                //so lets to the reservation area
                var reservationArea = driver.FindElement(By.XPath("//*[@id='sidebarnav']/li/ul/li[4]/div/a"));
                reservationArea.Click();
                //(single reservation)
                var singleReservartionButton = driver.FindElement(By.XPath("//*[@id='tab-0']/span"));
                singleReservartionButton.Click();
                //so lets fill it
                FillTheCamps fillingIt = new FillTheCamps(driver);
                fillingIt.fillSingleReservationForm();
            }
            else {
                Console.WriteLine("well somethig went wrong, i couldn't see the element");
            }
        }
       
    }

    public class FillTheCamps {
        public IWebDriver driver { get; set; }
        public FillTheCamps(IWebDriver driver){
            this.driver = driver;
        }
        public void fillSingleReservationForm()
        {
            var stAgency = driver.FindElement(By.Id("stAgency"));

            var stName = driver.FindElement(By.Id("stName"));
            stName.SendKeys("juanito");
            var stLastName = driver.FindElement(By.Id("stLastName"));
            stLastName.SendKeys("perez");
            var stEmail = driver.FindElement(By.Id("stEmail"));
            stEmail.SendKeys("test@test.com");
            var stPhone = driver.FindElement(By.Id("stPhone"));
            var stPassengersNumber = driver.FindElement(By.Id("stPassengersNumber"));
            var stOrigin = driver.FindElement(By.Id("stOrigin"));
            var stArrivalDate = driver.FindElement(By.Id("stArrivalDate"));
            var stArrivalAirline = driver.FindElement(By.Id("stArrivalAirline"));
            var stFlightNumber = driver.FindElement(By.Id("stFlightNumber"));
            var stArrivalTime = driver.FindElement(By.Id("stArrivalTime"));
            var stDestiny = driver.FindElement(By.Id("stDestiny"));
            var stCost = driver.FindElement(By.Id("stCost"));

        }
    }
}
