using NUnit.Framework;
using OpenQA.Selenium;

namespace HT1_Test
{
    public class Tests
    {

        private IWebDriver driver;
        private readonly By _inputSearch = By.XPath("//input[@class='gLFyf gsfi']");
        private readonly string _searchKeyword= "freesia";
        private readonly By _selectPictures = By.XPath("//a[contains(@href, 'freesia&source')]");
        private readonly By _selectPictur_3 = By.XPath("//div[@jsname='r5xl4']/div[3]");
       

       [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com");
            driver.Manage().Window.Maximize();
            
        }
       
        [Test]
        public void Test1()
        {
            IWebElement inputSearch = driver.FindElement(_inputSearch);
            inputSearch.SendKeys(_searchKeyword + OpenQA.Selenium.Keys.Enter);
            driver.FindElement(_selectPictures).Click();
            driver.FindElement(_selectPictur_3).Click();
            Screenshot scrin = ((ITakesScreenshot)driver).GetScreenshot();
            scrin.SaveAsFile(@"C:\Download\Image.png",ScreenshotImageFormat.Png);

            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}