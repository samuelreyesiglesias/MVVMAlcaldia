
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
///NOTA IMPORTANTE: PUEDES ELIMINAR TODO LO QUE APARECE EN VERDE... NO HAY NINGUN INCONVENIENTE...
///SON SOLO COMENTARIOS QUE SON IGNORADOS POR EL COMPILADOR...ESCRIBI BASTANTES COMENTARIOS DE 
///MANERA QUE SE TE FACILITE LA COMPRENSION DEL CODIGO..///////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
//DESCARGAMOS EL PAQUETE NUGET sqlite-net-pcl
//LUEGO IMPORTAMOS PAQUETE SQLITE
using SQLite;

namespace AlcaldiaMVVM.Model
{
    //AQUI ESPECIFICAMOS QUE NUESTRA CLASE FUNCIONA COMO UNA TABLA EN 
    //NUESTRA BASE DE DATOS SQLITE
    [Table(nameof(Contribuyente))]

    //ESTE EJEMPLO FUNCIONA IGUAL PARA CUALQUIER OTRO CASO, ES DECIR
    //PARA REGISTRAR DATOS DE CUALQUIER OTRO TIPO DE ENTIDAD DEBES UTILIZAR
    //EL MISMO ESQUEMA
    public class Contribuyente: ModeloBase
    {
        /* AQUI ESPECIFICAS QUE LA PROPIEDAD IdContribuyente sera el
        CAMPO AUTOINCREMENTABLE Y PRIMARIO DE NUESTRA TABLA 
        */
 
        private int _IdContribuyente;
        [AutoIncrement, PrimaryKey]
        public int IdContribuyente
        {
            get { return _IdContribuyente; }
            set { _IdContribuyente = value; OnPropertyChanged(); }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; OnPropertyChanged(); }
        }

        private string _Apellido;

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; OnPropertyChanged(); }
        }

        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; OnPropertyChanged(); }
        }

        private string _DUI;

        public string DUI
        {
            get { return _DUI; }
            set { _DUI = value; OnPropertyChanged(); }
        }

        private string _NIT;

        public string NIT
        {
            get { return _NIT; }
            set { _NIT = value; OnPropertyChanged(); }
        }

    }
}
