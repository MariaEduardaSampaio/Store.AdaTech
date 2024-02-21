namespace Store.AdaTech.Domain.Responses
{
    public class ErroResponse
    {
        public ErroResponse(string detalhes, int statusCode)
        {
            Detalhes = detalhes;
            StatusCode = statusCode;
        }

        public string Detalhes { get; set; }
        public int StatusCode { get; set; }

    }
}
