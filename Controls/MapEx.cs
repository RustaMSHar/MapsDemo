using MapsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsDemo.Controls
{
    public class MapEx : Microsoft.Maui.Controls.Maps.Map
    {
        public List<MapPin> CustomPins
        {
            get { return (List<MapPin>)GetValue(CustomPinsProperty); }
            set { SetValue(CustomPinsProperty, value); }
        }

        public static readonly BindableProperty CustomPinsProperty = BindableProperty.Create(nameof(CustomPins), typeof(List<MapPin>), typeof(MapEx), null);
    }
}
