using System;
using Sander_Peguero_Ap1_P1.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sander_Peguero_Ap1.Contexto;


namespace Sander_Peguero_Ap1_P1.BLL{

    public class BLL{
        public static bool Existe(int ProductoId){
           
            bool paso = false;
            Contexto contexto = new Contexto();

            paso = contexto.producto.Any(l => l.ProductoId == ProductoId);

            contexto.Dispose();
            
            return paso;

        }

        public static bool Guardar(Producto entidad){ // correct
            
            bool paso = false;

            Insertar(entidad);
            
            return paso;
        }

        public static bool Eliminar(int ProductoId){
            
            bool paso = false;
            Contexto contexto = new Contexto();

            var producto = contexto.producto.Find(ProductoId);
            contexto.producto.Remove(producto);

            contexto.Dispose();
            
            return paso;
        }

        private static bool Insertar(Producto entidad){ // correct
            
            bool paso = false;

            Contexto contexto = new Contexto();

            contexto.producto.Add(entidad);
            paso = 0 > contexto.SaveChanges();

            contexto.Dispose();
            
            return paso;
        }

        private static bool Modificar(Producto entidad){ // correct
           
            bool paso = false;
          
            
            return paso;

        }

        public static Producto  Buscar(int ProductoId){ //Tipo Entidad?

            Producto producto = new Producto();
            Contexto contexto = new Contexto();

            producto = contexto.producto.Find(ProductoId);

            contexto.Dispose();

            return producto;

        }

        public static List<Producto> GetList(Expression<Func<Producto, bool>> criterio){
           
            List<Producto> lista = new List<Producto>();
            Contexto contexto = new Contexto();

            lista = contexto.producto.Where(criterio).ToList();

            contexto.Dispose();

            return lista;

        }

    }
}
