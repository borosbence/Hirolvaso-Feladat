using System.Net.Http.Json;

namespace Hirolvaso.Repositories
{
    public enum OldalTipus
    {
        Arfolyam,
        Hatterkep,
        Hirek,
        Idojaras,
        Nevnap
    }

    public class GenericAPIRepository<T>
    {
        private const string ARFOLYAM_PATH = "https://telex.hu/api/exchangerate";
        private const string HATTERKEP_PATH = "https://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";
        private const string HIREK_PATH = "https://api.hvg.hu/blogservice/posts?limit=10";
        private const string IDOJARAS_PATH = "https://telex.hu/api/weather/Budapest";
        private const string NEVNAP_PATH = "https://api.nevnapok.eu/ma";

        private readonly string url;
        // Lejárt SSL tanúsítványok átugrása (1)
        private static HttpClientHandler handler = new HttpClientHandler();
        private static readonly HttpClient httpClient = new HttpClient(handler);

        public GenericAPIRepository(OldalTipus tipus)
        {
            url = string.Empty;
            // Lejárt SSL tanúsítványok átugrása (2)
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            switch (tipus)
            {
                case OldalTipus.Arfolyam:
                    url = ARFOLYAM_PATH;
                    break;
                case OldalTipus.Hatterkep:
                    url = HATTERKEP_PATH;
                    break;
                case OldalTipus.Hirek:
                    url = HIREK_PATH;
                    break;
                case OldalTipus.Idojaras:
                    url = IDOJARAS_PATH;
                    break;
                case OldalTipus.Nevnap:
                    url = NEVNAP_PATH;
                    break;
                default:
                    break;
            }
        }

        public async Task<T> GetValueAsync()
        {
            return await httpClient.GetFromJsonAsync<T>(url);
        }
    }
}
