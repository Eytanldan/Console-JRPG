using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game.Abstract
{
    public interface IDialogScreen
    {
        bool FinalScreen { get; }
        string Text { get; }
        Dictionary<string, IDialogScreen> NextScreens { get; }

        void EnterScreen(Entity entity);
    }
}
