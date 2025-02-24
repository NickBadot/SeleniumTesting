/*
 * Visit https://www.matchingengine.com/
 Expand ‘Modules’ in the header section
 Click ‘Repertoire Management Module’ from the menu
 Scroll to the ‘Additional Features’ section
 Click ‘Products Supported’
 Assert on the list of supported products under the heading ‘There are several types of
Product Supported:’
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumTesting
{
    class SeleniumTesting
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.matchingengine.com/";

            driver.FindElement(By.LinkText("Modules")).Click();
            Thread.Sleep(3000);  // wait for the menu  to load
            driver.FindElement(By.LinkText("Repertoire Management Module")).Click();


            //Use a CSS selector for 'Additional Features' section + use Actions class to scroll to the element
            IWebElement additionalFeatures = driver.FindElement(By.CssSelector(
                "div[class='vc_row wpb_row vc_row-fluid vc_custom_1661355414511'] h2[class='vc_custom_heading']"));
            Actions scroller = new Actions(driver);
            scroller.MoveToElement(additionalFeatures).Perform();


        }
    }
}


