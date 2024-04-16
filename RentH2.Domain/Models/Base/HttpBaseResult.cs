using Newtonsoft.Json;

namespace RentH2.Domain.Models.Base
{
    public class HttpBaseResult
    {
        public HttpBaseResult()
        {

        }

        public HttpBaseResult(string error)
        {
            Erros = new List<string> { error };
        }

        public HttpBaseResult(List<string> errors)
        {
            Erros = errors;
        }

        [JsonProperty("id")]
        public string? Id { get; set; }
        public List<string>? Erros { get; set; }
        public bool IsValid() => Erros != null ? !Erros.Any() : true;
    }
}
