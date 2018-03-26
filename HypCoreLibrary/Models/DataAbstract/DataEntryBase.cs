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
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public virtual int Version { get; set; } = 0;
        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public virtual string Extension { get; set; } = "hgen";
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
        /// <typeparam name="S"></typeparam>
        /// <param name="stream">The stream.</param>
        protected virtual S Deserialize<S>(Stream stream) where S : DataEntryBase
        {
            using (stream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var entry = formatter.Deserialize(stream);
                return entry as S;
            }
        }

        /// <summary>
        /// Serializes this instance. 
        /// Don't inheret if you have your own strategy
        /// </summary>
        /// <returns></returns>
        public virtual Stream Serialize()
        {
            MemoryStream outStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(outStream, this);
            outStream.Position = 0;
            return outStream;
        }

        //
        public virtual S Copy<S>() where S : DataEntryBase, new()
        {
            return Instance(this as S);
        }

        /// <summary>
        /// Serializes this instance. 
        /// Don't inheret if you have your own strategy
        /// </summary>
        /// <returns></returns>
        public void Serialize(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (Stream stream = Serialize())
                {
                    stream.CopyTo(fs);
                }
            }
        }

        #region Instancing 
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
        /// <summary>
        /// Instances the specified file path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static T Instance<T>(string filePath) where T : DataEntryBase, new()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var instance = new T();
                return instance.Deserialize<T>(fs);
            }
        }
        /// <summary>
        /// Instances the specified file path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static T Instance<T>(T obj) where T : DataEntryBase, new()
        {
            using (var stream = obj.Serialize())
            {
                var instance = new T();
                return instance.Deserialize<T>(stream);
            }
        }

        #endregion


    }
}
