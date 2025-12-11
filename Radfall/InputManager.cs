using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Radfall
{
    internal class InputManager
    {
        public static bool right { get; private set; } = false;
        public static bool left { get; private set; } = false;
        public static bool top { get; private set; } = false;
        public static bool bottom { get; private set; } = false;
        public static void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Q)
            {
                right = true;
            }
            if (e.Key == Key.D)
            {
                left = true;
            }
            if (e.Key == Key.Z)
            {
                top = true;
            }
            if (e.Key == Key.S)
            {
                bottom = true;
            }
        }

        public static void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Q)
            {
                right = false;
            }
            if (e.Key == Key.D)
            {
                left = false;
            }
            if (e.Key == Key.Z)
            {
                top = false;
            }
            if (e.Key == Key.S)
            {
                bottom = false;
            }
        }
    }
}
