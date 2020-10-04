using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasEntidades
{
    public class Categoria
    {
        int _id;
        string _codigo;
        string _nombre;
        string _observacion;
        public Categoria(int id, string codigo, string nombre, string observacion)
        {
            this._id = id;
            this._codigo = codigo;
            this._nombre = nombre;
            this._observacion = observacion;
        }
        //sobrecarga de constructores
        public Categoria(int id, string codigo, string nombre)
        {
            this._id = id;
            this._codigo = codigo;
            this._nombre = nombre;
        }
        public Categoria(int id, string nombre)
        {
            this._id = id;
            this._nombre = nombre;
        }
        public Categoria() : this(0, "", "")
        {

        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }
    }
}
