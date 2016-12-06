﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FormSite.Pages
{
    class SuccessPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@id='success_body']/span")]
        private IWebElement responseSpan;

        [FindsBy(How = How.XPath, Using = "//div[@id='extraInfo']/span")]
        private IWebElement referenceNumberSpan;

        public SuccessPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public string GetResponseText()
        {
            return responseSpan.Text;
        }

        public String GetReferenceNumber()
        {
           return referenceNumberSpan.Text.Substring(13);
        }


    }
}
