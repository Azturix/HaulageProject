using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Event
{


    /// <summary>
    /// Create data entry event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The arguments.</param>
    public delegate void CreateDataEntryHandler(object sender, CreateDataEntryArgs args);
    /// <summary>
    /// Delegate for progresss event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
    public delegate void ProgressEventHandler(object sender, ProgressEventArgs args);
    /// <summary>
    /// Delegate for loading data
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="LoadDataEventArgs"/> instance containing the event data.</param>
    public delegate void LoadDataEntryEventHandler(object sender, LoadDataEventArgs args);
    /// <summary>
    /// Delegate for renaming dataunit 
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="RenameDataEntryEventArgs"/> instance containing the event data.</param>
    public delegate void RenameDataEntryEventHandler(object sender, RenameDataEntryEventArgs args);
    /// <summary>
    /// Update data unit event handler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The arguments.</param>
    public delegate void UpdateDataEntryEventHandler(object sender, UpdateDataEntryEvenArgs args);
    /// <summary>
    /// Delete unit event handler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The arguments.</param>
    public delegate void DeleteDataEntryEventHandler(object sender, DeleteDataEntryEvenArgs args);
}
