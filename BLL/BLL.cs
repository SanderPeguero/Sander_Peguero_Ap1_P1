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

        public static bool Guardar(Entidad entidad){
            bool paso = false;
            
            return paso;
        }

        public static bool Eliminar(int Id){
            bool paso = false;
            
            return paso;
        }

        private static bool Insertar(Entidad entidad){
            bool paso = false;
            
            return paso;
        }

        private static bool Modificar(Entidad entidad){
            bool paso = false;
            
            return paso;
        }

        public static Entidad?  Buscar(int Id){ //Tipo Entidad?


        }

        public static List<Entidad> GetList(Expression<Func<Entidad, bool>> criterio){
            List<Entidad> lista = new List<Entidad>();
        }

    }
}
