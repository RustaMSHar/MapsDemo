﻿using MapsDemo.View;

namespace MapsDemo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
        }
    }
}
