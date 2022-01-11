using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Farum.QA.TestAutomationEssentials.Support.Hooks
{
    /// <summary>
    /// Class which contains methods, which will be executed after each scenario.
    /// </summary>
    [Binding]
    public class AfterScenarios
    {
        private readonly Drivers.WebDriver _webDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly Drivers.ConfigurationDriver _configurationDriver;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;


    }
}
