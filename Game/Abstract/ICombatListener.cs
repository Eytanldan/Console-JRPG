﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstract
{
    public interface ICombatListener
    {
        void DisplayMessage(string message);
        void EndCombat();
        void PlayerDied();
    }
}
