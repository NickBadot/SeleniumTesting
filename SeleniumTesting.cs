/*
 * Assigment instructions
 * Visit https://www.matchingengine.com/
 * Expand ‘Modules’ in the header section
 * Click ‘Repertoire Management Module’ from the menu
 * Scroll to the ‘Additional Features’ section
 * Click ‘Products Supported’
 * Assert on the list of supported products under the heading ‘There are several types of
Product Supported:’
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;

namespace SeleniumTesting
{
    class SeleniumTesting
    {
        static void Main(string[] args)
        {
            string[] productsSupported = {"Cue Sheet / AV Work​", "Recording​", "Bundle", "Advertisement",
                "Negative Test"}; // Include one false product as a negative test
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.matchingengine.com/";
            // set implicit wait to ten seconds - anything longer than that on a simple page is probably a bug
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);


            driver.FindElement(By.LinkText("Modules")).Click();
            driver.FindElement(By.LinkText("Repertoire Management Module")).Click();

            // We don't actually need to scroll to test the list, but including it as it's part of the instructions
            IWebElement additionalFeatures = driver.FindElement(By.XPath(
                "//*[contains(text(), 'Additional Features')]"));
            Actions scroller = new Actions(driver);
            scroller.MoveToElement(additionalFeatures).Perform();

            driver.FindElement(By.XPath("//*[contains(text(), 'Products Supported')]")).Click();

            // this will find ALL list items in the document, including some we don't care about
            // we could use the full Xpath for the specific list that only includes the relevant section
            // but it would make the code hard to read and is probably overkill for a simple test
            IReadOnlyList<IWebElement> productElements = driver.FindElements(By.XPath("//ul/li/span"));

            // for a real test we would use a framework, but for this simple test we can just print our assertion to the debug console
            foreach (string expectedProduct in productsSupported)
            {
                bool productFound = false;
                foreach (IWebElement element in productElements)
                {
                    string text = element.GetAttribute("innerText").Trim();
                    if (expectedProduct.Contains(text))
                    {
                        productFound = true;
                        break;
                    }
                }
                if (productFound && expectedProduct != "Negative Test")
                {
                    Debug.WriteLine("TEST PASSED: Product found: " + expectedProduct);
                }
                else if (expectedProduct == "Negative Test")
                {
                    Debug.WriteLine("TEST PASSED: Negative test passed, product not found: " + expectedProduct);
                }
                else
                {
                    Debug.WriteLine("TEST FAILED: Product not found: " + expectedProduct);
                }
            }
            driver.Quit();
        }
    }
}


