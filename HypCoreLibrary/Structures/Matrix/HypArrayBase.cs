using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
using HypCoreLibrary.Interface;
using System.Runtime.InteropServices;
using Ionic.Zip;
using HypCoreLibrary.Models.DataAbstract;

namespace HypCoreLibrary.Structures.Matrix
{
    /// <summary>
    /// Base array for data handling and operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="HypCoreLibrary.Models.DataAbstract.DataEntryBase" />
    public class HypArrayBase<T> : DataEntryBase
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public override int Version { get; set; } = 0;
        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public override string Extension { get; set; } = "hgenmat";

        /// <summary>
        /// Principal data unit
        /// </summary>
        public T[] Data { get; set; }
        /// <summary>
        /// Dimensions of the matrix
        /// </summary>
        public int[] Size { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public HypArrayBase()
        {
            Size = new int[0];
            Data = new T[0];
        }

        /// <summary>
        /// Constructor with dimensions and null based data
        /// </summary>
        /// <param name="dimensions">array with the dimensionhs</param>
        public HypArrayBase(int[] dimensions)
        {
            var elements = 1;
            for (int i = 0; i < dimensions.Length; i++)
                if (dimensions[i] == 0)
                    elements = 0;
                else
                    elements *= dimensions[i];
            Size = dimensions;
            Data = new T[elements];
        }

        /// <summary>
        /// Constructor with dimensions and data
        /// </summary>
        /// <param name="dimensions"></param>
        /// <param name="data"></param>
        public HypArrayBase(T[] data, int[] dimensions)
        {
            var elements = 1;
            for (int i = 0; i < dimensions.Length; i++)
                if (dimensions[i] == 0)
                    elements = 0;
                else
                    elements *= dimensions[i];
            Size = dimensions;
            Data = data;
        }

        /// <summary>
        /// Get the value according to subscripts
        /// </summary>
        /// <param name="subscripts">sub indices</param>
        /// <returns></returns>
        public virtual T GetValue(params int[] subscripts)
        {
            var dimensions = GetDimensions();
            var id = subscripts[0];
            var pitatory = 1;
            for (int i = 1; i < dimensions.Length; i++)
            {
                pitatory *= dimensions[i];
                id += subscripts[i] * pitatory;
            }
            return Data[id];
        }

        /// <summary>
        /// Get the value acoording to index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns></returns>
        public virtual T GetValue(int index)
        {
            return Data[index];
        }
        /// <summary>
        /// Set the value in the subscripts adress
        /// </summary>
        /// <param name="value">value to set</param>
        /// <param name="subscripts">subscripts of the matrix</param>
        public virtual void SetValue(T value, params int[] subscripts)
        {
            var dimensions = GetDimensions();
            var id = subscripts[0];
            var pitatory = 1;
            for (int i = 1; i < dimensions.Length; i++)
            {
                pitatory *= dimensions[i];
                id += subscripts[i] * pitatory;
            }
            Data[id] = value;
        }

        /// <summary>
        /// Set the index value
        /// </summary>
        /// <param name="value">value to be setted</param>
        /// <param name="index">index in the matrix array</param>
        public virtual void SetValue(T value, int index)
        {
            Data[index] = value;
        }
        /// <summary>
        /// Gets a subarray of values
        /// </summary>
        /// <param name="initialSubscripts">Initial subscript</param>
        /// <param name="finalSubscripts">Final subscript</param>
        /// <returns></returns>
        public HypArrayBase<T> GetSubarray(int[] initialSubscripts, int[] finalSubscripts)
        {
            var initialIndex = initialSubscripts[0];
            var finalIndex = finalSubscripts[0];
            var nElements = finalIndex - initialIndex + 1;
            var data = new T[nElements];
            for (int i = 0; i < nElements; i++)
                data[i] = Data[initialIndex + i];
            return new HypArrayBase<T>(data, new int[] { nElements });
        }
        /// <summary>
        /// Gets the minimum value
        /// </summary>
        /// <returns></returns>
        public T Min()
        {
            return Data.Min();
        }

        /// <summary>
        /// Get the maximum of the data
        /// </summary>
        /// <returns></returns>
        public T Max()
        {
            return Data.Max();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="logics"></param>
        public void SetValue(T value, Hyp2DArray<bool> logics)
        {
            for (int i = 0; i < logics.GetNumberOfElements(); i++)
                if (logics.Data[i])
                    Data[i] = value;
        }


        /// <summary>
        /// Get number of elements
        /// </summary>
        /// <returns></returns>
        public virtual int GetNumberOfElements()
        {
            return Data.Length;
        }
        /// <summary>
        /// Gets the dimensions size
        /// </summary>
        /// <returns></returns>
        public virtual int[] GetDimensions()
        {
            return Size;
        }

        /// <summary>
        /// Copy the array
        /// </summary>
        /// <returns></returns>
        public virtual HypArrayBase<T> Copy()
        {
            var outData = new T[Data.Length];
            Array.Copy(Data, outData, outData.Length);
            return new HypArrayBase<T>(outData, Size);
        }
        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <returns></returns>
        public override S Copy<S>()
        {
            return Copy() as S;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }


        #region Serialize region        
        /// <summary>
        /// Serializes this instance.
        /// Don't inheret if you have your own strategy
        /// </summary>
        /// <returns></returns>
        public override Stream Serialize()
        {            

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            //var intSize = sizeof(int);
            var genericSize = Marshal.SizeOf<T>();

            // Write the version
            writer.Write(Version);
            // Write the number of dimension
            writer.Write(GetDimensions().Count());
            // Write the dimensions
            foreach (var dim in GetDimensions())
                writer.Write(dim);
            // Write the data
            var outBytes = new byte[genericSize * Data.Length];
            Buffer.BlockCopy(Data, 0, outBytes, 0, Data.Count());
            writer.BaseStream.Write(outBytes, 0, outBytes.Count());
            stream.Position = 0;
            return stream;
        }

        #endregion


        #region Deserialization        
        /// <summary>
        /// Deserializes the specified stream fullfilling the properties.
        /// Don't use the base if you have your own strategy
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        protected override S Deserialize<S>(Stream stream)
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                // Sets the sizes
                var intSize = sizeof(int);
                var genericSize = Marshal.SizeOf<T>();

                // Read the version
                var auxiliarBytes = new byte[intSize];
                reader.BaseStream.Read(auxiliarBytes, 0, intSize);
                int version = BitConverter.ToInt32(auxiliarBytes, 0);

                // Read the avaiable number of dimensions
                reader.BaseStream.Read(auxiliarBytes, 0, auxiliarBytes.Count());
                var numberOfDimensions = BitConverter.ToInt16(auxiliarBytes, 0);
                var dimensions = new int[numberOfDimensions];

                var numElements = 1;
                for (int i = 0; i < numberOfDimensions; i++)
                {
                    auxiliarBytes = new byte[intSize];
                    reader.BaseStream.Read(auxiliarBytes, 0, auxiliarBytes.Count());
                    dimensions[i] = BitConverter.ToInt16(auxiliarBytes, 0);
                    numElements *= dimensions[i];
                }

                var data = new T[numElements];
                var readedBytes = new byte[numElements * genericSize];
                reader.BaseStream.Read(readedBytes, 0, readedBytes.Count());
                Buffer.BlockCopy(readedBytes, 0, data, 0, readedBytes.Count());
                return new HypArrayBase<T>(data, dimensions) { Version = version } as S;
            }
        }



        #endregion

        #region implicit mathematic  operators

        /// <summary>
        /// Add operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<T> operator +(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).Add(double.Parse(b.ToString())) as HypArrayBase<T>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).Add(float.Parse(b.ToString())) as HypArrayBase<T>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).Add(int.Parse(b.ToString())) as HypArrayBase<T>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }


        /// <summary>
        /// Substract operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<T> operator -(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).Substract(double.Parse(b.ToString())) as HypArrayBase<T>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).Substract(float.Parse(b.ToString())) as HypArrayBase<T>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).Substract(int.Parse(b.ToString())) as HypArrayBase<T>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Multiply operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<T> operator *(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).Multiply(double.Parse(b.ToString())) as HypArrayBase<T>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).Multiply(float.Parse(b.ToString())) as HypArrayBase<T>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).Multiply(int.Parse(b.ToString())) as HypArrayBase<T>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }
        /// <summary>
        /// Division operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<T> operator /(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).Divide(double.Parse(b.ToString())) as HypArrayBase<T>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).Divide(float.Parse(b.ToString())) as HypArrayBase<T>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).Divide(int.Parse(b.ToString())) as HypArrayBase<T>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Add operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<T> operator +(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).Add(b as HypArrayBase<double>) as HypArrayBase<T>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).Add(b as HypArrayBase<float>) as HypArrayBase<T>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).Add(b as HypArrayBase<int>) as HypArrayBase<T>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }


        /// <summary>
        /// Substract operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<T> operator -(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).Substract(b as HypArrayBase<double>) as HypArrayBase<T>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).Substract(b as HypArrayBase<float>) as HypArrayBase<T>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).Substract(b as HypArrayBase<int>) as HypArrayBase<T>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Multiply operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<T> operator *(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).Multiply(b as HypArrayBase<double>) as HypArrayBase<T>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).Multiply(b as HypArrayBase<float>) as HypArrayBase<T>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).Multiply(b as HypArrayBase<int>) as HypArrayBase<T>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }
        /// <summary>
        /// Division operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<T> operator /(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).Divide(b as HypArrayBase<double>) as HypArrayBase<T>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).Divide(b as HypArrayBase<float>) as HypArrayBase<T>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).Divide(b as HypArrayBase<int>) as HypArrayBase<T>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }
        #endregion

        #region implicit logic  operators
        /// <summary>
        /// Equal operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator ==(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreEqual(double.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreEqual(float.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreEqual(int.Parse(b.ToString())) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator !=(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreNotEqual(double.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreNotEqual(float.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreNotEqual(int.Parse(b.ToString())) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Greater or equal operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator >=(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreGreaterOrEqual(double.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreGreaterOrEqual(float.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreGreaterOrEqual(int.Parse(b.ToString())) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Less or equal operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator <=(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreLessOrEqual(double.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreLessOrEqual(float.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreLessOrEqual(int.Parse(b.ToString())) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Greater operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator >(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreGreater(double.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreGreater(float.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreGreater(int.Parse(b.ToString())) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Less operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator <(HypArrayBase<T> a, T b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreLess(double.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreLess(float.Parse(b.ToString())) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreLess(int.Parse(b.ToString())) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }


        /// <summary>
        /// Equal operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator ==(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreEqual(b as HypArrayBase<double>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreEqual(b as HypArrayBase<float>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreEqual(b as HypArrayBase<int>) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator !=(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreNotEqual(b as HypArrayBase<double>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreNotEqual(b as HypArrayBase<float>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreNotEqual(b as HypArrayBase<int>) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Greater or equal operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator >=(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreGreaterOrEqual(b as HypArrayBase<double>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreGreaterOrEqual(b as HypArrayBase<float>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreGreaterOrEqual(b as HypArrayBase<int>) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Less or equal operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator <=(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreLessOrEqual(b as HypArrayBase<double>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreLessOrEqual(b as HypArrayBase<float>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreLessOrEqual(b as HypArrayBase<int>) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Greater operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator >(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreGreater(b as HypArrayBase<double>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreGreater(b as HypArrayBase<float>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreGreater(b as HypArrayBase<int>) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        /// <summary>
        /// Less operator
        /// </summary>
        /// <param name="a">source array</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> operator <(HypArrayBase<T> a, HypArrayBase<T> b)
        {
            if (typeof(T) == typeof(double))
                return (a as HypArrayBase<double>).AreLess(b as HypArrayBase<double>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(float))
                return (a as HypArrayBase<float>).AreLess(b as HypArrayBase<float>) as HypArrayBase<bool>;
            else if (typeof(T) == typeof(int))
                return (a as HypArrayBase<int>).AreLess(b as HypArrayBase<int>) as HypArrayBase<bool>;
            else throw new Exception(Constants.ErrorConstant.GENERIC_NOT_IMPLEMENTED);
        }

        #endregion

    }
}
