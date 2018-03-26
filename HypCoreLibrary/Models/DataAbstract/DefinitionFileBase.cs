using HypCoreLibrary.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HypCoreLibrary.Models.DataAbstract
{
    /// <summary>
    /// Definition file base
    /// </summary>
    /// <seealso cref="HypCoreLibrary.Models.DataAbstract.DataEntryBase" />
    public class DefinitionFileBase : DataEntryBase
    {
        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public override string Extension { get; set; } = FileExtension.DEFINITION;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the children names.
        /// </summary>
        /// <value>
        /// The children names.
        /// </value>
        public List<string> ChildrenNames { get; set; }


        /// <summary>
        /// Gets or sets the entries names.
        /// </summary>
        /// <value>
        /// The entries names.
        /// </value>
        public List<string> EntriesNames { get; set; }



        public DefinitionFileBase() : base()
        {
            ChildrenNames = new List<string>();
            EntriesNames = new List<string>();
        }



        #region Serialize and deserialize

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns></returns>
        public override Stream Serialize()
        {
            var lines = JsonConvert.SerializeObject(this);
            var bytes = Encoding.UTF8.GetBytes(lines);
            return new MemoryStream(bytes);
        }

        /// <summary>
        /// Deserializes the specified stream.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        protected override S Deserialize<S>(Stream stream)
        {
            using (stream)
            {
                var lenght = (int)stream.Length;
                byte[] outBytes = new byte[lenght];
                stream.Read(outBytes, 0, lenght);
                return JsonConvert.DeserializeObject<S>(
                          Encoding.UTF8.GetString(outBytes));
            }
        }
        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public virtual void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                var lines = JsonConvert.SerializeObject(this);
                writer.Write(lines);
            }
        }
        /// <summary>
        /// Gets the object from file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static T GetObjectFromFile<T>(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
        }


        #endregion
    }
}
