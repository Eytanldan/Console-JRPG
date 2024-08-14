using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model.Images
{
    public class HydraImage : IImage
    {
        private readonly string[] _imageStrings;
        private readonly int _width;
        private readonly int _height;

        public HydraImage()
        {
            _imageStrings = new[]
            {
                @"                                ",
                @"           /\      __      /\   ",
                @"       /\ /  \ ____\_\ /\ /  \  ",
                @"  /\  /  \\/\ \\__ \///  \\/\ \ ",
                @" /  \ \/\ \ / /  / /\\\/\ \ / / ",
                @" \/\ \  / // /   \ \ \\ / // /  ",
                @"    \ \ \ \\ \   / / /// // /   ",
                @"    / /  \ \\ \_/  \/// // /    ",
                @"    \ \__/             . `      ",
                @"     \             . `.  `.     ",
                @"      \           `    `   \    ",
                @"       `           `. .`   /    ",
                @"        `.              . `     ",
                @"           ` .      . `         "
            };

            _width = _imageStrings[0].Length;
            _height = _imageStrings.Length;
        }

        public IEnumerable<string> ImageStrings { get { return _imageStrings; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
    }

}
