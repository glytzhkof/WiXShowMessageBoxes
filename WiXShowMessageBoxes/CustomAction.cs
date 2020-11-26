using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using System.Windows.Forms;

namespace WiXShowMessageBoxes
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ShowMessageBoxes(Session session)
        {
            MessageBox.Show("This is a .NET message box",".NET", MessageBoxButtons.OK, MessageBoxIcon.None,
                             MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);

            Record record = new Record(0);
            record[0] = "This is an MSI Win32 dialog.";

            session.Message(InstallMessage.User | (InstallMessage)MessageButtons.OK | (InstallMessage)MessageIcon.Information, record);

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult CustomActionName(Session session)
        {
            session.Log("Begin CustomActionName");

            return ActionResult.Success;
        }
    }
}
