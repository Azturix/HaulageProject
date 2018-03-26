using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Models.DataAbstract
{
    [Serializable]
    public abstract class DataEntryBase
    {
        public string Version { get; set; } = "0.0.0.0";
        /// <summary>
        /// Initializes a new instance of the <see cref="DataEntryBase"/> class.
        /// </summary>
        protected DataEntryBase()
        {

        }
        /// <summary>
        /// Deserializes the specified stream fullfilling the properties.
        /// Don't use the base if you have your own strategy
        /// </summary>
        /// <param name="stream">The stream.</param>
        protected virtual T Deserialize<T>(Stream stream) where T : DataEntryBase
        {
            using (stream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var entry = formatter.Deserialize(stream);
                return entry as T;
            }
        }
        /// <summary>
        /// Serializes this instance. 
        /// Don't inheret if you have your own strategy
        /// </summary>
        /// <returns></returns>
        public virtual Stream Serialize()
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(outStream, this);
                return outStream;
            }
        }
        /// <summary>
        /// Instances the specified stream.
        /// </summary>
        /// <typeparam name="T">Type of the instace (Inherets from DataEntryBase)</typeparam>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static T Instance<T>(Stream stream) where T : DataEntryBase, new()
        {
            var instance = new T();
            return instance.Deserialize<T>(stream);
        }
    }
}
