using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Habitacion
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public int huespedes { get; set; }
        public string imagen { get; set; }
        public decimal precio { get; set; }


        public void Validar()
        {
            if (string.IsNullOrEmpty(descripcion))
                throw new Exception("Descripcion es requerido");
            else if (descripcion.Length > 250)
                throw new Exception("Descripción tiene un máximo de 250 caracteres");
            
            if (huespedes==0)
                throw new Exception("Huespedes es requerido");
            else if (huespedes <= 0||huespedes>20)
                throw new Exception("Huespedes debe ser mayor a 0 y menor a 20");
            if (string.IsNullOrEmpty(imagen))
                throw new Exception("Imagen es requerido");
            if (precio == 0)
                throw new Exception("Precio es requerido");
            else if (precio <= 0)
                throw new Exception("Precio debe ser mayor a 0");
        }
    }
}
