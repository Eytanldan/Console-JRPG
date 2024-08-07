﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game.Abstract
{
    public interface IScene
    {
        Zone SceneZone { get; }
        Vector3 StartingPosition { get; }
        
        void PopulateZone();
    }
}
