using MySlave.Enums;
using MySlave.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySlave.Repository
{
    public class TeamsRepository : ITeamsRepository
    {
        [DllImport ("user32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        public void ReceiveKeyStroke(KeyEnum keyStroke)
        {
            var processList = GetTeamsProcess();
            string key = EnumHelper.GetEnumDescription(keyStroke);

            foreach (Process proc in processList)
            {
                IntPtr ptr = proc.MainWindowHandle;
                SetForegroundWindow(ptr);
                SendKeys.SendWait(key);
            }
        }

        private List<Process> GetTeamsProcess()
        {
            List<Process> processList = Process.GetProcesses().ToList();

            processList = processList.Where(process => process.ProcessName.Contains("Teams")).ToList();

            return processList;
        }
    }
}
