﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HypCoreLibrary.Interface;
namespace HypCoreLibrary.Structures.Matrix
{
    /// <summary>
    /// Array used
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Hyp2DArray<T> : HypArrayBase<T>
    {
        /// <summary>
        /// M Size of the matrix
        /// </summary>
        public int MSize { get; private set; }
        /// <summary>
        /// N Size of the matrixs
        /// </summary>
        public int NSize { get; private set; }



        /// <summary>
        /// Empty constructor
        /// </summary>
        public Hyp2DArray() : base()
        {

        }
        /// <summary>
        /// Constructor with dimensions and empty data
        /// </summary>
        /// <param name="m_size">M dimension</param>
        /// <param name="n_size">N dimension</param>
        public Hyp2DArray(int m_size, int n_size) : base(new int[] { m_size, n_size })
        {
            MSize = m_size;
            NSize = n_size;
        }
        /// <summary>
        /// Constructor with predefined data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="m_size"></param>
        /// <param name="n_size"></param>
        public Hyp2DArray(T[] data, int m_size, int n_size) : base(data, new int[] { m_size, n_size })
        {
            MSize = m_size;
            NSize = n_size;
        }


        /// <summary>
        /// Load from file path
        /// </summary>
        /// <param name="filePath"></param>
        public Hyp2DArray(string filePath) : base(filePath)
        {
            MSize = GetDimensions()[0];
            NSize = GetDimensions()[1];
        }

        /// <summary>
        /// Load from stream
        /// </summary>
        /// <param name="stream">strem</param>
        public Hyp2DArray(Stream stream) : base(stream)
        {
            MSize = GetDimensions()[0];
            NSize = GetDimensions()[1];
        }
        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="bytes"></param>
        public Hyp2DArray(byte[] bytes) : base(bytes)
        {

            MSize = GetDimensions()[0];
            NSize = GetDimensions()[1];
        }

        /// <summary>
        /// Get the value acoording to index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns></returns>
        public override T GetValue(int index)
        {
            return base.GetValue(index);
        }
        public override T GetValue(params int[] subscripts)
        {
            return Data[subscripts[0] + subscripts[1] * MSize];
        }
        /// <summary>
        /// Set the index value
        /// </summary>
        /// <param name="value">value to be setted</param>
        /// <param name="index">index in the matrix array</param>
        public override void SetValue(T value, int index)
        {
            base.SetValue(value, index);
        }
        /// <summary>
        /// Sets the value to an subscripts adress
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="subscripts">Adress in subscripts</param>
        public override void SetValue(T value, params int[] subscripts)
        {
            Data[subscripts[0] + subscripts[1] * MSize] = value;
        }


        public override HypArrayBase<T> Copy()
        {
            var data = new T[Data.Length];
            Array.Copy(Data, data, Data.Length);
            return new Hyp2DArray<T>(data, MSize, NSize);
        }


    }
}