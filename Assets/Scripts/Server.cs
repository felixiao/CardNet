using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
public abstract class Server
{
    public int port=11791;
    public IPEndPoint iepRecv, iepIncoming;

    public int maxAttempTime = 5;
    public int attempTime = 1;
    //初始化服务器状态
    public virtual void Init()
    {
        Start();
    }
    //开始服务器，并侦听客户端请求
    public virtual void Start()
    {
    }

    public virtual void Receive()
    {
        
    }
    public virtual void Send()
    {

    }

    public virtual void Close()
    {

    }
}

public class ServerTCP : Server
{
    #region Singleton
    public static ServerTCP Instance { get{return m_instance;} }
    private static readonly ServerTCP m_instance = new ServerTCP();
    static ServerTCP(){}
    private ServerTCP(){}
    #endregion

    TcpListener listener;
    List<TcpClient> clients=new List<TcpClient>();

    public void Init()
    {
        string debugStr = "[ServerTCP::Init] ";
        bool start = true;
        clients.Clear();

        Debug.Log(debugStr + "Server Init...");
        try
        {
            while (start)
            {
                try
                {
                    listener = new TcpListener(IPAddress.Any,port);
                    Debug.Log(debugStr + listener.LocalEndpoint.ToString());
                    start = false;
                }
                catch (System.Net.Sockets.SocketException e)
                {
                    Debug.Log(debugStr + e.Message);

                    if (attempTime >= maxAttempTime)
                        return;
                    port++;
                    attempTime++;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(debugStr + ex.Message);
            return;
        }
        base.Init();
    }
    public void Start()
    {
        listener.Start();
        Accept();
    }
    public void Accept()
    {
        string debugStr = "[ServerTCP::Accept] ";
        try
        {
            //listener.BeginAcceptTcpClient(new AsyncCallback(OnAccept), listener);
            listener.BeginAcceptTcpClient(new AsyncCallback(OnAccept), null);
        }
        catch (Exception e)
        {
            Debug.Log(debugStr + e.ToString());
        }
    }
    public void OnAccept(IAsyncResult ar)
    {
        string debugStr = "[ServerTCP::Accept(IAsyncResult)] ";
        try
        {
            //TcpListener l = (TcpListener)ar.AsyncState;
            //if(l.Server.IsBound)
            if (listener.Server.IsBound)
            {
                //TcpClient client = l.EndAcceptTcpClient(ar);
                TcpClient client = listener.EndAcceptTcpClient(ar);
                clients.Add(client);
                //l.BeginAcceptTcpClient(new AsyncCallback(OnAccept), l);
                listener.BeginAcceptTcpClient(new AsyncCallback(OnAccept), null);
            }
        }
        catch (Exception e)
        {
            Debug.Log(debugStr + e.ToString());
        }
        
    }

}
public class ServerClientTCP
{

}
public class ServerUDP : Server
{
    #region Singleton
    public static ServerUDP Instance { get{return m_instance;} }
    private static readonly ServerUDP m_instance = new ServerUDP();
    static ServerUDP(){}
    private ServerUDP() { }
    #endregion
    UdpClient receiver, sender;
    public void Init()
    {
        base.Init();
        bool start = true;
        string debugStr = "[ServerUDP::Init] ";
        Debug.Log(debugStr + "Server Init...");
        try
        {
            while (start)
            {
                try
                {
                    //iepRecv =new IPEndPoint(IPAddress.Any,listenPort);
                    receiver = new UdpClient(port);
                    Debug.Log(debugStr + port);
                    start = false;
                }
                catch (System.Net.Sockets.SocketException e)
                {
                    Debug.Log(debugStr + e.Message);

                    if (attempTime >= maxAttempTime)
                        return;
                    port++;
                    attempTime++;
                }
                sender = new UdpClient();

            }
        }
        catch (Exception ex)
        {
            Debug.Log(debugStr + ex.Message);
            return;
        }
    }
}