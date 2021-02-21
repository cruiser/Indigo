using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;



namespace made_it
{
    public partial class Form1 : Form
    {
        enum RecycleFlags : int
        {
            SHRB_NOCONFIRMATION = 0x00000001, // Don't ask for confirmation
            SHRB_NOPROGRESSUI = 0x00000001, // Don't show progress
            SHRB_NOSOUND = 0x00000004 // Don't make sound when the action is executed
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) ///Username
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            MessageBox.Show(userName);
        }
        string HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
        private void button2_Click(object sender, EventArgs e) ///HWID
        {

            MessageBox.Show(HWID);
        }

        private void button3_Click(object sender, EventArgs e) ///clipboard
        {
            Clipboard.SetText(HWID);
        }

        string invite = "https://discord.gg/mm57kkapnW";

        private void button4_Click(object sender, EventArgs e) ///discord
        {
            MessageBox.Show(invite);
        }

        private void button5_Click(object sender, EventArgs e) //clipboard2
        {
            Clipboard.SetText(invite);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e) //ip
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            MessageBox.Show(myIP);
        }


        private void button7_Click(object sender, EventArgs e) //ping
        {
            Ping p = new Ping();
            string data = "www.steamcommunity.com";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            try
            {
                PingReply reply = p.Send(data, timeout, buffer);
                if (reply.Status == IPStatus.Success)
                {
                    MessageBox.Show("Steam servers are currently UP.");
                }
                else
                {
                    MessageBox.Show("Steam servers are currently DOWN");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Host not found");
            }



        }

        private void button8_Click(object sender, EventArgs e) //temp
        {
            int swag = 0;
            var tmpPath = Path.GetTempPath();
            var files = Directory.GetFiles(tmpPath, "*.*", SearchOption.AllDirectories);
            List<string> lockedFiles = new List<string>();

            foreach (var file in files)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        MessageBox.Show("Deleted Temp File", file);
                    }


                }
                catch (IOException)
                {
                    lockedFiles.Add(file);
                    MessageBox.Show("File is being processed by another thread", file);
                    swag++;
                    if (swag >= 10)
                    {
                        MessageBox.Show("10 File Locks have Occured. Closing.");
                        break;
                    }

                }
            }
        }


        private void button9_Click(object sender, EventArgs e) //recycle bin
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete all the items in recycle bin", "Clear recycle bin", MessageBoxButtons.YesNo);

            // If accepted, continue with the cleaning
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Execute the method with the required parameters
                    uint IsSuccess = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION);
                    MessageBox.Show("The recycle bin has been succesfully recycled !", "Clear recycle bin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    MessageBox.Show("The recycle bin couldn't be recycled" + ex.Message, "Clear recycle bin", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

      
        private void button10_Click(object sender, EventArgs e) //music
        {
            MessageBox.Show("https://www.youtube.com/watch?v=GErG9femMQk&list=WL&index=9");
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e) //pc off
        {
            MessageBox.Show("Turning off PC");
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}




