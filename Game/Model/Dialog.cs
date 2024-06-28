﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model
{
    public class Dialog : IDialog
    {
        public IDialogScreen FirstScreen { get; private set; }

        public Dialog(IDialogScreen firstScreen)
        {
            FirstScreen = firstScreen;
        }
    }
}
