﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model.Images
{
    public class ForestBackgroundImage : IImage
    {
        private readonly string[] _imageStrings;
        private readonly int _width;
        private readonly int _height;

        public ForestBackgroundImage()
        {
            _imageStrings = new[]
            {
                @" /\        /\         /\   /\      /\  //\\ /\ //\",
                @"//\\ /\   //\\    /\ //\\ //\\  /\//\\ //\\//\\//\",
                @"//\\//\\  //\\   //\\//\\ //\\ //\\/\\  || //\\ ||",
                @" || //\\   ||    //\\ ||   ||  //\\||       ||    ",
                @"     ||######     ||            ||       ######## ",
                @"##################################################",
                @"######      ##################################### ",
                @"_______     ______________________________________",
                @"       |===|  /\              /\        /\   /\   ",
                @"       |===| //\\  /\  /\    //\\   /\ //\\ //\\  ",
                @"_______|===|_//\\_//\\//\\___//\\__//\\//\\/\/\\_/",
                @"       |===|  ||  //\\//\\  /\||   //\\ ||//\\| //",
                @"     ##|===|##     ||  ||  //\\     ||    //\\/\//",
                @"   ####|===|#####          //\\            ||//\\|",
                @"  #####|===|#########       || ########      //\\ ",
                @"   ####|===|#############################     ||  ",
                @"     ##|===|##############################      /\",
                @"_______|   |__________      ###############    //\",
                @"/\   ##     ##         `.       ############   //\",
                @"/\\   ###  ###########     ` ..##############   ||",
                @"/\\    #############           ############## /\  ",
                @"|| /\   #########              ##############//\\ ",
                @"__//\\________________         ##############//\\ ",
                @"  //\\  /\             `.      ###############||/\",
                @" /\||  //\\    /\    /\    ` .. /\ /\      /\  //\",
                @"//\\   //\\/\ //\\  //\\  /\   //\\/\\ /\ //\\ //\",
                @"//\\    ||//\\//\\  //\\ //\\  //\\/\\//\\//\\  ||",
                @" ||       //\\ ||    ||  //\\   || || //\\ ||     "
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
     *    |________|__________|_________|_________|_________|
     * 00| /\        /\         /\   /\      /\  //\\ /\ //\|
     * 01|//\\ /\   //\\    /\ //\\ //\\  /\//\\ //\\//\\//\|
     * 02|//\\//\\  //\\   //\\//\\ //\\ //\\/\\  || //\\ |||
     * 03| || //\\   ||    //\\ ||   ||  //\\||       ||    |
     * 04|     ||######     ||            ||       ######## |
     * 05|##################################################|
     * 06|######      ##################################### |
     * 07|_______     ______________________________________|
     * 08|       |===|  /\              /\        /\   /\   |
     * 09|       |===| //\\  /\  /\    //\\   /\ //\\ //\\  |
     * 10|_______|===|_//\\_//\\//\\___//\\__//\\//\\/\/\\_/|
     * 11|       |===|  ||  //\\//\\  /\||   //\\ ||//\\| //|
     * 12|     ##|===|##     ||  ||  //\\     ||    //\\/\//|
     * 13|   ####|===|#####          //\\            ||//\\||
     * 14|  #####|===|#########       || ########      //\\ |
     * 15|   ####|===|#############################     ||  |
     * 16|     ##|===|##############################      /\|
     * 17|_______|   |__________      ###############    //\|
     * 18|/\   ##     ##         `.       ############   //\|
     * 19|/\\   ###  ###########     ` ..##############   |||
     * 20|/\\    #############           ############## /\  |
     * 21||| /\   #########              ##############//\\ |
     * 22|__//\\________________         ##############//\\ |
     * 23|  //\\  /\             `.      ###############||/\|
     * 24| /\||  //\\    /\    /\    ` .. /\ /\      /\  //\|
     * 25|//\\   //\\/\ //\\  //\\  /\   //\\/\\ /\ //\\ //\|
     * 26|//\\    ||//\\//\\  //\\ //\\  //\\/\\//\\//\\  |||
     * 27| ||       //\\ ||    ||  //\\   || || //\\ ||     |
     * 28|__________________________________________________|
     * 29|                                                  |
     * 30|                                                  |
     *   
     * 
     */
}
