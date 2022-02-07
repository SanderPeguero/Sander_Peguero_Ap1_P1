using System;
using Sander_Peguero_Ap1_P1.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Sander_Peguero_Ap1_P1.BLL{

    public class BLL{
        public static bool Existe(int Id){
            bool paso = false;
            
            return paso;
        }

        public static bool Guardar(Producto entidad){ // correct
            bool paso = false;
            
            return paso;
        }

        public static bool Eliminar(int Id){
            bool paso = false;
            
            return paso;
        }

        private static bool Insertar(Producto entidad){ // correct
            bool paso = false;
            
            return paso;
        }

        private static bool Modificar(Producto entidad){ // correct
            bool paso = false;
            
            return paso;
        }

        public static Producto?  Buscar(int Id){ //Tipo Entidad?

            Producto producto = new Producto();

            return producto;

        }

        public static List<Producto> GetList(Expression<Func<Producto, bool>> criterio){
            List<Producto> lista = new List<Producto>();

            return lista;
        }

    }
}
