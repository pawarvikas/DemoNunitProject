using Microsoft.Playwright;

namespace DemoNunitProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task Test2() {
            using var playwright = await Playwright.CreateAsync();

            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            }) ;

            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://demo.orangecrm.com/");
            await page.ClickAsync("id=LoginButton");
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "evi1.jpg"
            });
            //var isExit = await page.ILocator("text='   Welcome, Demo Account!'");
            var isExits = await page.Locator("text='Welcome, Demo Account!'").IsVisibleAsync();
            Console.WriteLine("Output is :");
            Console.WriteLine(isExits);
            Assert.IsTrue(isExits);
            //await page.FillAsync()
        
        }
    }
}