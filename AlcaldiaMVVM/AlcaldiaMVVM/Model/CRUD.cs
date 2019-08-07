
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
//PARA PODER CREAR LAS FUNCIONES Y METODOS QUE NOS PERMITIRAN ACCEDER A NUESTRA
//BASE DE DATOS LOCAL, NECESITAMOS IMPORTAR LA CARPETA SQLITE
using SQLite;
//IMPORTAMOS EL PAQUETE SYSTEM.IO PARA ACCEDER A LA CLASE PATH
using System.IO;
using System.Diagnostics;

namespace AlcaldiaMVVM.Model
{
    //AGREGAMOS LA PALABRA PUBLIC A NUESTRA CLASE, 
    //PARA QUE SEA ACCESIBLE DESDE LOS DEMAS ARCHIVOS
    //CUANDO IMPORTEMOS LA CARPETA MODEL EXTERNAMENTE.

    //EL NOMBRE {CRUD} PUEDE VARIAR , TU PUEDES UTILIZA CUALQUIER OTRO NOMBRE
    //QUE IDENTIFIQUE EL PROPOSITO DE LA CLASE..PODRIAS LLAMARLE COMO TU GUSTES,
    // POR EJEMPLO: CONFIGDB, DBCRUD, ACCESOABASEDEDATOS,BASEDEDATOS,DB,MYDB,MIBD,..
    //EL NOMBRE DE LA CLASE PARA MODIFICAR LOS DATOS DE LA BASE DE DATOS, PUEDE LLEVAR
    //EL NOMBRE QUE TU GUSTES Y QUE IDENTIFIQUE LO QUE HARA
    public class CRUD
    {

        //DEFINIMOS UNA PROPIEDAD DE TIPO SQLCONNECTION, ENCARGADA DE MANEJAR EL ACCESO A NUETRA BASE DE DATOS
        //El nombre Conexion puede ser cualquier nombre que identifue el proposito de la propiedad...
        // bien puedes llamarla por ejemplo : AccesoDB, Conectar, DbConf, etc.. como tu quieras
        // pero debes tomar en cuenta que el nombre que le asignes sera requerido en las funciones y metodos
        //que crearas acontinuacion
        public SQLiteConnection Conexion { get; set; }

        //CREAMOS UN CONSTRUCTOR. EL CONSTRUCTOR SE CREA UTILIZANDO LA PALABRA {PUBLIC}
        // Y LUEGO EL NOMBRE DE LA CLASE.. COMO EN ESTE CASO LA CLASE SE LLAMA {CRUD} 
        //UTILIZAMOS ESA MISMA PALABRA PARA CREAR EL CONSTRUCTOR, SI NOSOTROS HUBIERAMOS 
        //LLAMADO DIFERENTE A NUESTRA CLASE, DEBIERAMOS CREAR EL CONSTRUCTOR CON ESE 
        //MISMO NOMBRE QUE HUBIERAMOS ESPECIFICADO A LA CLASE.
        public CRUD()
        {
            //Creamos la ruta en una variable string para acceder a nuestra DB
            string RutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Alcaldia.db3");
            
            //Creamos una instancia SQLiteConnection y asignamos ese objeto a Conexion...
            //la propiedad que creamos al inicio de la clase.
            Conexion = new SQLiteConnection(RutaDB);

            //Creamos la tabla que necesitamos...en este caso necesitamos crear la tabla 
            //contribuyente...y para ello accedemos a la propiedad Conexion, esta nos 
            //permitira gestionar cada accion sobre la db
            Conexion.CreateTable<Contribuyente>();

        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\||||||||||||||
        // DE AQUI EN ADELANTE EMPEZAMOS A CREAR LOS METODOS Y FUNCIONES PARA EL CRUD
        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\|


        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        //|||||||||||||||||||||||INSERTAR DATOS|||||||||||||||||||||||||||||||||||||||
        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\\

        //El Nombre {InsertarDatos} tu puedes llamarlo como tu gustes...pero debes tomar 
        //en cuenta que el nombre que le asignes sera utilizado al momento que requieras 
        //utilizarlo en los archivos donde enviaras a insertar datos a la base de datos
        public int InsertarDatos(Contribuyente DatosContribuyente)
        //LO QUE VA ENTRE PARENTESIS SE LLAMA PARAMETROS..
        //SON DATOS QUE ENVIAMOS AL MOMENTO QUE LLAMAMOS A ESTA FUNCION.
        {
            //EL METODO RETORNA UN VALOR 1, SI EL DATO FUE GUARDADO...
            //Conexion es el objeto que nos permite realizar cualquier accion CRUD 
            //en la base de datos Insert, Delete, Update, Read... en este caso 
            //utilizamos el metodo Insert para insertar los datos que le enviaremos
            //desde donde invoquemos a este metodo..
            try
            {
                return Conexion.Insert(DatosContribuyente);
            }catch(Exception EE)
            {
                System.Diagnostics.Debug.WriteLine(EE.Message);
                int a = 1;
            }
            return 0;
        }

        public int Delete(Contribuyente DatosContribuyente)
        //LO QUE VA ENTRE PARENTESIS SE LLAMA PARAMETROS..
        //SON DATOS QUE ENVIAMOS AL MOMENTO QUE LLAMAMOS A ESTA FUNCION.
        {
            //EL METODO RETORNA UN VALOR 1, SI EL DATO FUE ELIMINADO...
            //Conexion es el objeto que nos permite realizar cualquier accion CRUD 
            //en la base de datos Insert, Delete, Update, Read... en este caso 
            //utilizamos el metodo {DELETE} para ELIMINAR los datos que le enviaremos
            //desde donde invoquemos a este metodo..
            return Conexion.Delete(DatosContribuyente);
        }


        public int Update(Contribuyente DatosContribuyente)
        //LO QUE VA ENTRE PARENTESIS SE LLAMA PARAMETROS..
        //SON DATOS QUE ENVIAMOS AL MOMENTO QUE LLAMAMOS A ESTA FUNCION.
        {
            //EL METODO RETORNA UN VALOR 1, SI EL DATO FUE ACTUALIZADO...
            //Conexion es el objeto que nos permite realizar cualquier accion CRUD 
            //en la base de datos Insert, Delete, Update, Read... en este caso 
            //utilizamos el metodo {UPDATE} para ACTUALIZAR los datos que le enviaremos
            //desde donde invoquemos a este metodo..
            return Conexion.Update(DatosContribuyente);
        }

        //AQUI DEFINIMOS EL METODO PARA LEER 1 REGISTRO ESPECIFICO DE CONTRIBUYENTE 
        //UTILIZANDO SU IdContribuyente
        public Contribuyente Leer(int IdContribuyente)
        //LO QUE VA ENTRE PARENTESIS SE LLAMA PARAMETROS..
        //SON DATOS QUE ENVIAMOS AL MOMENTO QUE LLAMAMOS A ESTA FUNCION.
        // EN ESTE CASO ENVIAMOS UN PARAMETRO DE TIPO DE ENTERO LLAMADO IdContribuyente
        {
            //EL METODO RETORNA LOS DATOS DEL CONTRIBUYENTE 
            //QUE COINCIDA CON EL Id que enviamos como Parametro

            // CONECTAMOS A LA TABLA CONTRIBUYENTE, LUEGO REALIZAMOS LA CONSULTA POR ID Y LE ESPECIFICAMS QUE NECESITAMS EL PRIMER REGISTRO QUE ENCUENTR CON ESE ID.
            return Conexion.Table<Contribuyente>().Where(i => i.IdContribuyente == IdContribuyente).FirstOrDefault();
        }


        //PON ATENCION QUE AGREGAMOS LA PALABRA LIST...porque este metodo nos retorna varios registros
        public List<Contribuyente> LeerContribuyentes()
        //LO QUE VA ENTRE PARENTESIS SE LLAMA PARAMETROS..
        // EN ESTE CASO NO HAY NINGUN PARAMETRO , PORQUE ESTAN VACIOS LOS PARENTESIS
        {
            //EL METODO RETORNA LOS RGISTROS DE LOS CONTRIBUYENTES QUE SE HAN REGISTRADO 

            // CONECTAMOS A LA TABLA CONTRIBUYENTE, solicitaoms los datos y los convertimos a una lista.
            return Conexion.Table<Contribuyente>().ToList();
        }




    }
}
