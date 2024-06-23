﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstract
{
    public interface IEngineState : IDisposable
    {
        void ProcessInput(ConsoleKeyInfo key);
        void Activate();
        void Deactivate();
    }
}
