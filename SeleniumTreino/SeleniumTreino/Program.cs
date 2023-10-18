namespace SeleniumTreino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var automacao = new AutomacaoWeb();

            automacao.SaucedemoLogin();

            Console.ReadLine();

            Environment.Exit(0);
        }
    }
}