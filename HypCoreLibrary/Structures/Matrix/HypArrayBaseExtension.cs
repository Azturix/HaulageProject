using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Structures.Matrix
{
    public static class HypArrayBaseExtension
    {

        // Mathematics operations.

        #region double basic  mathematics operations
        // Basics operations
        /// <summary>
        /// Sum to scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to sum</param>
        /// <returns></returns>
        public static HypArrayBase<double> Add(this HypArrayBase<double> array, double value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] += value;
            });
            return outArray;
        }
        /// <summary>
        /// Sum another array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<double> Add(this HypArrayBase<double> array, HypArrayBase<double> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] += array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Substracts an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to substract</param>
        /// <returns></returns>
        public static HypArrayBase<double> Substract(this HypArrayBase<double> array, double value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] -= value;
            });
            return outArray;
        }
        /// <summary>
        /// Substract an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<double> Substract(this HypArrayBase<double> array, HypArrayBase<double> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] -= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Multiply an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static HypArrayBase<double> Multiply(this HypArrayBase<double> array, double value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] *= value;
            });
            return outArray;
        }
        /// <summary>
        /// Multiply an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<double> Multiply(this HypArrayBase<double> array, HypArrayBase<double> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] *= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Divide by an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static HypArrayBase<double> Divide(this HypArrayBase<double> array, double value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] /= value;
            });
            return outArray;
        }
        /// <summary>
        /// Divide by an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<double> Divide(this HypArrayBase<double> array, HypArrayBase<double> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] /= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Sumatory of all values
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double Sum(this HypArrayBase<double> array)
        {
            double sumatory = 0;
            Parallel.For(0, array.Data.Length, i =>
            {
                sumatory += array.Data[i];
            });
            return sumatory;
        }
        #endregion

        #region float basic mathematic operations
        // Basics operations
        /// <summary>
        /// Sum to scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to sum</param>
        /// <returns></returns>
        public static HypArrayBase<float> Add(this HypArrayBase<float> array, float value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] += value;
            });
            return outArray;
        }
        /// <summary>
        /// Sum another array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<float> Add(this HypArrayBase<float> array, HypArrayBase<float> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] += array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Substracts an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to substract</param>
        /// <returns></returns>
        public static HypArrayBase<float> Substract(this HypArrayBase<float> array, float value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] -= value;
            });
            return outArray;
        }
        /// <summary>
        /// Substract an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<float> Substract(this HypArrayBase<float> array, HypArrayBase<float> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] -= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Multiply an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static HypArrayBase<float> Multiply(this HypArrayBase<float> array, float value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] *= value;
            });
            return outArray;
        }
        /// <summary>
        /// Multiply an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<float> Multiply(this HypArrayBase<float> array, HypArrayBase<float> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] *= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Divide by an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static HypArrayBase<float> Divide(this HypArrayBase<float> array, float value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] /= value;
            });
            return outArray;
        }
        /// <summary>
        /// Divide by an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<float> Divide(this HypArrayBase<float> array, HypArrayBase<float> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] /= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Sumatory of all values
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static float Sum(this HypArrayBase<float> array)
        {
            float sumatory = 0;
            Parallel.For(0, array.Data.Length, i =>
            {
                sumatory += array.Data[i];
            });
            return sumatory;
        }
        #endregion

        #region int basic mathematic operations 
        // Basics operations
        /// <summary>
        /// Sum to scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to sum</param>
        /// <returns></returns>
        public static HypArrayBase<int> Add(this HypArrayBase<int> array, int value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] += value;
            });
            return outArray;
        }
        /// <summary>
        /// Sum another array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<int> Add(this HypArrayBase<int> array, HypArrayBase<int> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] += array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Substracts an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to substract</param>
        /// <returns></returns>
        public static HypArrayBase<int> Substract(this HypArrayBase<int> array, int value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] -= value;
            });
            return outArray;
        }
        /// <summary>
        /// Substract an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<int> Substract(this HypArrayBase<int> array, HypArrayBase<int> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] -= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Multiply an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static HypArrayBase<int> Multiply(this HypArrayBase<int> array, int value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] *= value;
            });
            return outArray;
        }
        /// <summary>
        /// Multiply an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<int> Multiply(this HypArrayBase<int> array, HypArrayBase<int> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] *= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Divide by an scalar
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static HypArrayBase<int> Divide(this HypArrayBase<int> array, int value)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] /= value;
            });
            return outArray;
        }
        /// <summary>
        /// Divide by an array
        /// </summary>
        /// <param name="array">source</param>
        /// <param name="array2">other array</param>
        /// <returns></returns>
        public static HypArrayBase<int> Divide(this HypArrayBase<int> array, HypArrayBase<int> array2)
        {
            var outArray = array.Copy();
            Parallel.For(0, array.Data.Length, i =>
            {
                outArray.Data[i] /= array.Data[i];
            });
            return outArray;
        }
        /// <summary>
        /// Sumatory of all values
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Sum(this HypArrayBase<int> array)
        {
            int sumatory = 0;
            Parallel.For(0, array.Data.Length, i =>
            {
                sumatory += array.Data[i];
            });
            return sumatory;
        }
        #endregion


        // Logic operations.

        #region double logic operations 

        /// <summary>
        /// Area equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreEqual(this HypArrayBase<double> a, double b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] == b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area not equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreNotEqual(this HypArrayBase<double> a, double b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] != b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater of equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreGreaterOrEqual(this HypArrayBase<double> a, double b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] >= b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater  to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreGreater(this HypArrayBase<double> a, double b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] > b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less or equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLessOrEqual(this HypArrayBase<double> a, double b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] <= b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLess(this HypArrayBase<double> a, double b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] < b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreEqual(this HypArrayBase<double> a, HypArrayBase<double> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] == b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area not equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreNotEqual(this HypArrayBase<double> a, HypArrayBase<double> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] != b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater of equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreGreaterOrEqual(this HypArrayBase<double> a, HypArrayBase<double> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] >= b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater  to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreGreater(this HypArrayBase<double> a, HypArrayBase<double> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] > b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less or equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLessOrEqual(this HypArrayBase<double> a, HypArrayBase<double> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] <= b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLess(this HypArrayBase<double> a, HypArrayBase<double> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] < b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }

        #endregion

        #region float logic operations 

        /// <summary>
        /// Area equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreEqual(this HypArrayBase<float> a, float b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] == b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area not equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreNotEqual(this HypArrayBase<float> a, float b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] != b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater of equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreGreaterOrEqual(this HypArrayBase<float> a, float b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] >= b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater  to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreGreater(this HypArrayBase<float> a, float b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] > b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less or equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLessOrEqual(this HypArrayBase<float> a, float b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] <= b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLess(this HypArrayBase<float> a, float b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] < b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreEqual(this HypArrayBase<float> a, HypArrayBase<float> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] == b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area not equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreNotEqual(this HypArrayBase<float> a, HypArrayBase<float> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] != b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater of equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreGreaterOrEqual(this HypArrayBase<float> a, HypArrayBase<float> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] >= b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater  to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreGreater(this HypArrayBase<float> a, HypArrayBase<float> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] > b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less or equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLessOrEqual(this HypArrayBase<float> a, HypArrayBase<float> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] <= b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLess(this HypArrayBase<float> a, HypArrayBase<float> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] < b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }

        #endregion

        #region int logic operations 

        /// <summary>
        /// Area equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreEqual(this HypArrayBase<int> a, int b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] == b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area not equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreNotEqual(this HypArrayBase<int> a, int b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] != b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater of equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreGreaterOrEqual(this HypArrayBase<int> a, int b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] >= b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater  to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        public static HypArrayBase<bool> AreGreater(this HypArrayBase<int> a, int b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] > b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less or equal to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLessOrEqual(this HypArrayBase<int> a, int b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] <= b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less to the scalar
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLess(this HypArrayBase<int> a, int b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] < b)
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreEqual(this HypArrayBase<int> a, HypArrayBase<int> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] == b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area not equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreNotEqual(this HypArrayBase<int> a, HypArrayBase<int> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] != b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater of equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreGreaterOrEqual(this HypArrayBase<int> a, HypArrayBase<int> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] >= b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Area  greater  to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        public static HypArrayBase<bool> AreGreater(this HypArrayBase<int> a, HypArrayBase<int> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] > b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less or equal to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLessOrEqual(this HypArrayBase<int> a, HypArrayBase<int> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] <= b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }
        /// <summary>
        /// Are less to the array
        /// </summary>
        /// <param name="a">source</param>
        /// <param name="b">array</param>
        /// <returns></returns>
        public static HypArrayBase<bool> AreLess(this HypArrayBase<int> a, HypArrayBase<int> b)
        {
            HypArrayBase<bool> outArray = new HypArrayBase<bool>(a.GetDimensions());

            Parallel.For(0, a.GetNumberOfElements(), i =>
            {
                if (a.Data[i] < b.Data[i])
                    outArray.Data[i] = true;
            });
            return outArray;
        }

        #endregion

        // Miscellaneous operations 

        #region double miscellaneous operations 
        public static void Round(this HypArrayBase<double> array, int precision)
        {
            Parallel.For(0, array.GetNumberOfElements(), i =>
            {
                array.Data[i] = Math.Round(array.Data[i], precision);
            });
        }
        #endregion


        #region float miscellaneous operations 
        public static void Round(this HypArrayBase<float> array, int precision)
        {
            Parallel.For(0, array.GetNumberOfElements(), i =>
            {
                array.Data[i] = (float)Math.Round((double)array.Data[i], precision);
            });
        }
        #endregion

        #region int miscellaneous operations 
  
       
        #endregion

    }
}
