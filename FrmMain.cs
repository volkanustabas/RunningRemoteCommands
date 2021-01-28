using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using RunningRemoteCommands.Properties;

namespace RunningRemoteCommands
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (PingHost(tb_ipAdress.Text))
            {
                if (tb_username.Text == "" || tb_password.Text == "")
                {
                    MessageBox.Show(@"Username or password cannot be empty", @"Warning");
                }
                else
                {
                    if (tb_command.Text == "")
                    {
                        MessageBox.Show(@"Command cannot be empty", @"Warning");
                    }
                    else
                    {
                        if (bw_run.IsBusy != true)
                        {
                            bw_run.RunWorkerAsync();
                            btn_run.Enabled = false;
                            tb_ipAdress.Enabled = false;
                            tb_username.Enabled = false;
                            tb_password.Enabled = false;
                            tb_command.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Wrong ip adress or computer name", @"Warning");
            }
        }

        private void bw_run_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate { });

            var exeBytes = Resources.PsExec;
            if (File.Exists(Path.GetTempPath() + @"PsExec.exe")) File.Delete(Path.GetTempPath() + @"PsExec.exe");
            var psExecexeToRun = Path.Combine(Path.GetTempPath(), "PsExec.exe");
            using (var exeFile = new FileStream(psExecexeToRun, FileMode.CreateNew))
            {
                exeFile.Write(exeBytes, 0, exeBytes.Length);
            }

            RunWithPsExec(tb_ipAdress.Text, tb_username.Text, tb_password.Text, tb_command.Text, psExecexeToRun);
        }


        private void bw_run_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_run.Enabled = true;
            tb_ipAdress.Enabled = true;
            tb_username.Enabled = true;
            tb_password.Enabled = true;
            tb_command.Enabled = true;
        }

        public void RunWithPsExec(string ipAdress, string username, string password, string parameter,
            string psExecLocation)
        {
            var usernamePasswordForPsExec = " -u " + username + " -p " + "\"" + password + "\" ";
            var process = new Process();
            var locationForPsExec = psExecLocation;
            var runWithPsExec = @" C:\Windows\System32\cmd.exe ";

            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                FileName = locationForPsExec,
                Arguments = locationForPsExec + " -i -d " + "\\\\" + ipAdress + usernamePasswordForPsExec +
                            runWithPsExec + "/c start " + parameter + ""
            };
            process.StartInfo = processInfo;
            process.Start();
        }

        public bool PingHost(string remoteComputerIpAdress)
        {
            var pingable = false;
            var pinger = new Ping();

            try
            {
                var reply = pinger.Send(remoteComputerIpAdress);
                if (reply != null) pingable = reply.Status == IPStatus.Success;
            }
            catch (Exception e)
            {
                return false;
            }

            return pingable;
        }

        private void tb_command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btn_run_Click(sender, e);
        }
    }
}