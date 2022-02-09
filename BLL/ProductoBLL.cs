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
           
            bool Existe = false;
            Contexto contexto = new Contexto();

            Existe = contexto.producto.Any(l => l.ProductoId == ProductoId);

            contexto.Dispose();
            
            return Existe;

        }

        public static bool Existe(string Descripcion){

            bool Existe = false;
            Contexto contexto = new Contexto();

            Existe = contexto.producto.Any(l => l.Descripcion == Descripcion);

            contexto.Dispose();

            return Existe;

        }

        public static bool Guardar(Producto entidad){ // correct
            
            bool successful = false;

            successful = Insertar(entidad);
            
            return successful;
        }

        public static bool Eliminar(int ProductoId){
            
            bool successful = false;
            Contexto contexto = new Contexto();

            Producto producto = contexto.producto.Find(ProductoId);

            if(producto != null){
                
                contexto.producto.Remove(producto);
                successful = true;

            }

            contexto.Dispose();
            
            return successful;
        }

        private static bool Insertar(Producto entidad){ // correct
            
            bool successful = false;
            Contexto contexto = new Contexto();
            
            contexto.producto.Add(entidad);
            successful = 0 > contexto.SaveChanges();

            contexto.Dispose();
            
            return successful;
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
