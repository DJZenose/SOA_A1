using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    class registryConnector
    {
        private static string connectReg(string messageToSend, string registerIP)
        {
            Int32 port = 3128;
            TcpClient regSock = new TcpClient(registerIP, port);
            NetworkStream regStream;

            try
            {
                regSock.Connect(registerIP, port);
                regStream = regSock.GetStream();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            byte[] register = System.Text.Encoding.ASCII.GetBytes(messageToSend);


            regStream.Write(register, 0, register.Length);
            regStream.Flush();

            //get response
            byte[] responseStream = new byte[80025];
            regStream.Read(responseStream, 0, regSock.ReceiveBufferSize);
            string responseStr = System.Text.Encoding.ASCII.GetString(responseStream);

            regStream.Close();
            regSock.Close();

            return responseStr;
        }
    }
}
