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
        private const string ARFOLYAM_PATH = "https://infojegyzet.hu/webszerkesztes/php/valuta/api/v1/arfolyam";
        private const string HATTERKEP_PATH = "https://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";
        private const string HIREK_PATH = "https://api.hvg.hu/blogservice/posts?limit=40";
        private const string IDOJARAS_PATH = "https://api.infojegyzet.hu/idojaras";
        private const string NEVNAP_PATH = "https://api.nevnapok.eu/ma";

        private readonly string url;
        // static --> 1 példány készül belőle

        // Lejárt SSL tanúsítványok esetén, figyelmen kívül hagyás (1)
        private static HttpClientHandler handler = new HttpClientHandler();
        private static readonly HttpClient httpClient = new HttpClient(handler);

        // Nem lejárt SSL tanúsítványok esetén: 
        // private static readonly HttpClient httpClient = new HttpClient();

        public GenericAPIRepository(OldalTipus tipus)
        {
            url = string.Empty;
            // Lejárt SSL tanúsítványok esetén, figyelmen kívül hagyás (2)
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
            }
        }

        public async Task<T> GetValueAsync()
        {
            return await httpClient.GetFromJsonAsync<T>(url);
        }
    }
}
