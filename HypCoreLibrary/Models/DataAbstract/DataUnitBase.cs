///-----------------------------------------------------------------
///   Namespace:      <Class Namespace>
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         <Author>                    Date: <DateTime>
///   Notes:          <Notes>
///   Revision History:
///   Name:           Date:        Description:
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HypCoreLibrary.Interface;
using HypCoreLibrary.Constants;
using Ionic.Zip;
using System.IO;
using HypCoreLibrary.Event;

namespace HypCoreLibrary.Models.DataAbstract
{

    /// <summary>
    /// Data unit base
    /// </summary>
    public class DataUnitBase
    {


        #region Propertys
        /// <summary>
        /// The definition file constant name
        /// </summary>
        public const string DefinitionFile = "Definition file";

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        public string ZipFilePath { get; private set; }

        /// <summary>
        /// Gets the entry names.
        /// </summary>
        /// <value>
        /// The entry names.
        /// </value>
        public List<string> EntryNames { get; private set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public virtual string Extension { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is lock.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is lock; otherwise, <c>false</c>.
        /// </value>
        public bool IsLock { get; set; }
        /// <summary>
        /// Gets or sets the children data unit.
        /// </summary>
        /// <value>
        /// The children data unit.
        /// </value>
        public List<string> ChildrenFolderRoutes { get; set; }


        public string InsideFolderPath { get; set; }

        public List<string> EntryRoute { get; set; }
        #endregion
        #region Event        


        /// <summary>
        /// Occurs when [create data entry event].
        /// </summary>
        public event CreateDataEntryHandler CreateDataEntryEvent;
        /// <summary>
        /// Occurs when [delete event].
        /// </summary>
        public event DeleteDataEntryEventHandler DeleteDataEntryEvent;
        /// <summary>
        /// Occurs when [rename data entry event].
        /// </summary>
        public event RenameDataEntryEventHandler RenameDataEntryEvent;
        /// <summary>
        /// Occurs when [load data entry event].
        /// </summary>
        public event LoadDataEntryEventHandler LoadDataEntryEvent;
        /// <summary>
        /// Occurs when [load data entry event].
        /// </summary>
        public event UpdateDataEntryEventHandler UpdateDataEntryEvent;
        /// <summary>
        /// Occurs when [progress event].
        /// </summary>
        public event ProgressEventHandler ProgressEvent;



        #endregion 


        /// <summary>
        /// Initializes a new instance of the <see cref="DataUnitBase"/> class.
        /// </summary>
        /// <param name="filePath">The absolute file path.</param>
        public DataUnitBase(string filePath, string folderPath = null)
        {
            ZipFilePath = filePath;
            if (folderPath == null) InsideFolderPath = string.Empty;
            else InsideFolderPath = folderPath;


            CreateDataEntryEvent += DataUnitBase_CreateDataEntryEvent;
            DeleteDataEntryEvent += DataUnitBase_DeleteDataEntryEvent;
            RenameDataEntryEvent += DataUnitBase_RenameDataEntryEvent;
            LoadDataEntryEvent += DataUnitBase_LoadDataEntryEvent;
            UpdateDataEntryEvent += DataUnitBase_UpdateDataEntryEvent;
            ProgressEvent += DataUnitBase_ProgressEvent;
        }

        #region Event implementation

        /// <summary>
        /// Invokes the progress event.
        /// </summary>
        /// <param name="args">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        protected void InvokeProgressEvent(ProgressEventArgs args)
        {
            ProgressEvent.Invoke(this, args);
        }
        /// <summary>
        /// Handles the ProgressEvent event of the DataUnitBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        private void DataUnitBase_ProgressEvent(object sender, ProgressEventArgs args)
        {

        }
        /// <summary>
        /// Invokes the update data entry event.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void InvokeUpdateDataEntryEvent(UpdateDataEntryEvenArgs args)
        {
            UpdateDataEntryEvent.Invoke(this, args);
        }
        /// <summary>
        /// Datas the unit base update data entry event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The arguments.</param>
        private void DataUnitBase_UpdateDataEntryEvent(object sender, UpdateDataEntryEvenArgs args)
        {

        }
        /// <summary>
        /// Invokes the load data entry event.
        /// </summary>
        /// <param name="args">The <see cref="LoadDataEventArgs"/> instance containing the event data.</param>
        protected void InvokeLoadDataEntryEvent(LoadDataEventArgs args)
        {
            LoadDataEntryEvent.Invoke(this, args);
        }
        /// <summary>
        /// Handles the LoadDataEntryEvent event of the DataUnitBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="LoadDataEventArgs"/> instance containing the event data.</param>
        private void DataUnitBase_LoadDataEntryEvent(object sender, LoadDataEventArgs args)
        {

        }
        /// <summary>
        /// Invokes the rename data entry event.
        /// </summary>
        /// <param name="args">The <see cref="RenameDataEntryEventArgs"/> instance containing the event data.</param>
        protected void InvokeRenameDataEntryEvent(RenameDataEntryEventArgs args)
        {
            RenameDataEntryEvent.Invoke(this, args);
        }
        /// <summary>
        /// Handles the RenameDataEntryEvent event of the DataUnitBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="RenameDataEntryEventArgs"/> instance containing the event data.</param>
        private void DataUnitBase_RenameDataEntryEvent(object sender, RenameDataEntryEventArgs args)
        {

        }
        /// <summary>
        /// Invokes the delete data entry event.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void InvokeDeleteDataEntryEvent(DeleteDataEntryEvenArgs args)
        {
            DeleteDataEntryEvent.Invoke(this, args);
        }

        private void DataUnitBase_DeleteDataEntryEvent(object sender, DeleteDataEntryEvenArgs args)
        {

        }
        /// <summary>
        /// Invokes the create data entry event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The arguments.</param>
        protected void InvokeCreateDataEntryEvent(object sender, CreateDataEntryArgs args)
        {
            CreateDataEntryEvent.Invoke(this, args);
        }
        private void DataUnitBase_CreateDataEntryEvent(object sender, CreateDataEntryArgs args)
        {

        }
        #endregion 


        ~DataUnitBase()
        {
        }
        /// <summary>
        /// Gets the zip file instance.
        /// </summary>
        /// <returns></returns>
        private ZipFile GetZipFile()
        {
            ZipFile zipFile;
            if (File.Exists(ZipFilePath))
            {
                zipFile = ZipFile.Read(ZipFilePath);
                EntryNames = zipFile.EntryFileNames.ToList();
            }
            else
            {
                zipFile = new ZipFile(ZipFilePath);
                zipFile.Save();
                EntryNames = new List<string>();
            }
            return zipFile;
        }


        public void CreateEntry(string name)
        {
            using (var zipFile = GetZipFile())
            {
                zipFile.AddEntry(Path.Combine(InsideFolderPath, name), new byte[1000000000]);
                zipFile.Save();
            }
        }


        public void ReadEntry<T>(string name, IDeserialize<T> deserialize)
        {
            using (var zipFile = GetZipFile())
            {
                var algo = zipFile[Path.Combine(InsideFolderPath, name)];
                using (MemoryStream stream = new MemoryStream((int)algo.UncompressedSize))
                {
                    // TODO: Eventos de deserializ
                    // TODO: Deserializable en el constructor
                    // Deserialiacion en archivos temporales. 
                    algo.Extract(stream);
                    deserialize.Deserialize(stream);
                }
            }
        }

        /// <summary>
        /// Creates the entry.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="serialize">The serialize.</param>
        /// <exception cref="Exception">Key already exists exception</exception>
        protected void CreateEntry(string name, ISerialize serialize)
        {
            if (EntryNames.Contains(name))
                throw new Exception(ErrorConstant.KEY_ALREADY_EXISTIS);
            using (var zipFile = GetZipFile())
            {
                zipFile.AddEntry(name, new byte[1000000000]);
                zipFile.Save();
            }
        }


        public void GetEntry<T>(string name)
        {

        }





    }
}
