using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Structures.Matrix
{
    public class MatrixUtility
    {
        /// <summary>
        /// Obtains the value.
        /// </summary>
        /// <param name="array3D">The array3 d.</param>
        /// <param name="heightIndex">Index of the height.</param>
        /// <param name="subscriptI">The subscript i.</param>
        /// <param name="subscriptJ">The subscript j.</param>
        /// <returns></returns>
        public static double ObtainAcumulatedValue(Hyp3DArray<double> array3D,
                                                   double heightIndex,
                                                   int subscriptI,
                                                   int subscriptJ)
        {
            if (heightIndex > array3D.OSize) heightIndex = array3D.OSize;
            if (heightIndex < 0) heightIndex = 0;
            int superiorIndex = (int)Math.Ceiling(heightIndex) - 1;
            int inferiorIndex = (int)Math.Floor(heightIndex) - 1;
            double fractionPart = heightIndex % 1;

            double superiorValue = 0;
            double inferiorValue = 0;

            if (superiorIndex >= 0)
            {
                superiorValue = array3D.GetValue(subscriptI, subscriptJ, superiorIndex);
            }
            if (inferiorIndex >= 0)
            {
                inferiorValue = array3D.GetValue(subscriptI, subscriptJ, inferiorIndex);
            }

            return inferiorValue + (superiorValue - inferiorValue) * fractionPart;
        }

        /// <summary>
        /// Obtains the value.
        /// </summary>
        /// <param name="array3D">The array3 d.</param>
        /// <param name="arrayHeight2D">The array height2 d.</param>
        /// <returns></returns>
        public static Hyp2DArray<double> ObtainAcumulatedValue(Hyp3DArray<double> array3D, Hyp2DArray<double> arrayHeight2D)
        {

            int m = array3D.MSize;
            int n = array3D.NSize;
            Hyp2DArray<double> outMatrix = new Hyp2DArray<double>(m, n);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double heightIndex = arrayHeight2D.GetValue(i, j);
                    outMatrix.SetValue(ObtainAcumulatedValue(array3D, heightIndex, i, j), i, j);
                }
            }
            return outMatrix;

        }

        public static Hyp2DArray<double> MaximumValueZDirection(Hyp3DArray<double> array3D)
        {
            int m = array3D.MSize;
            int n = array3D.NSize;
            Hyp2DArray<double> maxValueIndexMat = new Hyp2DArray<double>(m, n);

            for (int i = 0; i < array3D.MSize; i++)
            {
                for (int j = 0; j < array3D.NSize; j++)
                {
                    double maxIndexValue = MaximumValueZDirection(array3D, i, j);
                    maxValueIndexMat.SetValue(maxIndexValue, i, j);
                }
            }

            return maxValueIndexMat;
        }

        /// <summary>
        /// Maximums the value z direction.
        /// </summary>
        /// <param name="array3D">The array3 d.</param>
        /// <param name="subscriptI">The subscript i.</param>
        /// <param name="subscriptJ">The subscript j.</param>
        /// <returns></returns>
        public static double MaximumValueZDirection(Hyp3DArray<double> array3D, int subscriptI, int subscriptJ)
        {
            int o = array3D.OSize;
            int maxValueIndex = 0;
            double maxValue = array3D.GetValue(subscriptI, subscriptJ, 0);
            for (int k = 0; k < o; k++)
            {
                double value = array3D.GetValue(subscriptI, subscriptJ, k);
                if (value > maxValue)
                {
                    maxValue = value;
                    maxValueIndex = k;
                }
            }

            return maxValueIndex;
        }

        public static Hyp2DArray<double> GetZeros(int numberBlocksX, int numberBlocksY)
        {
            return new Hyp2DArray<double>(numberBlocksX, numberBlocksY);
        }

        public static Hyp2DArray<double> GetOnes(int numberBlocksX, int numberBlocksY)
        {

            return (new Hyp2DArray<double>(numberBlocksX, numberBlocksY)) + 1.0 as Hyp2DArray<double>;
        }

        public static Hyp3DArray<double> GetOnes(int numberBlocksX, int numberBlocksY, int numberBlocksZ)
        {
            return new Hyp3DArray<double>(numberBlocksX, numberBlocksY, numberBlocksZ) + 1 as Hyp3DArray<double>;
        }

        public static Hyp3DArray<double> GetZeros(int numberBlocksX, int numberBlocksY, int numberBlocksZ)
        {
            return new Hyp3DArray<double>(numberBlocksX, numberBlocksY, numberBlocksZ);
        }

        /// <summary>
        /// Acumulates the z values.
        /// </summary>
        /// <param name="array3D">The array3d.</param>
        /// <returns></returns>
        public static Hyp3DArray<double> AcumulateZValues(Hyp3DArray<double> array3D)
        {
            int m = array3D.MSize;
            int n = array3D.NSize;
            int o = array3D.OSize;

            var acumulatedArray = new Hyp3DArray<double>(m, n, o);

            // First row
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    double value = array3D.GetValue(i, j, 0);
                    acumulatedArray.SetValue(value, i, j, 0);
                }

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 1; k < o; k++)
                    {
                        double oldValue = acumulatedArray.GetValue(i, j, k - 1);
                        double value = array3D.GetValue(i, j, k);
                        acumulatedArray.SetValue(value + oldValue, i, j, k);
                    }
            return acumulatedArray;
        }

        public static Hyp3DArray<double> AcumulateWeighted(Hyp3DArray<double> ponderator,
                                                           Hyp3DArray<double> tonnage,
                                                           Hyp3DArray<double> acumulatedTonnage)
        {

            var tibb = tonnage + 1.0;
            Hyp3DArray<double> tonnageAffectedAcumulated = AcumulateZValues((tonnage * ponderator as Hyp3DArray<double>));
            return tonnageAffectedAcumulated / acumulatedTonnage as Hyp3DArray<double>;
        }
        /// <summary>
        /// Gets the random array.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public static Hyp2DArray<double> GetRandomArray(int m, int n)
        {
            Random randomEngine = new Random(DateTime.Now.Millisecond);
            randomEngine.NextDouble();
            Hyp2DArray<double> randomArray = new Hyp2DArray<double>(m, n);

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    randomArray.SetValue(randomEngine.NextDouble(), i, j);
            return randomArray;
        }
        /// <summary>
        /// Gets the random array.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="n">The n.</param>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static Hyp3DArray<double> GetRandomArray(int m, int n, int o)
        {
            Random randomEngine = new Random(DateTime.Now.Millisecond);
            randomEngine.NextDouble();
            Hyp3DArray<double> randomArray = new Hyp3DArray<double>(m, n, o);

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < o; k++)
                        randomArray.SetValue(randomEngine.NextDouble(), i, j, k);
            return randomArray;
        }

        /// <summary>
        ///  Horizontal concatenation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrays">The arrays.</param>
        /// <returns></returns>
        public static Hyp2DArray<T> HorzCat<T>(params Hyp2DArray<T>[] arrays)
        {
            var nSize = 0;
            var mSize = arrays[0].MSize;
            foreach (var array in arrays)
                nSize += array.NSize;

            Hyp2DArray<T> outArray = new Hyp2DArray<T>(mSize, nSize);


            int offset = 0;
            foreach (var array in arrays)
            {
                for (int i = 0; i < array.MSize; i++)
                    for (int j = 0; j < array.NSize; j++)
                    {
                        var value = array.GetValue(i, j);
                        outArray.SetValue(value, i, j + offset);
                    }

                offset += array.NSize;
            }

            return outArray;
        }

        public static Hyp2DArray<double> Multiply(Hyp2DArray<double> a, Hyp2DArray<double> b)
        {
            throw new NotImplementedException("Not implemented yet");
            //var m = Matrix<double>.Build.Dense(a.MSize, a.NSize, a.Data);
            //var v = Matrix<double>.Build.Dense(b.MSize, b.NSize, b.Data);
            //var out1 = m * v;
            //var hypOut = new Hyp2DArray<double>(out1.RowCount, out1.ColumnCount, out1.Storage.ToColumnMajorArray());
            //return hypOut;
        }

        public static Hyp2DArray<int> And(Hyp2DArray<double> a, Hyp2DArray<double> b)
        {
            int m = a.MSize;
            int n = a.NSize;

            var outArray = new Hyp2DArray<int>(m, n);

            for (int i = 0; i < m * n; i++)
                if (a.Data[i] == 1 && b.Data[i] == 1)
                    outArray.Data[i] = 1;
            return outArray;
        }


    }
}
