using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaCapsium.ViewModels;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AvaloniaCapsium
{
    public class ViewLocator : IDataTemplate
    {
      
        public Avalonia.Controls.Control? Build(object? data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Avalonia.Controls.Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}