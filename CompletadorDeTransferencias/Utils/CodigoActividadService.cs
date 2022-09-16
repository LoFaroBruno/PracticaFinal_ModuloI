using System.Threading.Tasks;
using System.Net.Http;
using BusinessModel.Modelos;

namespace CompletadorDeTransferencias.Utils
{
    public static class CodigoActividadService
    {
        internal static async Task<string> GetCodigoActividad(string CUIL)
        {
            HttpClient client = new HttpClient();
            string requestUrl = $"https://localhost:44334/api/Personas1?cuil={CUIL}";
            Persona persona = new Persona();
            HttpResponseMessage response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                persona = await response.Content.ReadAsAsync<Persona>();
            }
            return persona.CodActividad.Codigo;
        }
    }
}
