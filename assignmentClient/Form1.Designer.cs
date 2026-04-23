namespace assignmentClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtChat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtIP
            this.txtIP.Location = new System.Drawing.Point(20, 20);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(150, 23);
            this.txtIP.Text = "127.0.0.1";

            // txtPort
            this.txtPort.Location = new System.Drawing.Point(180, 20);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(80, 23);
            this.txtPort.Text = "5000";

            // txtName
            this.txtName.Location = new System.Drawing.Point(20, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 23);
            this.txtName.PlaceholderText = "Enter Name";

            // btnConnect
            this.btnConnect.Location = new System.Drawing.Point(280, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 27);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            // txtChat
            this.txtChat.Location = new System.Drawing.Point(20, 100);
            this.txtChat.Multiline = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(350, 200);
            this.txtChat.Name = "txtChat";

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(20, 320);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(250, 23);

            // btnSend
            this.btnSend.Location = new System.Drawing.Point(280, 320);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 27);
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);

            this.Name = "Form1";
            this.Text = "TCP Chat Client";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
