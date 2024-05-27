using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COSTAS_DEMANDAS.Models
{
    public class CostaModel
    {
        public int IDCOSTA { get; set; }
        public string NRO_DE_CREDITO { get; set; }
        public string ETAPA { get; set; }
        public string TIPO_DE_COSTA { get; set; }
        public DateTime FECHA_COSTA { get; set; }
        public string VALOR_DE_LA_COSTA { get; set; }
        public string TIPO_DOCUMENTO_DE_COBRO { get; set; }
        public string NRO_DE_DOCUMENTO { get; set; }
        public string NOMBRE_DEL_PROVEEDOR { get; set; }
        public string OBSERVACIONES { get; set; }
    }

}
