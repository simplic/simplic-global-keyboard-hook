using System;
using System.Windows;
using System.Windows.Input;

namespace Simplic.GlobalKeyboardHook
{
    public static class MoveFocusBackHook
    {
        private static Key _key;

        public static void Setup(Key key = Key.Oem5)
        {
            EventManager.RegisterClassHandler(typeof(Window),
            Keyboard.KeyDownEvent, new KeyEventHandler(keyUp), true);
            _key = key;
        }

        private static void keyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == _key)
            {
                var tRequest = new TraversalRequest(FocusNavigationDirection.Previous);
                var keyboardFocus = Keyboard.FocusedElement as UIElement;

                if (keyboardFocus != null)
                {
                    keyboardFocus.MoveFocus(tRequest);
                }

                e.Handled = true;
            }
        }
    }
}