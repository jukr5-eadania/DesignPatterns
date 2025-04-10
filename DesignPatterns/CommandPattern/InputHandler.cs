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
        private Dictionary<Keys, ICommand> keybindsUpdate = new();
        private Dictionary<Keys, ICommand> keybindsButtonDown = new();

        private Stack<ICommand> executedCommands = new();
        private Stack<ICommand> unExecutedCommands = new();

        private KeyboardState previousKeyState;

        public void AddUpdateCommand(Keys inputKey, ICommand command)
        {
            keybindsUpdate.Add(inputKey, command);
        }

        public void AddButtonDownCommand(Keys inputKey, ICommand command)
        {
            keybindsButtonDown.Add(inputKey, command);
        }

        public void Execute()
        {
            KeyboardState keyState = Keyboard.GetState();

            foreach (var pressedKey in keyState.GetPressedKeys())
            {
                if (keybindsUpdate.TryGetValue(pressedKey, out ICommand cmd))
                {
                    cmd.Execute();
                }
                if (!previousKeyState.IsKeyDown(pressedKey) && keyState.IsKeyDown(pressedKey))
                {
                    if (keybindsButtonDown.TryGetValue(pressedKey, out ICommand cmdBd))
                    {
                        cmdBd.Execute();
                        executedCommands.Push(cmdBd);
                        unExecutedCommands.Clear();
                    }

                    if (pressedKey == Keys.P)
                    {
                        Undo();
                    }
                    if (pressedKey == Keys.O)
                    {
                        Redo();
                    }
                }
            }
            previousKeyState = keyState;
        }

        private void Undo()
        {
            if (executedCommands.Count > 0)
            {
                ICommand commandToUndo = executedCommands.Pop();
                commandToUndo.Undo();
                unExecutedCommands.Push(commandToUndo);
            }
        }

        public void Redo()
        {
            if (unExecutedCommands.Count > 0)
            {
                ICommand commandToRedo = unExecutedCommands.Pop();
                commandToRedo.Execute();
                executedCommands.Push(commandToRedo);
            }
        }
    }
}
