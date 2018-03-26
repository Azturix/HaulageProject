using System;
using System.Collections.Generic;
using System.Text;
using HypCoreLibrary.Structures.Geometry;
using HypCoreLibrary.Interfaces;
namespace HypCoreLibrary.Interfaces
{
    public abstract class BaseGraphicsEntityData
    {
        /// <summary>
        /// ID of the entity data
        /// </summary>
        public string ID { get; private set; }
        /// <summary>
        /// Vertices
        /// </summary>

        public List<HypVector3> Vertices { get; set; }
        /// <summary>
        /// Colors of the vertices
        /// </summary>

        public List<HypColor> VerticesColor { get; set; }
        /// <summary>
        /// Triangles of the system
        /// </summary>
        public List<int> Triangles { get; set; }



    }
}
