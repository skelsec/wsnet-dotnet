﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using WSNet;

/*
namespace WSNetFramework.WSNet.SocketComm
{
    class SocketUDPClientSession : SocketSession
    {
        string ip;
        int port;
        UdpClient client_sock;
        byte[] token;
        AsyncQueue<byte[]> outQ;
        CancellationTokenSource cts = new CancellationTokenSource();
        bool EvtSocketClosed = false;

        public SocketUDPClientSession(CMDHeader cmdhdr, CMDConnect cmd, AsyncQueue<byte[]> outQ)
        {
            this.initiator_cmdhdr = cmdhdr;
            this.initiator_cmd = cmd;
            this.ip = cmd.ip;
            this.port = cmd.port;
            this.token = cmdhdr.token;
            this.outQ = outQ;
        }

        public async Task<Tuple<bool, byte[]>> connect()
        {
            try
            {
                client_sock = new UdpClient();
                client_sock.Connect(ip, port);
                recv();
                return new Tuple<bool, byte[]>(true, null);

            }
            catch (Exception e)
            {
                CMDErr err = new CMDErr(-1, "Generic error -sockst connect- " + e.ToString());
                return new Tuple<bool, byte[]>(false, err.to_bytes());
            }
        }

        public override void stop()
        {
            cts.Cancel();
        }

        public override async Task<Tuple<bool, byte[]>> send(CMDHeader cmdhdr)
        {
            try
            {
                if (cts.IsCancellationRequested || EvtSocketClosed)
                {
                    throw new Exception("Socket already closed!");
                }
                await client_sock.SendAsync(cmdhdr.data, cmdhdr.data.Length);
                return new Tuple<bool, byte[]>(true, null);
            }
            catch (Exception e)
            {
                Console.WriteLine("Socket send Error! " + e.Message);
                EvtSocketClosed = true;
                cts.Cancel();

                CMDErr err = new CMDErr(-1, "send error " + e.ToString());
                return new Tuple<bool, byte[]>(false, err.to_bytes());
            }


        }

        public async Task recv()
        {
            while (!(cts.IsCancellationRequested || EvtSocketClosed))
            {
                try
                {
                    var receivedResults = await client_sock.ReceiveAsync(); //.WithCancellation(cts.Token);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Socket recv Error! " + e.Message);
                    EvtSocketClosed = true;

                    CMDErr err = new CMDErr(-1, "recv error " + e.ToString());
                    CMDHeader reply = new CMDHeader(CMDType.ERR, token, err.to_bytes());
                    outQ.Enqueue(reply.to_bytes());
                    return;
                }
            }

        }
    }
}
*/