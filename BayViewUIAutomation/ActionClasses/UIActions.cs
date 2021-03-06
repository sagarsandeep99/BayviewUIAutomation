﻿using System;
using BayViewUIAutomation.GlobalParam;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace BayViewUIAutomation.ActionClasses
{
    public class UiActions
    {
        public static void GoToUrl(string url)
        {
            ObjectRepo.Driver.Navigate().GoToUrl(url);
        }

        public static void WindowMaximize()
        {
            ObjectRepo.Driver.Manage().Window.Maximize();
        }

        public static void Clear(By element)
        {
            ObjectRepo.Driver.FindElement(element).Clear();
        }

        public static void Click(By element)
        {
            ObjectRepo.Driver.FindElement(element).Click();
        }

        public static void GiveInput(By element, string input)
        {
            ObjectRepo.Driver.FindElement(element).SendKeys(input);
        }
        public static string GetText(By element)
        {
            return ObjectRepo.Driver.FindElement(element).Text;
        }

        public static int Count(By element)
        {
            return ObjectRepo.Driver.FindElements(element).Count;
        }

        public static string GetTitle()
        {
            return ObjectRepo.Driver.Title;
        }

        public static void ImplicitlyWait(int timeoutInSeconds)
        {
            ObjectRepo.Driver.Manage().Timeouts().ImplicitWait.Seconds.CompareTo(timeoutInSeconds);
        }

        public static void WebDriverWait(IWebDriver driver, By element, int timeoutInSeconds, string errorMessage)
        {
            try
            {
                if (timeoutInSeconds > 0)
                    new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
            }
            catch (Exception e)
            {
                Console.WriteLine(e + ": Unable to load " + errorMessage + "element");
                throw;
            }
        }


        static readonly Actions Actions = new Actions(ObjectRepo.Driver);
        public static void MouseHoverOver(By element)
        {
            var webElement = ObjectRepo.Driver.FindElement(element);
            Actions.MoveToElement(webElement).Perform();
        }

        public static void ScrollUp()
        {
            ((IJavaScriptExecutor)ObjectRepo.Driver).ExecuteScript("window.scroll(0,0);");
        }

        public static void ScrollDown()
        {
            ((IJavaScriptExecutor)ObjectRepo.Driver).ExecuteScript("window.scroll(0,10000);");
        }

        public static void Quit()
        {
            ObjectRepo.Driver.Quit();
        }

        public static bool TryFindElement(By by, IWebElement element)
        {
            try
            {
                ObjectRepo.Driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public static bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public static bool IsElementDisplayedAndVisible (By by, IWebElement element)
        {   
            if (TryFindElement(by, element))
            {
                element = ObjectRepo.Driver.FindElement(by);
                bool visible = IsElementVisible(element);
                if (visible)
                {
                    return visible;
                }
            }
           return false;
        }
    }
}
