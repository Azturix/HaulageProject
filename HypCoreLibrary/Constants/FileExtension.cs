using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Constants
{
    public class FileExtension
    {
        /// <summary>
        /// The definition file extension
        /// </summary>
        public const string DEFINITION = "json";

        /// <summary>
        /// The generic 
        /// </summary>
        public const string GENERIC = "hgen";

        #region Matrices

        public const string GENERIC_MATRIX = "hmatgen";

        public const string MATRIX_2D_FLOAT = "h2dmatf";
        public const string MATRIX_2D_DOUBLE = "h2dmatd";
        public const string MATRIX_2D_INT = "h2dmati";

        public const string MATRIX_3D_FLOAT = "h3dmatf";
        public const string MATRIX_3D_DOUBLE = "h3dmatd";
        public const string MATRIX_3D_INT = "h3dmati";

        #endregion
    }
}
