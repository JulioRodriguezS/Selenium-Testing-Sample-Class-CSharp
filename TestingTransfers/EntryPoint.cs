using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace TestingTransfers
{
    public class EntryPoint
    {

        public static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run();

            //now you need to download the driver according of the version of your web browser
            //In Chrome you can go to "Chrome > About Google Chrome" and view the version
            //and then you need to download the driver in...
            //http://chromedriver.storage.googleapis.com/index.html
            //the path in the ChromeDriver('path') is refered to the path when you downloaded 
            //and we can add options to open in the time the web console for debug the results...
            var options = new ChromeOptions();
            options.AddArguments(new[] { "start-maximized", "auto-open-devtools-for-tabs" });
            IWebDriver driver = new ChromeDriver("C:/Users/julio/Downloads/chromedriver_win32", options);
            
            //then you now can navigate
            //driver.Navigate().GoToUrl("https://transfers-american-way-admin.herokuapp.com/");
            driver.Navigate().GoToUrl("http://localhost:4200/");
            //and await to the page to loadit
            Thread.Sleep(3000);
            //when you need to handle certains elements in the DOM you can access to them with...
            //now lets check if the driver can see this element, if the element is it visible on the page
            if (driver.FindElement(By.Id("loginFormIn")).Displayed){
                //now we can see the element
                var emailElement = driver.FindElement(By.Name("email"));
                var passwordElement = driver.FindElement(By.Name("password"));
                emailElement.SendKeys("prueba@prueba.com");
                passwordElement.SendKeys("123");
                var loginButton = driver.FindElement(By.XPath("//*[@id='loginFormIn']/div[3]/div/button"));
                loginButton.Click();
                //now lets the page a chance to load
                Thread.Sleep(6000);
                //if we can see the next button, we are in!
                if (driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]")).Displayed)
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]")).Click();
                //so lets to the reservation area
                //driver.Navigate().GoToUrl("https://transfers-american-way-admin.herokuapp.com/dashboard/add-reservation-form");
                driver.Navigate().GoToUrl("http://localhost:4200/dashboard/add-reservation-form");
                Thread.Sleep(3000);
                //(single reservation)
                var singleReservartionButton = driver.FindElement(By.XPath("//*[@id='tab-0']/span"));
                singleReservartionButton.Click();
                //so lets fill it
                FillTheCamps fillingIt = new FillTheCamps(driver);
                //fillingIt.fillSingleReservationForm();
                fillingIt.fillRoundReservationForm();
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
            var selestAgency = new SelectElement(stAgency);
            selestAgency.SelectByText("American Way");

            var stName = driver.FindElement(By.Id("stName"));
            stName.SendKeys("juanito");
            var stLastName = driver.FindElement(By.Id("stLastName"));
            stLastName.SendKeys("perez");
            var stEmail = driver.FindElement(By.Id("stEmail"));
            stEmail.SendKeys("test@test.com");
            var stPhone = driver.FindElement(By.Id("stPhone"));
            stPhone.SendKeys("9981828384");

            var stPassengersNumber = driver.FindElement(By.Id("stPassengersNumber"));
            var selestPassengersNumber = new SelectElement(stPassengersNumber);
            selestPassengersNumber.SelectByText("2");

            var stOrigin = driver.FindElement(By.Id("stOrigin"));
            stOrigin.SendKeys("Aeropuerto");
            var stArrivalDate = driver.FindElement(By.Id("stArrivalDate"));
            stArrivalDate.SendKeys("01/04/2021");
            var stArrivalAirline = driver.FindElement(By.Id("stArrivalAirline"));
            stArrivalAirline.SendKeys("Volaris");
            var stFlightNumber = driver.FindElement(By.Id("stFlightNumber"));
            stFlightNumber.SendKeys("805VF");

            var stArrivalTime = driver.FindElement(By.Id("stArrivalTime"));
            //with Keys we can add the keyboard keys in our Selenium commands... 
            stArrivalTime.SendKeys("09:15" + Keys.Alt + "p");
            var stDestiny = driver.FindElement(By.Id("stDestiny"));

            stDestiny.SendKeys("Hotel");
            var stCost = driver.FindElement(By.Id("stCost"));
            stCost.SendKeys("1500.00");

            var sendSingleTransferButton = driver.FindElement(By.XPath("//*[@id='tab-content-0']/div/div/form/button"));
            sendSingleTransferButton.Click();
            Thread.Sleep(500000);

        }

        public void fillRoundReservationForm()
        {
            var btnRoundReservation = driver.FindElement(By.XPath("//*[@id='tab-1']"));
            btnRoundReservation.Click();
            Thread.Sleep(2000);

            var stAgency = driver.FindElement(By.Id("rtAgency"));
            var selestAgency = new SelectElement(stAgency);
            selestAgency.SelectByText("American Way");

            var stName = driver.FindElement(By.Id("rtName"));
            stName.SendKeys("juanito");
            var stLastName = driver.FindElement(By.Id("rtLastName"));
            stLastName.SendKeys("perez");
            var stEmail = driver.FindElement(By.Id("rtEmail"));
            stEmail.SendKeys("test@test.com");
            var stPhone = driver.FindElement(By.Id("rtPhone"));
            stPhone.SendKeys("9981828384");

            var stPassengersNumber = driver.FindElement(By.Id("rtPassengersNumber"));
            var selestPassengersNumber = new SelectElement(stPassengersNumber);
            selestPassengersNumber.SelectByText("2");

            var stOrigin = driver.FindElement(By.Id("rtOrigin"));
            stOrigin.SendKeys("Aeropuerto");
            var stArrivalDate = driver.FindElement(By.Id("rtArrivalDate"));
            stArrivalDate.SendKeys("01/04/2021");
            var stArrivalAirline = driver.FindElement(By.Id("rtArrivalAirline"));
            stArrivalAirline.SendKeys("Volaris");
            var stFlightNumber = driver.FindElement(By.Id("rtFlightNumber"));
            stFlightNumber.SendKeys("805VF");

            var stArrivalTime = driver.FindElement(By.Id("rtArrivalTime"));
            //with Keys we can add the keyboard keys in our Selenium commands... 
            stArrivalTime.SendKeys("09:15" + Keys.Alt + "p");

            var rtDepartureDate = driver.FindElement(By.Id("rtReturnDate"));
            rtDepartureDate.SendKeys("01/04/2021");
            var rtDepartureAirline = driver.FindElement(By.Id("rtReturnAirline"));
            rtDepartureAirline.SendKeys("Volaris");
            var rtDepartureFlightNumber = driver.FindElement(By.Id("rtReturnFlightNumber"));
            rtDepartureFlightNumber.SendKeys("805VF");

            var rtDepartureTime = driver.FindElement(By.Id("rtReturnFlightTime"));
            //with Keys we can add the keyboard keys in our Selenium commands... 
            rtDepartureTime.SendKeys("09:15" + Keys.Alt + "p");

            var stDestiny = driver.FindElement(By.Id("rtDestiny"));

            stDestiny.SendKeys("Airport");
            var stCost = driver.FindElement(By.Id("rtCost"));
            stCost.SendKeys("1500.00");

            var sendSingleTransferButton = driver.FindElement(By.XPath("//*[@id='tab-content-1']/div/div/form/button"));
            sendSingleTransferButton.Click();
            Thread.Sleep(500000);

        }
    }
}
