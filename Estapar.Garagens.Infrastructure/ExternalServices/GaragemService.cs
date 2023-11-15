using Estapar.Garagens.Infrastructure.Config;
using Estapar.Garagens.Infrastructure.ExternalServices.Interfaces;
using Estapar.Garagens.Infrastructure.Models;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text.Json;

namespace Estapar.Garagens.Infrastructure.ExternalServices
{
    public class GaragemService : IGaragemService
    {
        private readonly ExternalServiceConfig _externalServiceConfig;

        public GaragemService(IOptions<ExternalServiceConfig> options)
        {
            _externalServiceConfig = options.Value;
        }

        public async Task<List<GaragemDto>> GetData()
        {
            try
            {
                var baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var formasPagamentoPath = Path.Combine(baseDirectory, _externalServiceConfig.GaragensPath);

                if (File.Exists(formasPagamentoPath))
                {
                    string json = File.ReadAllText(formasPagamentoPath);

                    return JsonSerializer.Deserialize<ConfiguiracaoGaragemDto>(json).Garagens;
                }
                else
                {
                    Console.WriteLine($"O arquivo {_externalServiceConfig.GaragensPath} não existe.");
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
                return null;
            }
        }
    }
}