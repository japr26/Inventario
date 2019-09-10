using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mardom.Utilidades
{

    public class MiExcepcion : Exception
    {
        public MiExcepcion(string msn) : base(msn)
        {

        }
    }
}