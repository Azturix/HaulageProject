using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Interface
{
    public delegate void UnloadEventHandler(object sender);
    public delegate void LoadEventHandler(object sender);


    public abstract class BaseDataUnit
    {
        /// <summary>
        /// Path to the data unit file
        /// </summary>
        public string PathFile { get; private set; }

        /// <summary>
        /// Unload event
        /// </summary>
        public event UnloadEventHandler UnloadEvent;


        public virtual void Load(string pathFile)
        {
            UnloadEvent += BaseDataUnit_UnloadEvent;
        }

        private void BaseDataUnit_UnloadEvent(object sender)
        {
            
        }

        public virtual void Unload()
        {

        }

        public virtual void Update()
        {

        }




    }
}
