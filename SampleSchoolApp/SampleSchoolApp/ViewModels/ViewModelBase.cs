﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleSchoolApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();
        public event PropertyChangedEventHandler PropertyChanged;
        public bool BackButtonVisible { get; set; } = true;
        public string ServiceModuleIPAddress = string.Empty;
        #region "Constructor"
        public ViewModelBase()
        {

        }
        #endregion
        #region "Properties"
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
            {
                properties.Add(propertyName, default(T));
            }

            var oldValue = GetValue<T>(propertyName);
            if (!EqualityComparer<T>.Default.Equals(oldValue, value))
            {
                properties[propertyName] = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
            {
                return default(T);
            }
            else
            {
                return (T)properties[propertyName];
            }
        }
        #endregion


    }
}
