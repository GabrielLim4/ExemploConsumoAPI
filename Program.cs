using Refit;

namespace ExemploConsumoAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br/");

                Console.WriteLine("Informe seu CEP: ");
                string cepInformado = Console.ReadLine().ToString();

                Console.WriteLine($"Consultando informações do CEP {cepInformado}");

                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.WriteLine($"\n CEP: {address.Cep} " +
                                  $"\n Rua: {address.Logradouro} " +
                                  $"\n Bairro: {address.Bairro}" +
                                  $"\n Cidade: {address.Localidade}" +
                                  $"\n DDD: {address.Ddd}"); 
                            

            }catch (Exception ex)
            {
                Console.WriteLine($"Erro na consulta do CEP: {ex.Message}");
            }
        }
    }
}