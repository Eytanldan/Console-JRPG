﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model.Images
{
    public class LairEntranceBackgroundImage : IImage
    {
        private readonly string[] _imageStrings;
        private readonly int _width;
        private readonly int _height;

        public LairEntranceBackgroundImage()
        {
            _imageStrings = new[]
            {
                @"       _   _   _ _____ _   _   _ _____  _   _   _ ", 
                @"      | |_| |_| |\___/| |_| |_| |\___/_| |_| |_| |", 
                @"      |           | |    _____    | |            |", 
                @"      |           |_|   (_\|/_)   |_|            |", 
                @"     .|__________/___\  |=| |=|  /___\___________|", 
                @"    (                                           `|", 
                @"    |`. . .                                    . |", 
                @"    |     | ` .                                  |", 
                @"    |     |   | ` .   .`|[===]|`.             `  |", 
                @"    |     |   |     .   |[===]|   `.        .`   |", 
                @"    |     |` .|     |   |[===]|      ` .. ` |    |", 
                @"    |     |     ` . |. ` [===]  ` .         |.``.|", 
                @"    |     |                         ` . .  `     `", 
                @"    |     |`                                     `", 
                @"    |     | ` . . . `|`.   ...                   `", 
                @"    |     |          |   `|   |`    `|[===]|`   `|", 
                @"    |     |          |    |   | `..` |[===]| `.` |", 
                @"    |     |          |    |   |   |  |[===]|  |  |", 
                @"    |     |          |    |  ` ` .|.`       ` | `|", 
                @"    |     |          |    |.`                `.` |", 
                @"___________________________`                    .|", 
                @"___________________________                  . ` |", 
                @"|/|\|/|\|/|\|/|\|/|\|/|\|/|`.               .    |", 
                @"    |     |          |    |  `.             .    |", 
                @"    |     |          |    |    |             )   |", 
                @"    |     |          |    |    |`.         .`|   |", 
                @"    |     |          |     ` ..|   ` . . `   |   |", 
                @"    |     |          |         |      |      |   |"  
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
     * 00|       _   _   _ _____ _   _   _ _____  _   _   _ |
     * 01|      | |_| |_| |\___/| |_| |_| |\___/_| |_| |_| ||
     * 02|      |           | |    _____    | |            ||
     * 03|      |           |_|   (_\|/_)   |_|            ||
     * 04|     .|__________/___\  |=| |=|  /___\___________||
     * 05|    (                                           `||
     * 06|    |`. . .                                    . ||
     * 07|    |     | ` .                                  ||
     * 08|    |     |   | ` .   .`|[===]|`.             `  ||
     * 09|    |     |   |     .   |[===]|   `.        .`   ||
     * 10|    |     |` .|     |   |[===]|      ` .. ` |    ||
     * 11|    |     |     ` . |. ` [===]  ` .         |.``.|| 
     * 12|    |     |                         ` . .  `     `|
     * 13|    |     |`                                     `|
     * 14|    |     | ` . . . `|`.   ...                   `|
     * 15|    |     |          |   `|   |`    `|[===]|`   `||
     * 16|    |     |          |    |   | `..` |[===]| `.` ||
     * 17|    |     |          |    |   |   |  |[===]|  |  ||
     * 18|    |     |          |    |  ` ` .|.`       ` | `||
     * 19|    |     |          |    |.`                `.` ||
     * 20|___________________________`                    .||
     * 21|___________________________                  . ` ||
     * 22||/|\|/|\|/|\|/|\|/|\|/|\|/|`.               .    ||
     * 23|    |     |          |    |  `.             .    ||
     * 24|    |     |          |    |    |             )   ||
     * 25|    |     |          |    |    |`.         .`|   ||
     * 26|    |     |          |     ` ..|   ` . . `   |   ||
     * 27|    |     |          |         |      |      |   ||
     * 28|__________________________________________________|
     * 29|                                                  |
     * 30|                                                  |
     *   
     * 
     */
}
