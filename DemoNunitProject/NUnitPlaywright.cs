using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace DemoNunitProject
{
    public class NUnitPlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://demo.orangecrm.com/");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task Test2() {
            
            
            await Page.ClickAsync("id=LoginButton");
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "evi1.jpg"
            });
            
            await Expect(Page.Locator("text='Welcome, Demo Account!'")).ToBeVisibleAsync();

            //await page.FillAsync()
            //$env:HEADED=1 and set to 0 again
            //use set headed=1 dotnet test

        }
    }
}