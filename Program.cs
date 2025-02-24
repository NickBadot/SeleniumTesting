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

IWebDriver driver = new ChromeDriver();
driver.Url = "https://www.matchingengine.com/";

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
