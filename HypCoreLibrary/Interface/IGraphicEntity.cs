using System;
using System.Collections.Generic;
using System.Text;

namespace HypCoreLibrary.Interfaces
{
    public interface IGraphicEntity
    {
        /// <summary>
        /// Unloads the graphic entity
        /// </summary>
        void Unload();
        /// <summary>
        /// Load the graphic entity
        /// </summary>
        void Load();
        /// <summary>
        /// Update the file
        /// </summary>
        void Update();
        /// <summary>
        /// Rename the entity
        /// </summary>
        void Rename();
        /// <summary>
        /// Delete data
        /// </summary>
        void Delete();
    }
}
