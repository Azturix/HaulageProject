using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Event
{
    /// <summary>
    /// Arguments for progress
    /// </summary>
    public class ProgressEventArgs
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is indeterminated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is indeterminated; otherwise, <c>false</c>.
        /// </value>
        public bool IsIndeterminated { get; set; } = true;
        /// <summary>
        /// The percentage completed
        /// </summary>
        public double PercentageCompleted { get; set; } = 0;
        /// <summary>
        /// The has initiated
        /// </summary>
        public bool HasInitiated = false;
        /// <summary>
        /// The has finished
        /// </summary>
        public bool HasFinished = false;
    }
}
