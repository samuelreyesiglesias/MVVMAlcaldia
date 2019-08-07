using System;
using System.Collections.Generic;
using System.Text;
// IMRPOTAMOS LIBRERIAS
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlcaldiaMVVM.Model
{
    public class ModeloBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
