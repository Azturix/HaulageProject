using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic;
using Ionic.Zlib;
using Ionic.Zip;
using HypCoreLibrary.Structures.Matrix;

namespace HypCoreLibrary.IO.ZIP
{
    public class Compression
    {
        public static byte[] CompressStream(byte[] unCompressedBytes)
        {
            return ZlibStream.CompressBuffer(unCompressedBytes);
        }

        public static byte[] UncompressStream(byte[] compressedBytes)
        {
            return ZlibStream.UncompressBuffer(compressedBytes);
        }


        public static void AddEntry(string filename, HypArrayBase<double> array)
        {
            Ionic.Zip.ZipFile zipFile = new Ionic.Zip.ZipFile(filename);

            //zipFile.CompressionLevel = CompressionLevel.BestCompression;
            //zipFile.CompressionMethod = CompressionMethod.None;
            //zipFile.Strategy = CompressionStrategy.HuffmanOnly;

            for (int i = 0; i < 10; i++)
            {
                //zipFile.AddEntry(i.ToString(), array.GetBytes());
            }
            zipFile.Save();
        }

        public static void ReadEntry(string filename)
        {
            Ionic.Zip.ZipFile zipFile = ZipFile.Read(filename);


            MemoryStream memory = new MemoryStream();
            zipFile["1"].Extract(memory);
            var bytes = memory.GetBuffer();
        }
    }
}
