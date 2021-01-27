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
                MessageBox.Show(@"Can you select psexec location?", @"Warning");
            }
            else
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
                                btn_browse.Enabled = false;
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
        }

        private void bw_run_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate { });
            RunWithPsExec(tb_ipAdress.Text, tb_username.Text, tb_password.Text, tb_command.Text, lbl_location.Text);
        }


        private void bw_run_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_browse.Enabled = true;
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