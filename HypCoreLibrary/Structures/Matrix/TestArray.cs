using System;
using System.Collections.Generic;
using System.Text;

namespace HypCoreLibrary.Structures.Matrix
{
    public class TestArray<T> : HypArrayBase<T>
    {

        public int MSize { get; set; }

        public int NSize { get; set; }

        public TestArray() : base()
        {
            Random randomEngine =
                new Random(DateTime.Now.Millisecond);

            MSize = 100;
            NSize = 100;

            var data = new double[MSize * NSize];

            int count = 0;
            for (int i = 0; i < MSize; i++)
                for (int j = 0; j < NSize; j++)
                    data[count++] = randomEngine.NextDouble();
            (this as TestArray<double>).Data = data;
        }

        public TestArray(int[] dimensions) : base(dimensions)
        {

        }

        public override int GetNumberOfElements()
        {
            return MSize * NSize;
        }
    }
}

