using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Reserva
    {
        public int codigo { get; set; }
        public Habitacion habitacion { get; set; }
        public Usuario usuario { get; set; }
        public DateTime fechaRealizacion { get; set; }
        public int cantidadDias { get; set; }
        public DateTime fechaInicio { get; set; }
        public int estado { get; set; }
        public decimal total { get; set; }

        public void Validar()
        {
            
            if (cantidadDias == 0)
                throw new Exception("Cantidad de dias es requerido");
            else if (cantidadDias < 0)
                throw new Exception("La mínima Cantidad de dias aceptable es 1");

            if (DateTime.Now > fechaInicio)
                throw new Exception("La fecha ingresada debe ser mayor a la actual");
            if (total == 0)
                throw new Exception("Total es requerido");
            else if (total < 0)
                throw new Exception("El mínimo precio aceptable es 1.00");
            else if (total >= 100000000)
                throw new Exception("El máximo precio aceptable es 99999999.99");

        }
    }
}
