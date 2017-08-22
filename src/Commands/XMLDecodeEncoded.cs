using System;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text;
using XHelper;
using Microsoft.VisualStudio.Shell.Interop;

namespace EBCXHelper
{
    internal sealed class XMLDecodeCommand : BaseCommand<XMLDecodeCommand>
    {
        protected override void SetupCommands()
        {
            RegisterCommand(PackageGuids.guidPackageCmdSet, PackageIds.XmlConversion);
        }

        protected override void Execute(OleMenuCommand button)
        {
            var view = ProjectHelpers.GetCurentTextView();

            try
            {
                DTE.UndoContext.Open(button.Text);

                XMLDecodeFromBuffer(view);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            finally
            {
                DTE.UndoContext.Close();
            }
        }

        private void XMLDecodeFromBuffer(IWpfTextView view)
        {
            using (var edit = view.TextBuffer.CreateEdit())
            {

                foreach (var line in view.TextBuffer.CurrentSnapshot.Lines.Reverse())
                {
                    if (line.Extent.IsEmpty)
                        continue;

                    var current = view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(line.LineNumber);
                    string text = current.GetTextIncludingLineBreak().Replace("&lt;", "<")
                                      .Replace("&gt;", ">")
                                      .Replace("amp;lt;", "<")
                                      .Replace("amp;gt;", ">");

                    edit.Delete(current.Start, current.LengthIncludingLineBreak);
                    edit.Insert(current.Start, text);
                }
                edit.Apply();
            }
            
            // Extract DebugInfo details and show in xHelper toolwindow
            
            ToolWindowPane window = ProjectHelpers.XHelperPackage.FindToolWindow(typeof(EBCXSDebugger), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("Cannot create tool window");
            }

            IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());            
        }
    }
}

