using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace DevsuE2E
{
    [TestFixture]
    public class buyFlow
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            //get into the web page and maximize the windows
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.Manage().Window.Maximize();
        }

        [Test, Order(1)]
        public void AddProduct1()
        {
            //use a variable for wait to an element is visible
            var stay = driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Find and saved and  element in a variable
            IWebElement phoneCategory = driver.FindElement(By.XPath("/html/body/div[5]/div/div[1]/div/a[2]"));
            // click on element finded
            phoneCategory.Click();
            //wait for element is visible
            _ = stay;
            //Find and saved and  element in a variable
            var nexux6 = driver.FindElement(By.PartialLinkText("Nexus 6"));
            // click on element finded
            nexux6.Click();
            //wait for element is visible
            _ = stay;
            //Find and saved and  element in a variable
            IWebElement addToCart = driver.FindElement(By.LinkText("Add to cart"));
            // click on element finded
            addToCart.Click();
            //Checking if all steps are OK
            Assert.Pass();
        }

        [Test, Order(2)]
        public void AddProduct2()
        {
            //use a var stay for wait to an element is visible
            var stay = driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Find element and click on it, other way to find and click without saved it in a variable
            driver.FindElement(By.XPath("/html/body/div[5]/div/div[1]/div/a[3]")).Click();
            //wait for element is visible
            _ = stay;
            //Find element and click on it, other way to find and click without saved it in a variable
            driver.FindElement(By.PartialLinkText("Dell i7 8gb")).Click();
            //wait for element is visible
            _ = stay;
            //Find element and click on it, other way to find and click without saved it in a variable
            driver.FindElement(By.LinkText("Add to cart")).Click();
            //Checking if all steps are OK
            Assert.Pass();
        }


        public void ViewCart()
        {

            //use a var stay for wait to an element is visible
            var stay = driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Find element and click on it, other way to find and click without saved it in a variable
            driver.FindElement(By.XPath("/html/body/nav/div[1]/ul/li[4]/a")).Click();
            //use a var stay for wait to an element is visible
            _ = stay;
            //Validate if the element is present
            driver.FindElement(By.Id("page-wrapper"));
        }

        [Test, Order(3)]
        public void BuyProduct()
        {
            //use a var stay for wait to an element is visible
            var stay = driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //call methond view cart
            ViewCart();
            //use a var stay for wait to an element is visible
            _ = stay;
            //find and click element for placing order
            IWebElement btPlaceOrder = driver.FindElement(By.XPath("/html/body/div[6]/div/div[2]/button"));
            btPlaceOrder.Click();
            //use a var stay for wait to an element is visible
            _ = stay;
            //Find and complete the elements for the form
            IWebElement nameTxtBox = driver.FindElement(By.Id("name"));
            nameTxtBox.SendKeys("Johan Guzmán");
            IWebElement countryTxtBox = driver.FindElement(By.Id("country"));
            countryTxtBox.SendKeys("Dominican Republic");
            IWebElement cityTxtBox = driver.FindElement(By.Id("city"));
            cityTxtBox.SendKeys("Santo Domingo");
            IWebElement ccTxtBox = driver.FindElement(By.Id("card"));
            ccTxtBox.SendKeys("378282246310005");
            IWebElement monthTxtBox = driver.FindElement(By.Id("month"));
            monthTxtBox.SendKeys("November");
            IWebElement yearTxtBox = driver.FindElement(By.Id("year"));
            yearTxtBox.SendKeys("2023");
            //summit the form
            IWebElement btok = driver.FindElement(By.XPath("//*[@id=\"orderModal\"]/div/div/div[3]/button[2]"));
            btok.Click();
            //use a var stay for wait to an element is visible
            _ = stay;
            //Validate if the form is completed correctly
            IWebElement msg = driver.FindElement(By.XPath("/html[1]/body[@class=\"modal-open stop-scrolling\"]/div[@class=\"sweet-alert  showSweetAlert visible\"]/h2[1]"));
            //string msg2 = msg.Text;
            Assert.That(msg.Text, Is.EqualTo("Thank you for your purchase!"));
            IWebElement okbt = driver.FindElement(By.CssSelector("button.confirm.btn.btn-lg.btn-primary"));
            okbt.Submit();
            //close brower to end the test
           //Close();
            Assert.Pass();

        }

        [OneTimeTearDown]
        public void Close()
        {

            driver.Close();
        }

    }
}
