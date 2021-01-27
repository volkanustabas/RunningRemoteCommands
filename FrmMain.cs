using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace RunningRemoteCommands
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            ofd_location.ShowDialog();
            ofd_location.InitialDirectory = @"C:\Users\%username%\Downloads";
            var path = ofd_location.FileName;
            lbl_location.Text = path;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (lbl_location.Text == "")
            {
                MessageBox.Show(@"can you select psexec location", @"Warning");
            }
            else
            {
                if (PingHost(tb_ipAdress.Text))
                {

                    if (tb_command.Text =="")
                    {
                        MessageBox.Show(@"Command cannot be empty", @"Warning");
                    }
                    else
                    {
                        if (bw_run.IsBusy != true)
                        {
                            bw_run.RunWorkerAsync();
                            btn_browse.Enabled = false;
                            btn_run.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Wrong ip adress or computer name", @"Warning");
                }
            }
        }

        private void bw_run_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate { });
            RunWithPsExec(tb_ipAdress.Text, tb_command.Text, lbl_location.Text);
        }


        private void bw_run_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_browse.Enabled = true;
            btn_run.Enabled = true;
        }

        public void RunWithPsExec(string ipAdress, string parameter, string psExecLocation)
        {
            var usernamePasswordForPsExec = " -u Administrator -p \"password\"";
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
    }
}