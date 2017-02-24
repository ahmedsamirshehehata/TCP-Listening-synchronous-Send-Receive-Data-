using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recevier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // set the TcpListener on port 1000
                    int port = 1000;
                    TcpListener server = new TcpListener(IPAddress.Any, port);

                    // Start listening for client requests
                    server.Start();


                    // Buffer for reading data
                    byte[] buffer = new byte[1024];
                    string data;

                    //Enter the listening loop
                    while (true)
                    {
                        Console.Write("Waiting for a connection... ");

                        // Perform a blocking call to accept requests.
                        // You could also user server.AcceptSocket() here.
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Connected!");

                        // Get a stream object for reading and writing
                        NetworkStream stream = client.GetStream();

                        int i;

                        // Loop to receive all the data sent by the client.
                        while (stream.Read(buffer, 0, buffer.Length) > 0)
                        {
                            // show recevied data in message
                            MessageBox.Show(System.Text.Encoding.Default.GetString(buffer));
                        }


                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SocketException: {0}");
                }


                Console.WriteLine("Hit enter to continue...");
                Console.Read();
            }

        }
    }
}
