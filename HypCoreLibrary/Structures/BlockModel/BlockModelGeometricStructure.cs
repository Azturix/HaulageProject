using System;
using System.Collections.Generic;
using System.Text;

namespace HypCoreLibrary.Structures.BlockModel
{
    public class BlockModelGeometricStructure
    {
        

        /// <summary>
        /// Distance in x direction
        /// </summary>
        public double DistanceBlocksXDirection { get; set; }
        /// <summary>
        /// Distance in y direction
        /// </summary>
        public double DistanceBlocksYDirection { get; set; }
        /// Distance in z direction
        /// </summary>
        public double DistanceBlocksZDirection { get; set; }

        /// <summary>
        /// Number of blocks in x direction
        /// </summary>
        public int NumberBlocksX { get; set; } 
        /// <summary>
        /// Number of blocks in y direction
        /// </summary>
        public int NumberBlocksY { get; set; } 
        /// <summary>
        /// Number of blocks in z direction
        /// </summary>
        public int NumberBlocksZ { get; set; } 


        /// <summary>
        /// Initial centroid in x
        /// </summary>
        public double InitialXCentroid { get; set; }
        /// <summary>
        /// Initial centroid in y
        /// </summary>
        public double InitialYCentroid { get; set; } 
        /// <summary>
        /// Initial centroid in z
        /// </summary>
        public double InitialZCentroid { get; set; } 

        /// <summary>
        /// Gets the last point of the block structure
        /// </summary>
        public double[] getFinalCentroid()
        {
            double x = InitialXCentroid + (NumberBlocksX - 1) * DistanceBlocksXDirection;
            double y = InitialYCentroid + (NumberBlocksY - 1) * DistanceBlocksYDirection;
            double z = InitialZCentroid + (NumberBlocksZ - 1) * DistanceBlocksZDirection;
            return new double[] { x, y, z };
        }
        /// <summary>
        /// Gets the block volume.
        /// </summary>
        /// <returns></returns>
        public double GetVolume()
        {
            return DistanceBlocksXDirection * DistanceBlocksYDirection * DistanceBlocksZDirection;
        }

        /// <summary>
        /// Gets the initial point of the structure
        /// </summary>
        public double[] getInitialCentroid()
        {
            return new double[] { InitialXCentroid, InitialYCentroid, InitialZCentroid };
        }

        /// <summary>
        /// Gets the initial point of the structure
        /// </summary>
        public double[] getCentroid(int[] subscripts)
        {
            double x = subscripts[0] * DistanceBlocksXDirection + InitialXCentroid;
            double y = subscripts[1] * DistanceBlocksYDirection + InitialYCentroid;
            double z = subscripts[2] * DistanceBlocksZDirection + InitialZCentroid;

            return new double[] { x, y, z };
        }
        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return DistanceBlocksXDirection * DistanceBlocksYDirection;
        }

        /// <summary>
        /// Gets the x centroid.
        /// </summary>
        /// <param name="_subscriptI">The subscript i.</param>
        /// <returns></returns>
        public double getXCentroid(int _subscriptI)
        {
            return _subscriptI * DistanceBlocksXDirection + InitialXCentroid;
        }

        /// Gets the x centroid.
        /// </summary>
        /// <param name="_subscriptI">The subscript i.</param>
        /// <returns></returns>
        public double getYCentroid(int _subscriptJ)
        {
            return _subscriptJ * DistanceBlocksYDirection + InitialYCentroid;
        }

        /// Gets the x centroid.
        /// </summary>
        /// <param name="_subscriptI">The subscript i.</param>
        /// <returns></returns>
        public double getZCentroid(int _subscriptK)
        {
            return _subscriptK * DistanceBlocksZDirection + InitialZCentroid;
        }
        /// <summary>
        /// Gets the number blocks in each direction
        /// </summary>
        public int[] getNumberBlocks()
        {
            return new int[] { NumberBlocksX, NumberBlocksY, NumberBlocksZ };
        }
        /// <summary>
        /// Gets the distance blocks.
        /// </summary>
        public double[] getDistanceBlocks()
        {
            return new double[] { DistanceBlocksXDirection, DistanceBlocksYDirection, DistanceBlocksZDirection };
        }
        /// <summary>
        /// Gets the block subindex.
        /// </summary>
        /// <param name="idx">The index of the block.</param>
        /// <returns></returns>
        public int[] getBlockSubindex(int idx)
        {

            int x = idx / (NumberBlocksY * NumberBlocksZ);
            idx -= (x * NumberBlocksY * NumberBlocksZ);
            int y = idx / NumberBlocksZ;
            int z = idx % NumberBlocksZ;

            return new int[] { x, y, z };
        }
        /// <summary>
        /// Gets the block 2d subindex based in the index
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns></returns>
        public int[] getBlock2DSubindex(int idx)
        {

            int x = idx / (NumberBlocksY);
            int y = idx % NumberBlocksY;
            return new int[] { x, y };
        }
        /// <summary>
        /// Gets the index of the block based on subscript
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        /// <returns></returns>
        public int getBlockIndex(int i, int j, int k)
        {

            return k + j * NumberBlocksZ + i * NumberBlocksY * NumberBlocksZ;
        }
        /// <summary>
        /// Get i,j subscripts based in 1D index
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        public int get2DIndex(int i, int j)
        {
            int idx = j + NumberBlocksY * i;
            return idx;
        }
        /// <summary>
        /// Nears the x centroid.
        /// </summary>
        /// <param name="_XPoint">The x point.</param>
        /// <returns></returns>
        public double nearXCentroid(double _XPoint)
        {
            return nearXIndex(_XPoint) * DistanceBlocksXDirection + InitialXCentroid;
        }
        /// <summary>
        /// Nears the y centroid.
        /// </summary>
        /// <param name="_YPoint">The y point.</param>
        /// <returns></returns>
        public double nearYCentroid(double _YPoint)
        {
            return nearYIndex(_YPoint) * DistanceBlocksYDirection + InitialYCentroid;
        }
        /// <summary>
        /// Nears the z centroid.
        /// </summary>
        /// <param name="_ZPoint">The z point.</param>
        /// <returns></returns>
        public double nearZCentroid(double _ZPoint)
        {
            return nearZIndex(_ZPoint) * DistanceBlocksZDirection + InitialZCentroid;
        }
        /// <summary>
        /// Nears the index of the x.
        /// </summary>
        /// <param name="_XPoint">The x point.</param>
        /// <returns></returns>
        public int nearXIndex(double _XPoint)
        {
            return ClampSubscriptI((int)Math.Round((_XPoint - InitialXCentroid) / DistanceBlocksXDirection));
        }
        /// <summary>
        /// Nears the index of the y.
        /// </summary>
        /// <param name="_YPoint">The y point.</param>
        /// <returns></returns>
        public int nearYIndex(double _YPoint)
        {
            return ClampSubscriptJ((int)Math.Round((_YPoint - InitialYCentroid) / DistanceBlocksYDirection));
        }
        /// <summary>
        /// Nears the index of the z.
        /// </summary>
        /// <param name="_ZPoint">The z point.</param>
        /// <returns></returns>
        public int nearZIndex(double _ZPoint)
        {
            return ClampSubscriptK((int)Math.Round((_ZPoint - InitialZCentroid) / DistanceBlocksZDirection));
        }


        /// <summary>
        /// Clamps the subscript i.
        /// </summary>
        /// <param name="_subscriptI">The subscript i.</param>
        /// <returns></returns>
        public int ClampSubscriptI(int _subscriptI)
        {
            if (_subscriptI < 0) return 0;
            else if (_subscriptI >= NumberBlocksX) return NumberBlocksX - 1;
            else return _subscriptI;
        }
        /// <summary>
        /// Clamps the subscript j.
        /// </summary>
        /// <param name="_subscriptJ">The subscript j.</param>
        /// <returns></returns>
        public int ClampSubscriptJ(int _subscriptJ)
        {
            if (_subscriptJ < 0) return 0;
            else if (_subscriptJ >= NumberBlocksY) return NumberBlocksY - 1;
            else return _subscriptJ;
        }
        /// <summary>
        /// Clamps the subscript k.
        /// </summary>
        /// <param name="_subscriptK">The subscript k.</param>
        /// <returns></returns>
        public int ClampSubscriptK(int _subscriptK)
        {
            if (_subscriptK < 0) return 0;
            else if (_subscriptK >= NumberBlocksZ) return NumberBlocksZ - 1;
            else return _subscriptK;
        }
        public bool IsOutOfBoundaries(int _subscript, Subscript _subscriptType)
        {

            switch (_subscriptType)
            {
                case Subscript.i:
                    if (_subscript < 0 || _subscript >= NumberBlocksX) return true;
                    else return false;
                case Subscript.j:
                    if (_subscript < 0 || _subscript >= NumberBlocksY) return true;
                    else return false;
                case Subscript.k:
                    if (_subscript < 0 || _subscript >= NumberBlocksZ) return true;
                    else return false;
                default:
                    return false;
            }
        }
        /// <summary>
        /// Determines whether [is out of boundaries z point] [the specified z point].
        /// </summary>
        /// <param name="zPoint">The z point.</param>
        /// <returns>
        ///   <c>true</c> if [is out of boundaries z point] [the specified z point]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsOutOfBoundariesZPoint(double zPoint)
        {
            if (zPoint < GetBlockModelFloor())
                return true;
            if (zPoint > GetBlockModelCeil())
                return true;
            else return false;
        }
        /// <summary>
        /// Gets the block model floor.
        /// </summary>
        /// <returns></returns>
        public double GetBlockModelFloor()
        {
            return InitialZCentroid - DistanceBlocksZDirection / 2;
        }
        /// <summary>
        /// Gets the block model floor.
        /// </summary>
        /// <returns></returns>
        public double GetBlockModelCeil()
        {
            return InitialZCentroid + NumberBlocksZ * DistanceBlocksZDirection - DistanceBlocksZDirection / 2;
        }
        public double GetBlockModelHeight()
        {
            return NumberBlocksZ * DistanceBlocksZDirection;
        }
        /// <summary>
        /// Gets the diagonal.
        /// </summary>
        /// <returns></returns>
        public double GetDiagonal()
        {
            double dx = DistanceBlocksXDirection;
            double dy = DistanceBlocksYDirection;
            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }


        public double ConvertAbsoluteHeightToRelativeHeight(double zAbsolute)
        {
            return zAbsolute - GetBlockModelFloor();
        }

        ///// <summary>
        ///// Saves the instance in thespecified path.
        ///// </summary>
        ///// <param name="path">The path.</param>
        //public void Save(string path)
        //{

        //    var json = Newtonsoft.Json.JsonConvert.SerializeObject(this);

        //    using (var writer = new StreamWriter(path))
        //    {
        //        writer.Write(json);
        //    }
        //}
    }

    public enum Subscript
    {
        i, j, k
    }

}
