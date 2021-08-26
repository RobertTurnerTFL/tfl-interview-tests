using System;
using System.Collections.Generic;
using System.Data;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TestAutomation.Framework.BasePages;
using TestAutomation.Framework.Helpers;
using TestAutomation.Framework.Interfaces;

namespace TestAutomation.PageObjects.Pages
{
    public class JourneyResultsPage : BasePage<JourneyResultsPage>
    {
        private ScenarioContext _scenarioContext;
        private string HeadingText = "Cycling and other options";
        
        internal JourneyResultsPage(IWebDriverManager webDriverManager,ScenarioContext scenarioContext) : base(webDriverManager)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }
        private IWebElement EditPreferences => WebDriver.FindElement(By.LinkText("Edit preferences"));
        private IWebElement FromStation => WebDriver.FindElement(By.Id("InputFrom"));
        private IWebElement ToStation => WebDriver.FindElement(By.Id("InputTo"));
        private IWebElement PlanJourneyButton => WebDriver.FindElement(By.Id("plan-journey-button"));
        private IWebElement EditJourney => WebDriver.FindElement(By.XPath("//a[@class = 'edit-journey']"));
        private IList<IWebElement> FromJourneyResults =>
            WebDriver.FindElements(By.XPath("//div[contains(@class,'summary-row clearfix disambiguating')]"));
        private IList<IWebElement> MoreThanOneLocationMatching =>
            WebDriver.FindElements(By.XPath("//div[contains(@class,'disambiguation-box')]"));
        private IList<IWebElement> JourneyOptions =>
            WebDriver.FindElements(By.XPath("//a[starts-with(@class,'journey-box')]"));

        private IWebElement PublicTransport => WebDriver.FindElement(
            By.CssSelector(
                "#option-1-heading > div.clearfix.time-boxes.time-boxes-override > div.journey-time.no-map"));

        private IWebElement NonPublicTransport =>
            WebDriver.FindElement(By.XPath("//div[@class = 'journey-row-container left-journey-options']"));
        private IList<IWebElement> StationSelection(string LinkText) => WebDriver.FindElements(
            By.PartialLinkText(LinkText));

        private IWebElement ErrorMessage => WebDriver.FindElement(By.XPath("//li[@class = 'field-validation-error']"));

        public override JourneyResultsPage WaitForPageElements()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementExists(By.LinkText("Edit preferences")));
            return this;
        }

        public void ValidateJourneyResults()
        {
            FromJourneyResults.Count.Equals(2); // To validate if two Iwebelements are returned if From or to is not displayed this step would fail
            foreach (var Element in FromJourneyResults)
            {
                //these are used to validate if the from and to station values displayed as the same as the inputted values
                var Station = Element.FindElement(By.ClassName("notranslate")).Text;
                if (Element.FindElement(By.ClassName("label")).Text.ToLower() == "from:")
                {
                    Station.Should().Be(_scenarioContext["From Station"].ToString());
                }
                else
                {
                    Station.Should().Be(_scenarioContext["To Station"].ToString());
                }
            }
        }

        public void ValidateIfMoreThanOneLocationMatchingFound()
        {
            int Count = MoreThanOneLocationMatching.Count;
            var FromStationSelect = _scenarioContext["From Station"].ToString();
            var ToStationSelect = _scenarioContext["To Station"].ToString();
            if (Count > 0)
            {
                if (StationSelection(FromStationSelect).Count > 0)
                {
                    _scenarioContext.Remove("From Station");
                    //this step will fail to get the object if the from station does not match the value from the Sceanrio context
                    _scenarioContext["From Station"] = StationSelection(FromStationSelect)[0]
                        .FindElement(By.ClassName("place-name")).Text;
                    StationSelection(FromStationSelect)[0].Click();
                }
                if(StationSelection(ToStationSelect).Count>0)
                {
                    _scenarioContext.Remove("To Station");
                    _scenarioContext["To Station"] = StationSelection(ToStationSelect)[0].FindElement(By.ClassName("place-name")).Text;
                    StationSelection(ToStationSelect)[0].Click();
                }
            }
        }

        public void ValidateIfFastestRouteIsDisplayed()
        {
            WebDriverWait.Until(
                ExpectedConditions.ElementIsVisible(
                    By.XPath("//a[(@class = 'plain-button with-icon least-walking')]")));

            Heading2Text.Equals(HeadingText);

            //creates a new table and sorts it based on duration. This is check if the fastest route is displayed to the user first
            DataTable JourneyOption = new DataTable();
            JourneyOption.Columns.Add("JourneyMode", typeof(string));
            JourneyOption.Columns.Add("Duration", typeof(int));
            foreach (var Type in JourneyOptions)
            {
                var JourneyMode = Type.FindElement(By.TagName("H4")).Text;
                if (!String.IsNullOrWhiteSpace(JourneyMode))
                {
                    var Duration = Type.FindElement(By.CssSelector("div.two-col > div.col2.journey-info")).Text;
                    JourneyOption = AddaNewRow(JourneyOption, JourneyMode, Duration);
                }
            }
            //Sort the table & copy to temp
            DataTable newTable = JourneyOption.AsEnumerable()
                .OrderBy(i => i.Field<int>("Duration"))
                .CopyToDataTable();

            //check if the unsorted table and sorted table does not have any differences.
            Common.compareDataTables(JourneyOption, newTable);

            //getlocation of Non public transport box
            int JourneyOptionsBox = NonPublicTransport.Location.Y;

            //getlocation of public transport box
            int JourneyOptionsPublicTransport = PublicTransport.Location.Y;
            
            //checks if the public transport time is greater than the nonpublic transport
            //faster mode should have lesser y location

            if (JourneyOption.Rows.Count > 0 && Common.timeInMins(PublicTransport.Text.Split("Total time:\r\n")[1]) < int.Parse(JourneyOption.Rows[0]["Duration"].ToString()))
            {
                JourneyOptionsPublicTransport.Should().BeLessThan(JourneyOptionsBox);
            }
            else
            {
                JourneyOptionsBox.Should().BeLessThan(JourneyOptionsPublicTransport);
            }
        }

        public DataTable AddaNewRow(DataTable dt,string JourneyMode,string Duration)
        {
            DataRow newRow = dt.NewRow();
            newRow["JourneyMode"] = JourneyMode;
            newRow["Duration"] = Common.timeInMins(Duration);
            dt.Rows.Add(newRow);
            newRow.AcceptChanges();
            return dt;
        }

        public string ErrorMessageDisplayedNoResultsFound() => ErrorMessage.Text;

        public void EditJourneyDetails(string fieldName,string Value)
        {
            IWebElement Field = null;
            switch (fieldName.ToLower())
            {
                case "fromstation":
                    Field = FromStation;
                    _scenarioContext.Remove("From Station");
                    _scenarioContext.Add("From Station", Value);
                    break;
                case "tostation":
                    Field = ToStation;
                    _scenarioContext.Remove("To Station");
                    _scenarioContext.Add("To Station",Value);
                    break;
            }
            Field.SendKeys(Keys.LeftShift + Keys.Home);
            Field.SendKeys(Value);
        }
        public JourneyResultsPage ClickPlanMyJourney()
        {
            PlanJourneyButton.Click();
            return new JourneyResultsPage(WebDriverManager, _scenarioContext).WaitForPageLoad();
        }
        public JourneyResultsPage ClickEditJourney()
        {
            EditJourney.Click();
            return new JourneyResultsPage(WebDriverManager, _scenarioContext).WaitForPageLoad();
        }
    }
}