using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Interface
{
    public interface ISerialize
    {
        /// <summary>
        /// Serialize to a file
        /// </summary>
        /// <param name="filePath"></param>
        void Serialize(string filePath);
        /// <summary>
        /// Serialize memory stream
        /// </summary>
        /// <returns></returns>
        MemoryStream Serialize();
        /// <summary>
        /// Get bytes from the array
        /// </summary>
        /// <returns></returns>
        byte[] GetBytes();
    }
}
