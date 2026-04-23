using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace assignmentClient
{
    public partial class Form1 : Form
    {
        TcpClient? client;
        StreamWriter? writer;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                Disconnect();
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(txtIP.Text, int.Parse(txtPort.Text));

                writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                Task.Run(() => ReceiveLoop());

                Log("Connected to server");
                btnConnect.Text = "Disconnect";
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
            }
        }

        private void Disconnect()
        {
            try { client?.Close(); } catch { }
            client = null;
            writer = null;

            btnConnect.Text = "Connect";
            btnSend.Enabled = false;
            Log("Disconnected");
        }

        private async Task ReceiveLoop()
        {
            try
            {
                using var reader = new StreamReader(client!.GetStream());
                while (true)
                {
                    string? msg = await reader.ReadLineAsync();
                    if (msg == null) break;
                    string decryptedStr = DecryptString("LsFBTrQ3lI+jJQydUzp4FQ==", msg);
                    Log("Received: " + decryptedStr);
                }
            }
            catch { }

            BeginInvoke(new Action(Disconnect));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        void SendMessage()
        {
            try
            {
                if (writer == null) return;

                string msg = txtName.Text + ": " + txtMessage.Text.Trim();
                string EncMessage = EncryptString("LsFBTrQ3lI+jJQydUzp4FQ==", msg);
                writer.WriteLine(EncMessage);
                txtMessage.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }

        public static string DecryptString(string key, byte[] cipherText, string iv = "", bool isBas64 = false)
        {
            byte[] buffer = cipherText;

            using (Aes aes = Aes.Create())
            {
                aes.Key = isBas64 ? Convert.FromBase64String(key) : Encoding.UTF8.GetBytes(key);
                aes.IV = string.IsNullOrEmpty(iv) ? new byte[16] : Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }

        }
        public static string DecryptString(string key, string cipherText)
        {
            return DecryptString(key, Convert.FromBase64String(cipherText), "", true);
        }


        public static string EncryptString(string key, string plainText)
        {
            return Convert.ToBase64String(EncryptString(key, plainText, "", true));
        }


        public static byte[] EncryptString(string key, string plainText, string iv = "", bool isBas64 = false)
        {
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = isBas64 ? Convert.FromBase64String(key) : Encoding.UTF8.GetBytes(key);
                aes.IV = string.IsNullOrEmpty(iv) ? new byte[16] : Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }

            return array;

        }


        void Log(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Log), msg);
                return;
            }
            txtChat.AppendText(msg + Environment.NewLine);
        }
    }
}
