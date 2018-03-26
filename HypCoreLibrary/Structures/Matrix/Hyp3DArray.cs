using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Structures.Matrix
{
    /// <summary>
    /// 3D array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Hyp3DArray<T> : HypArrayBase<T>
    {

        /// <summary>
        /// Gets the size of the m.
        /// </summary>
        /// <value>
        /// The size of the m.
        /// </value>
        public int MSize { get; private set; }

        /// <summary>
        /// Gets the size of the n.
        /// </summary>
        /// <value>
        /// The size of the n.
        /// </value>
        public int NSize { get; private set; }

        /// <summary>
        /// Gets the size of the o.
        /// </summary>
        /// <value>
        /// The size of the o.
        /// </value>
        public int OSize { get; private set; }


        /// <summary>
        /// Empty constructor
        /// </summary>
        public Hyp3DArray() : base()
        {

        }
        /// <summary>
        /// Constructor with dimensions and empty data
        /// </summary>
        /// <param name="m_size">M dimension</param>
        /// <param name="n_size">N dimension</param>
        public Hyp3DArray(int m_size, int n_size, int o_size) : base(new int[] { m_size, n_size, o_size })
        {
            MSize = m_size;
            NSize = n_size;
            OSize = o_size;
        }
        /// <summary>
        /// Constructor with predefined data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="m_size"></param>
        /// <param name="n_size"></param>
        public Hyp3DArray(T[] data, int m_size, int n_size, int o_size) : base(data, new int[] { m_size, n_size, o_size })
        {
            MSize = m_size;
            NSize = n_size;
            OSize = o_size;
        }


        /// <summary>
        /// Load from file path
        /// </summary>
        /// <param name="filePath"></param>
        public Hyp3DArray(string filePath) : base(filePath)
        {
            MSize = GetDimensions()[0];
            NSize = GetDimensions()[1];
            OSize = GetDimensions()[2];
        }

        /// <summary>
        /// Load from stream
        /// </summary>
        /// <param name="stream">strem</param>
        public Hyp3DArray(Stream stream) : base(stream)
        {
            MSize = GetDimensions()[0];
            NSize = GetDimensions()[1];
            OSize = GetDimensions()[2];
        }
        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="bytes"></param>
        public Hyp3DArray(byte[] bytes) : base(bytes)
        {

            MSize = GetDimensions()[0];
            NSize = GetDimensions()[1];
            OSize = GetDimensions()[2];
        }


        /// <summary>
        /// Get the value according to subscripts
        /// </summary>
        /// <param name="subscripts">i,j,k subscripts</param>
        /// <returns></returns>
        public override T GetValue(params int[] subscripts)
        {
            return Data[subscripts[0]
                        + subscripts[1] * MSize
                        + subscripts[2] * MSize * NSize];
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns></returns>
        public override T GetValue(int idx)
        {
            return Data[idx];
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        public override void SetValue(T value, params int[] subscripts)
        {
            Data[subscripts[0] + subscripts[1] * MSize + subscripts[2] * MSize * NSize] = value;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="idx">The index.</param>
        public override void SetValue(T value, int idx)
        {
            Data[idx] = value;
        }
        /// <summary>
        /// Copy a new instance
        /// </summary>
        /// <returns></returns>
        public override HypArrayBase<T> Copy()
        {
            var data = new T[Data.Length];
            Array.Copy(Data, data, Data.Length);
            return new Hyp3DArray<T>(data, MSize, NSize,OSize);
        }
    }
}
