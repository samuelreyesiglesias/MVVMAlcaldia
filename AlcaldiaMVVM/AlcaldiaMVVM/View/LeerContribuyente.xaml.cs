
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
///NOTA IMPORTANTE: PUEDES ELIMINAR TODO LO QUE APARECE EN VERDE... NO HAY NINGUN INCONVENIENTE...
///SON SOLO COMENTARIOS QUE SON IGNORADOS POR EL COMPILADOR...ESCRIBI BASTANTES COMENTARIOS DE 
///MANERA QUE SE TE FACILITE LA COMPRENSION DEL CODIGO..///////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//IMORTAMOS
using AlcaldiaMVVM.Model;

namespace AlcaldiaMVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeerContribuyente : ContentPage
    {
        public LeerContribuyente()
        {
            InitializeComponent();
            CRUD datos = new CRUD();
            ListaDatos.ItemsSource = datos.LeerContribuyentes();
        }

        private void ListaDatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Contribuyente datos = new Contribuyente();
            datos = (Contribuyente)e.SelectedItem;
            Navigation.PushAsync(new GuardarContribuyente(datos));
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuardarContribuyente());
        }
    }
}