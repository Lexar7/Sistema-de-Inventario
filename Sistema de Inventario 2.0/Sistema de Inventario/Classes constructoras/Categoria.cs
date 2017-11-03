using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario
{
    class Categoria
    {

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public Categoria() { }


        public Categoria(string pNombre, string pDescripcion)
        {
            this.Nombre = pNombre;
        }
    }
}
