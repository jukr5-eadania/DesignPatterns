using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPattern
{
    public class InputHandler
    {
        private Dictionary<Keys, ICommand> keybinds = new();

        public InputHandler()
        {

        }

        public void AddCommand(Keys inputKey, ICommand command)
        {
            keybinds.Add(inputKey, command);
        }

        public void Execute()
        {
            KeyboardState keyState = Keyboard.GetState();

            foreach (var pressedKey in keyState.GetPressedKeys())
            {
                if (keybinds.TryGetValue(pressedKey, out ICommand cmd))
                {
                    cmd.Execute();
                }
            }
        }
    }
}
