using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrialWPF
{
    public abstract class OnPropertyChangedClass : INotifyPropertyChanged
    {
        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>Метод для вызова события извещения об изменении свойства</summary>
        /// <param name="propertyName">Изменившееся свойство. 
        /// По умолчанию используется имя вызвавшего метода</param>
        public void RaisePropertyChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void Set<T>(ref T propertyFiled, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(propertyFiled, newValue))
            {
                T oldValue = propertyFiled;
                propertyFiled = newValue;
                RaisePropertyChanged(propertyName);

                OnPropertyChanged(propertyName, oldValue, newValue);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName, object oldValue, object newValue) { }
    }
}
