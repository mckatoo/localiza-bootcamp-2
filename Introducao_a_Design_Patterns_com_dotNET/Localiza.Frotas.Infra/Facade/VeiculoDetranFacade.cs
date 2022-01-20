using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Options;

using Localiza.Frotas.Domain;

namespace Localiza.Frotas.Infra.Facade
{
    public class VeiculoDetranFacade : IVeiculoDetran
    {
        private readonly DetranOptions detranOptions;
        private IHttpClientFactory httpClientFactory;

        public IVeiculoRepository veiculoRepository;

        public VeiculoDetranFacade(
            IOptionsMonitor<DetranOptions> detranOptions,
            IHttpClientFactory httpClientFactory,
            IVeiculoRepository veiculoRepository
        )
        {
            this.detranOptions = detranOptions.CurrentValue;
            this.httpClientFactory = httpClientFactory;
            this.veiculoRepository = veiculoRepository;
        }

        public async Task AgendarVistoriaDetran(Guid veiculoId)
        {
            var veiculo = veiculoRepository.PorID(veiculoId);

            var client = httpClientFactory.CreateClient();
            if (detranOptions != null && detranOptions.BaseUrl != null)
                client.BaseAddress = new Uri(detranOptions.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            var requestModel = new VistoriaModel()
            {
                Placa = veiculo != null ? veiculo.Placa : null,
                AgendadoPara = DateTime.Now.AddDays(
                    detranOptions != null ? detranOptions.QuantidadeDiasParaAgendamento : 0
                )
            };
            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            if (detranOptions != null && detranOptions.VistoriaUri != null)
                await client.PostAsync(detranOptions.VistoriaUri, contentString);
        }
    }
}
