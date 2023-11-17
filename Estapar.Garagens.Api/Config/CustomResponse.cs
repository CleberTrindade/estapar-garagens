namespace Estapar.Garagens.Api.Config
{
    public class CustomResponse
    {
        public CustomResponse(object data)
        {
            Sucess = true;
            Data = data;
        }

        public CustomResponse(List<string> erros, bool sucess)
        {
            Sucess = sucess;
            Erros = erros;
        }

        public bool Sucess { get; set; }
        public object Data { get; set; }
        public List<string> Erros { get; set; }        
    }
}
