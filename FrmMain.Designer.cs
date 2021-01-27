
namespace RunningRemoteCommands
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lbl_info_ipAdress = new System.Windows.Forms.Label();
            this.tb_ipAdress = new System.Windows.Forms.TextBox();
            this.lbl_info_command = new System.Windows.Forms.Label();
            this.tb_command = new System.Windows.Forms.TextBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.lbl_info_psExecLocation = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.bw_run = new System.ComponentModel.BackgroundWorker();
            this.lbl_location = new System.Windows.Forms.Label();
            this.ofd_location = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lbl_info_ipAdress
            // 
            this.lbl_info_ipAdress.AutoSize = true;
            this.lbl_info_ipAdress.Location = new System.Drawing.Point(12, 97);
            this.lbl_info_ipAdress.Name = "lbl_info_ipAdress";
            this.lbl_info_ipAdress.Size = new System.Drawing.Size(123, 13);
            this.lbl_info_ipAdress.TabIndex = 0;
            this.lbl_info_ipAdress.Text = "Remote Computer Name";
            // 
            // tb_ipAdress
            // 
            this.tb_ipAdress.Location = new System.Drawing.Point(15, 114);
            this.tb_ipAdress.Name = "tb_ipAdress";
            this.tb_ipAdress.Size = new System.Drawing.Size(264, 20);
            this.tb_ipAdress.TabIndex = 1;
            // 
            // lbl_info_command
            // 
            this.lbl_info_command.AutoSize = true;
            this.lbl_info_command.Location = new System.Drawing.Point(12, 149);
            this.lbl_info_command.Name = "lbl_info_command";
            this.lbl_info_command.Size = new System.Drawing.Size(195, 13);
            this.lbl_info_command.TabIndex = 2;
            this.lbl_info_command.Text = "Command (Example: taskmgr, devmgmt)";
            // 
            // tb_command
            // 
            this.tb_command.Location = new System.Drawing.Point(15, 166);
            this.tb_command.Name = "tb_command";
            this.tb_command.Size = new System.Drawing.Size(264, 20);
            this.tb_command.TabIndex = 3;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(15, 215);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(264, 23);
            this.btn_run.TabIndex = 4;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // lbl_info_psExecLocation
            // 
            this.lbl_info_psExecLocation.AutoSize = true;
            this.lbl_info_psExecLocation.Location = new System.Drawing.Point(12, 13);
            this.lbl_info_psExecLocation.Name = "lbl_info_psExecLocation";
            this.lbl_info_psExecLocation.Size = new System.Drawing.Size(87, 13);
            this.lbl_info_psExecLocation.TabIndex = 5;
            this.lbl_info_psExecLocation.Text = "PsExec Location";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(15, 30);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(264, 23);
            this.btn_browse.TabIndex = 6;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // bw_run
            // 
            this.bw_run.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_run_DoWork);
            this.bw_run.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_run_RunWorkerCompleted);
            // 
            // lbl_location
            // 
            this.lbl_location.AutoSize = true;
            this.lbl_location.ForeColor = System.Drawing.Color.Red;
            this.lbl_location.Location = new System.Drawing.Point(15, 60);
            this.lbl_location.Name = "lbl_location";
            this.lbl_location.Size = new System.Drawing.Size(0, 13);
            this.lbl_location.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 265);
            this.Controls.Add(this.lbl_location);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.lbl_info_psExecLocation);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.tb_command);
            this.Controls.Add(this.lbl_info_command);
            this.Controls.Add(this.tb_ipAdress);
            this.Controls.Add(this.lbl_info_ipAdress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Running Remote Commands";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_info_ipAdress;
        private System.Windows.Forms.TextBox tb_ipAdress;
        private System.Windows.Forms.Label lbl_info_command;
        private System.Windows.Forms.TextBox tb_command;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Label lbl_info_psExecLocation;
        private System.Windows.Forms.Button btn_browse;
        private System.ComponentModel.BackgroundWorker bw_run;
        private System.Windows.Forms.Label lbl_location;
        private System.Windows.Forms.OpenFileDialog ofd_location;
    }
}

