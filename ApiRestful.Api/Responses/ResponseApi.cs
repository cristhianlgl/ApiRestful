using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestful.Api.Responses
{
    public class ResponseApi<T>
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }

        public ResponseApi(T data, bool exito = false, string mensaje = "")
        {
            Data = data;
            Exito = exito;
            Mensaje = mensaje;
        }
    }
}
