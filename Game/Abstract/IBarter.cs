﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game.Abstract
{
    public interface IBarter
    {
        Dictionary<IItem, int> Stock { get; }
    }
}
