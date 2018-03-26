using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Interface
{
    /// <summary>
    /// Deserialize interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDeserialize<T>
    {
        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="stream">stream data</param>
        /// <returns></returns>
        T Deserialize(Stream stream);

        /// <summary>
        /// Deserialize the data
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <returns></returns>
        T Deserialize(byte[] bytes);

        /// <summary>
        /// Deserialize from a path
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        T Deserialize(string filePath);

    }

    public interface IDeserialize2
    {
        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="stream">stream data</param>
        /// <returns></returns>
        void Deserialize(Stream stream);

    }
}
