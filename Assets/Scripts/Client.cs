using UnityEngine;
using System.Collections;

public class Client{

    #region Singleton
    public static Client Instance { get{return m_instance;} }
    private static readonly Client m_instance = new Client();
    static Client(){}
    private Client(){}
    #endregion

    public virtual void Init()
    {

    }
}
