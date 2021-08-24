using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrialWPF
{
    public abstract class BaseInps : INotifyPropertyChanged
    {
        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Метод для вызова события извещения об изменении свойства</summary>
        /// <param name="propertyName">Изменившееся свойство. 
        /// По умолчанию используется имя вызвавшего метода</param>
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>Метод задания значения свойству с уведовлением о его изменении.</summary>
        /// <typeparam name="T">Тип свойства.</typeparam>
        /// <param name="propertyFiled">Поле хранящее значение свойства.</param>
        /// <param name="newValue">Присваиваемое свойству значение.</param>
        /// <param name="propertyName">Имя свойства.
        /// По умолчанию используется имя метода (в том числе геттера свойства),
        /// в котором был вызван этот метод.</param>
        protected void Set<T>(ref T propertyFiled, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(propertyFiled, newValue))
            {
                T oldValue = propertyFiled;
                propertyFiled = newValue;
                RaisePropertyChanged(propertyName);

                OnPropertyChanged(propertyName, oldValue, newValue);
            }
        }

        /// <summary>Виртуальный метод вызываемый при изменении значения свойства.</summary>
        /// <param name="propertyName">Имя свойства.</param>
        /// <param name="oldValue">Старое значение свойства.</param>
        /// <param name="newValue">Новое значение свойства.</param>
        /// <remarks>Метод служит для создания зависимостей от изменившихся свойств.</remarks>
        protected virtual void OnPropertyChanged(string propertyName, object oldValue, object newValue) { }
    }

}
