using System;
using System.Collections.Generic;
using System.Text;

namespace HypCoreLibrary.Structures.Geometry
{
    public class HypColor
    {

        /// <summary>
        /// Default constructor with alpha 255
        /// </summary>
        /// <param name="rIn"></param>
        /// <param name="gIn"></param>
        /// <param name="bIn"></param>
        public HypColor(byte rIn, byte gIn, byte bIn)
        {
            a = 255;
            r = rIn;
            g = gIn;
            b = bIn;
        }

        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="rIn"></param>
        /// <param name="gIn"></param>
        /// <param name="bIn"></param>
        /// <param name="aIn"></param>
        public HypColor(byte rIn, byte gIn, byte bIn, byte aIn)
        {
            a = aIn;
            r = rIn;
            g = gIn;
            b = bIn;
        }

        /// <summary>
        /// Alpha channel
        /// </summary>
        public byte a;
        /// <summary>
        /// REd channel
        /// </summary>
        public byte r;
        /// <summary>
        /// Blue channel
        /// </summary>
        public byte g;
        /// <summary>
        /// Blue channel
        /// </summary>
        public byte b;



    }
}
