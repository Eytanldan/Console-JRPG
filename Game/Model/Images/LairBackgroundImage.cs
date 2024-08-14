﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model.Images
{
    public class LairBackgroundImage : IImage
    {
        private readonly string[] _imageStrings;
        private readonly int _width;
        private readonly int _height;

        public LairBackgroundImage()
        {
            _imageStrings = new[]
            {
                @"___|___O___|___|___|___|___|___|___|___|___|___|__",
                @"_|___|_O_|___|___|___|__     /\      __      /\   ",
                @"_  ____O____  __|__      /\ /  \ ____\_\ /\ /  \  ",
                @"_ | | | | | | |___  /\  /  \\/\ \\__ \///  \\/\ \ ",
                @"_ | | | | | | _|__ /  \ \/\ \ / /  / /\\\/\ \ / / ",
                @"_ |_|_|9|_|_| __|_ \/\ \  / // /   \ \ \\ / // /  ",
                @"                      \ \ \ \\ \   / / /// // /   ",
                @"                      / /  \ \\ \_/  \/// // /    ", 
                @"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~~~  ___________  ~~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~~~ |           | ~~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~~~ |           | ~~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~~~ |           | ~~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~~~ |           | ~~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~~~ /           \ ~~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~~ /             \ ~~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~~ /               \ ~~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~~ /                 \ ~~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~~ /                   \ ~~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~~ /                     \ ~~~~~~~~~~~~~", 
                @"~~~~~~~~~~~ /                       \ ~~~~~~~~~~~~", 
                @"  _________/                         \__________  ", 
                @" |                                              | ", 
                @" |                                              | ", 
                @" |                                              | ", 
                @"/                                                \", 
                @"||||||||||||||||||||||[   ]|||||||||||||||||||||||"  
            };

            _width = _imageStrings[0].Length;
            _height = _imageStrings.Length;
        }

        public IEnumerable<string> ImageStrings { get { return _imageStrings; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
    }

    /*
     *              1         2         3         4         5
     *    012345678901234567890123456789012345678901234567890
     *    |_________|_________|_________|_________|_________|
     * 00|___|___O___|___|___|___|___|___|___|___|___|___|__|
     * 01|_|___|_O_|___|___|___|__     /\      __      /\   |
     * 02|_  ____O____  __|__      /\ /  \ ____\_\ /\ /  \  |
     * 03|_ | | | | | | |___  /\  /  \\/\ \\__ \///  \\/\ \ |
     * 04|_ | | | | | | _|__ /  \ \/\ \ / /  / /\\\/\ \ / / |
     * 05|_ |_|_|9|_|_| __|_ \/\ \  / // /   \ \ \\ / // /  |
     * 06|                      \ \ \ \\ \   / / /// // /   |
     * 07|                      / /  \ \\ \_/  \/// // /    |
     * 08|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|
     * 09|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|
     * 10|~~~~~~~~~~~~~~~~~  ___________  ~~~~~~~~~~~~~~~~~~|
     * 11|~~~~~~~~~~~~~~~~~ |           | ~~~~~~~~~~~~~~~~~~|
     * 12|~~~~~~~~~~~~~~~~~ |           | ~~~~~~~~~~~~~~~~~~|
     * 13|~~~~~~~~~~~~~~~~~ |           | ~~~~~~~~~~~~~~~~~~|
     * 14|~~~~~~~~~~~~~~~~~ |           | ~~~~~~~~~~~~~~~~~~|
     * 15|~~~~~~~~~~~~~~~~~ /           \ ~~~~~~~~~~~~~~~~~~|
     * 16|~~~~~~~~~~~~~~~~ /             \ ~~~~~~~~~~~~~~~~~|
     * 17|~~~~~~~~~~~~~~~ /               \ ~~~~~~~~~~~~~~~~|
     * 18|~~~~~~~~~~~~~~ /                 \ ~~~~~~~~~~~~~~~|
     * 19|~~~~~~~~~~~~~ /                   \ ~~~~~~~~~~~~~~|
     * 20|~~~~~~~~~~~~ /                     \ ~~~~~~~~~~~~~|
     * 21|~~~~~~~~~~~ /                       \ ~~~~~~~~~~~~|
     * 22|  _________/                         \__________  |
     * 23| |                                              | |
     * 24| |                                              | |
     * 25| |                                              | |
     * 26|/                                                \|
     * 27|||||||||||||||||||||||[   ]||||||||||||||||||||||||
     * 28|__________________________________________________|
     *   
     * 
     */
}
