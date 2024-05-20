using MapsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Maps;

namespace MapsDemo.Controls
{
    public class CustomMap : Microsoft.Maui.Controls.Maps.Map
    {
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<CustomPin>), typeof(CustomMap), null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<CustomPin> ItemsSource
        {
            get => (IEnumerable<CustomPin>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var map = bindable as CustomMap;
            if (map != null)
            {
                map.Pins.Clear();
                var pins = newValue as IEnumerable<CustomPin>;
                if (pins != null)
                {
                    foreach (var pin in pins)
                    {
                        map.Pins.Add(pin);
                    }
                }
            }
        }
    }
}
