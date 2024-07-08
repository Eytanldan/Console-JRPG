using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstract
{
    public interface IImage
    {
        IEnumerable<string> ImageStrings { get; }
        int Width { get; }
        int Height { get; }
    }
}
