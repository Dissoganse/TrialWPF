using System.ComponentModel;
using System.Windows;

namespace TrialWPF
{
    /// <summary>Класс базовой ViewModel.</summary>
    /// <remarks>Дополнен свойствами, позволяющими определить режим в котором находится приложение.</remarks>
    public abstract class ViewModelBase : BaseInps
    {
        /// <summary>Возвращает <see langword="true"/>, если приложение в Режиме Времени Разработки.</summary>
        public static bool IsDesignModeStatic { get; } = DesignerProperties.GetIsInDesignMode(new DependencyObject());

        /// <summary>Возвращает <see langword="true"/>, если приложение в Режиме Времени Разработки.</summary>
        public bool IsDesignMode => IsDesignModeStatic;
    }

}
