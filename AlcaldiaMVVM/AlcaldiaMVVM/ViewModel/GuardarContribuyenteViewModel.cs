
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
//IMPORTAMOS PARA UTILIZAR COMMAND
using Xamarin.Forms;
//IMPORTAMOS CARPETA MODEL
using AlcaldiaMVVM.Model;
//IMPORTAMOS CARPETA VIEW
using AlcaldiaMVVM.View;

namespace AlcaldiaMVVM.ViewModel
{
    public class GuardarContribuyenteViewModel:Contribuyente
    {

        
        public Command Guardar { get; set; }
        public Command Ver { get; set; }
        public CRUD BASE { get; set; }

        public void IrAVer()
        {
            App.Current.MainPage = new NavigationPage(new LeerContribuyente());
        }
        public GuardarContribuyenteViewModel()
        {
            Ver = new Command(IrAVer);
            Guardar = new Command(InsertarDato);
        }
        public Contribuyente Editar { get; set; }
        public GuardarContribuyenteViewModel(Contribuyente Datos)
        {
            //CTUALIZAR
            //llenar clase
            Ver = new Command(IrAVer);
            Contribuyente Nuevo = new Contribuyente();
            this.IdContribuyente = Datos.IdContribuyente;
            this.Nombre = Datos.Nombre;
            this.Apellido = Datos.Apellido;
            this.Direccion = Datos.Direccion;
            this.DUI = Datos.DUI;
            this.NIT = Datos.NIT;
            Guardar = new Command(Actualizar);
        }

        void InsertarDato()
        {
            Contribuyente Nuevo = new Contribuyente();
            Nuevo.Nombre = this.Nombre;
            Nuevo.Apellido = this.Apellido;
            Nuevo.Direccion = this.Direccion;
            Nuevo.DUI = this.DUI;
            Nuevo.NIT = this.NIT;
            CRUD db = new CRUD();
            db.InsertarDatos(Nuevo);
            App.Current.MainPage.Navigation.PushAsync(new LeerContribuyente());
        }

        void Actualizar()
        {
            Contribuyente Nuevo = new Contribuyente();
            Nuevo.IdContribuyente = this.IdContribuyente;
            Nuevo.Nombre = this.Nombre;
            Nuevo.Apellido = this.Apellido;
            Nuevo.Direccion = this.Direccion;
            Nuevo.DUI = this.DUI;
            Nuevo.NIT = this.NIT;
            CRUD db = new CRUD();
            db.Update(Nuevo);
            App.Current.MainPage.Navigation.PushAsync(new LeerContribuyente());
        }

        public void Eliminar()
        {
            Contribuyente Nuevo = new Contribuyente();
            Nuevo.IdContribuyente = this.IdContribuyente;
            Nuevo.Nombre = this.Nombre;
            Nuevo.Apellido = this.Apellido;
            Nuevo.Direccion = this.Direccion;
            Nuevo.DUI = this.DUI;
            Nuevo.NIT = this.NIT;
            CRUD db = new CRUD();
            db.Delete(Nuevo);
            App.Current.MainPage.Navigation.PushAsync(new LeerContribuyente());
        }
    }
}
