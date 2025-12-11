using System;
using System.Collections;
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
        private static Dictionary<Enum, Key> keycodeToKey = new Dictionary<Enum, Key>();
        private static Dictionary<Key, bool> keyToValue = new Dictionary<Key, bool>();

        public static void KeyDown(object sender, KeyEventArgs e)
        {
                // Verifier les touches qui ne sont plus presser
                // On peut pas faire un for i puis keycodeToKey[i] car enum
                foreach (KeyValuePair<Enum, Key> element in keycodeToKey)
                {
                    if (e.Key == element.Value)
                    {
                        keyToValue[e.Key] = false;
                    }
                }
        }

        public static void KeyUp(object sender, KeyEventArgs e)
        {
                // Verifier les touches qui ne sont plus presser
                // On peut pas faire un for i puis keycodeToKey[i] car enum
                foreach (KeyValuePair<Enum, Key> element in keycodeToKey)
                {
                    if (e.Key == element.Value)
                    {
                        keyToValue[e.Key] = true;
                    }
                }
        }

        public static bool IsActionActive(Enum action)
        {
            Key key = keycodeToKey[action];
            return keyToValue[key];
        }

        public static void BindKey(Enum keyCode, Key key)
        {
            keycodeToKey.Add(keyCode, key);
            keyToValue.Add(key, false);
        }

        public static void ChangeKey(Enum keyCode, Key newKey)
        {
            // On récupère l'anccienne touche important pour modifier le deuxieme dico
            Key key = keycodeToKey[keyCode];

            // Changer le premier dico
            keycodeToKey[keyCode] = newKey;

            // Pour le deuxieme dico, il faut changer la clé
            keyToValue.Remove(key);
            // On peut mtn recreer une pair
            keyToValue.Add(newKey, false);
        }

    }
}
