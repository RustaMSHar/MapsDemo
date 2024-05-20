using Microsoft.Maui.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapsDemo.Models
{
    public class MapPin : Pin
    {
        public string Id { get; set; }
        public Location Position { get; set; }
        public string IconSrc { get; set; }
        public ICommand ClickedCommand { get; set; }

        public MapPin(Action<MapPin> clicked)
        {
            ClickedCommand = new Command(() => clicked(this));
        }
    }
}
