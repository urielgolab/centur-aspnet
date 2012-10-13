using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public partial class Causas_Detenciones
    {
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (idObservacion!=null)
                GeneraObservacion = true;
            else
                GeneraObservacion = false;
        }
    }
}
