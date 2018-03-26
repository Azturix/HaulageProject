using System;
using System.Collections.Generic;
using System.Text;

namespace HypCoreLibrary.Structures.Geometry
{
    /// <summary>
    /// Vector used also as point
    /// </summary>
    [Serializable]
    public class HypVector3
    {
        /// <summary>
        /// Zero constructor
        /// </summary>
        public HypVector3()
        {

        }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="xIn"></param>
        /// <param name="yIn"></param>
        /// <param name="zIn"></param>
        public HypVector3(float xIn, float yIn, float zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
        }
        /// <summary>
        /// X direction of the vector
        /// </summary>
        public float x;
        /// <summary>
        /// X direction of the vector
        /// </summary>
        public float y;
        /// <summary>
        /// Y direction of the color
        /// </summary>
        public float z;
    }
}
