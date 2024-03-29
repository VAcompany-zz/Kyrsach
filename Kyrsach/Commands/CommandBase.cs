﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; 
namespace Kyrsach.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public virtual bool CanExecute(object parameter) //пожет ли команда выполняться
        {
            return true;
        }

        public abstract void Execute(object parameter);

       
    }
}
