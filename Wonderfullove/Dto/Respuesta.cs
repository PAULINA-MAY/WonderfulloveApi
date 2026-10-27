namespace Wonderfullove.Dto
{
    public class Respuesta
    {
        public class RespuestaDto<T>
        {
            public int Estatus { get; set; }
            public string Mensaje { get; set; } = null!;
            public T Data { get; set; } = default!;
        }
    }
}
