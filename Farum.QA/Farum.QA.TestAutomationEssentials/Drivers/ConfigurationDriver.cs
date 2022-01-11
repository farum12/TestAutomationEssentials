using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow.Infrastructure;

namespace Farum.QA.TestAutomationEssentials.Drivers
{
    /// <summary>
    /// Class which represents test configuration for given Test Thread. Additionally serves as variables container.
    /// </summary>
    public class ConfigurationDriver
    {
        // Set of variables which are set from given *.srprofile
        #region VariablesSetOnStartup
        /// <summary>
        /// Variable for setting which WebDriver should be used (CHROME, FIREFOX, SAUCELABS, etc.)
        /// </summary>
        public String Browser = "CHROME";

        /// <summary>
        /// Variable for debug functions e.g. turning on/off various WriteLines.
        /// </summary>
        public Boolean DebugMode = true;

        /// <summary>
        /// Variable for turning on/off screenshot capturing; useful when testing non-browser functionalities.
        /// </summary>
        public Boolean TakeScreenshots = true;

        /// <summary>
        /// Variable for turning on/off screenshot capturing when a scenario is successful; useful when we want to ensure with SS that a scenario was successful.
        /// </summary>
        public Boolean TakeScreenshotsOnSuccess = false;

        #endregion

        /// <summary>
        /// Base URL for application instance.
        /// </summary>
        public String SeleniumBaseUrl => "https://www.saucedemo.com/";

        /// <summary>
        /// Base URL for API requests.
        /// </summary>
        public String APIBaseUrl => "";

        private readonly ISpecFlowOutputHelper _outputHelper;

        public ConfigurationDriver(ISpecFlowOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            BuildConfiguration();
        }

        /// <summary>
        /// Sets configuration variables. Values are taken form current *.srprofile.
        /// </summary>
        public void BuildConfiguration()
        {
            if(Environment.GetEnvironmentVariable("browser") != null)
            {
                Browser = Environment.GetEnvironmentVariable("browser");
            } else
            {
                _outputHelper.WriteLine("[BuildConfiguration] Browser variable not defined in given srprofile!");
                throw new NotImplementedException();
            }

            if (Environment.GetEnvironmentVariable("debugMode") != null)
            {
                DebugMode = Convert.ToBoolean(Environment.GetEnvironmentVariable("debugMode"));
            }
            else
            {
                _outputHelper.WriteLine("[BuildConfiguration] DebugMode variable not defined in given srprofile. Using default.");
            }

            if (Environment.GetEnvironmentVariable("takeScreenshotOnSuccess") != null)
            {
                TakeScreenshotsOnSuccess = Convert.ToBoolean(Environment.GetEnvironmentVariable("takeScreenshotOnSuccess"));
            }
            else
            {
                _outputHelper.WriteLine("[BuildConfiguration] takeScreenshotOnSuccess variable not defined in given srprofile. Using default.");
            }
        }
    }
}
