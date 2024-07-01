using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game.Abstract
{
    public interface IScene
    {
        Player PlayerModel { get; }
        Entity PlayerEntity { get; }
        Zone SceneZone { get; }

        void PopulateZone();
    }
}
