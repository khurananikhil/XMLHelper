//------------------------------------------------------------------------------
// <copyright file="EBCXSDebugger.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace EBCXHelper
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("ec510d2f-baf1-4f4c-b793-14f02be2cf93")]
    public class EBCXSDebugger : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EBCXSDebugger"/> class.
        /// </summary>
        public EBCXSDebugger() : base(null)
        {
            this.Caption = "EBCXSDebugger";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new EBCXSDebuggerControl();
        }
    }
}
