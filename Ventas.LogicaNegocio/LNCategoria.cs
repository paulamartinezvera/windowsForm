using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Datos;
using VentasEntidades;

namespace Ventas.LogicaNegocio
{
    public class LNCategoria
    {
        public List<Categoria> Listar()
        {
            DaoCategoria daCategoria = new DaoCategoria();
            return daCategoria.Listar();
        }
        public Categoria TraerPorId(int Id)
        {
            DaoCategoria daCategoria = new DaoCategoria();
            return daCategoria.TraePorId(Id);
        }
        public int Insertar(Categoria Categoria)
        {
            DaoCategoria daCategoria = new DaoCategoria();
            return daCategoria.Insertar(Categoria);
        }
        public int Actualizar(Categoria Categoria)
        {
            DaoCategoria daCategoria = new DaoCategoria();
            return daCategoria.Actualizar(Categoria);
        }
        public int Eliminar(int Id)
        {
            DaoCategoria daCategoria = new DaoCategoria();
            return daCategoria.Eliminar(Id);
        }
    }
}
