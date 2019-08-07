
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
//IMportmos
using AlcaldiaMVVM.Model;
using AlcaldiaMVVM.ViewModel;

namespace AlcaldiaMVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuardarContribuyente : ContentPage
    {
        public GuardarContribuyente()
        {
            InitializeComponent();
        }
        public GuardarContribuyente(Contribuyente contribuyente )
        {
            InitializeComponent();
            GuardarContribuyenteViewModel objeto = new GuardarContribuyenteViewModel(contribuyente);
            BindingContext = objeto;
            Button eliminar = new Button {
                Text = "Eliminar"
            };
            eliminar.Clicked += (sender, args) =>
            {
                objeto.Eliminar();
            };
            MyForm.Children.Add(eliminar);
        }
    }
}