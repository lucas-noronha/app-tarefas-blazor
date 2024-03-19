using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string mensagem) : base(mensagem)
        {}
        
        public static void ThrowWhen(bool temErro, string mensagem)
        {
            if(temErro) 
                throw new DomainValidationException(mensagem);
        }
    }
}
