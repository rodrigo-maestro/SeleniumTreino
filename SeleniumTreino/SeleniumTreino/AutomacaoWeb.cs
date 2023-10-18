using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTreino
{
    public class AutomacaoWeb
    {
        const string url = "https://www.saucedemo.com/";

        public void SaucedemoLogin()
        {
            SaucedemoLogin("performance_glitch_user", "secret_sauce");
            SaucedemoLogin("standard_user", "secret_sauce");
            SaucedemoLogin("locked_out_user", "secret_sauce");
        }

        private void SaucedemoLogin(string usuario, string senha)
        {
            var driver = new FirefoxDriver();

            driver.Navigate().GoToUrl(url);

            var campoLogin = driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));

            var campoSenha = driver.FindElement(By.XPath("//*[@id=\"password\"]"));

            var botaoLogin = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));

            campoLogin.SendKeys(usuario);

            campoSenha.SendKeys(senha);

            DateTime startTime = DateTime.Now;

            botaoLogin.Click();

            try 
            {
                var urlEsperada = "https://www.saucedemo.com/inventory.html";

                var urlFoiAcessada = false;
                
                TimeSpan maxWaitTime = TimeSpan.FromMilliseconds(1000);

                while (DateTime.Now - startTime < maxWaitTime)
                {
                    if(driver.Url.Equals(urlEsperada))
                    {  
                        urlFoiAcessada = true; 
                        break;
                    }
                    Thread.Sleep(100);
                }

                if (urlFoiAcessada)
                {
                    Console.WriteLine("Sucesso.");
                }
                else
                {
                    try
                    {
                        Console.WriteLine("Erro em tela: " + driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3")).Text);
                    }
                    catch
                    {
                        Console.WriteLine("Demorou mais do que o tempo limite.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro INESPERADO: " + ex.Message);
            }

            driver.Quit();
        }
    }
}
