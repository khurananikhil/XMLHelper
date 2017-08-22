using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using task = System.Threading.Tasks.Task;
using XHelper;

namespace EBCXHelper
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.guidPackageString)]
    [ProvideToolWindow(typeof(EBCXSDebugger))]
    public sealed class XHelperPackage : AsyncPackage
    {
        protected override async task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await Logger.InitializeAsync(this, Vsix.Name);

            await RemoveAllCommentsCommand.InitializeAsync(this);

            await XMLDecodeCommand.InitializeAsync(this);

            base.Initialize();
            EBCXSDebuggerCommand.Initialize(this);

            // to make instance available globally
            ProjectHelpers.XHelperPackage = this;
        }

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        //protected override void Initialize()
        //{
        //    base.Initialize();
        //    EBCXSDebuggerCommand.Initialize(this);
        //}
    }
}
