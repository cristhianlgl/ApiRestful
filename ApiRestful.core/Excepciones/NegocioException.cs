using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.core.Excepciones
{
    public class NegocioException : Exception
    {
        public NegocioException()
        {

        }

        public NegocioException(string mensaje): base(mensaje)
        {

        }
    }
}
