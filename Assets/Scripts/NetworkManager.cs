using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;
    public Canvas canvas;
    //public SocketIOComponent socket;
    public GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    public void JoinGame()
    {
        StartCoroutine(ConnectToServer());
    }

    #region Commands
    private IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
    }
    #endregion

    #region Listening

    #endregion

    #region JSONMessageClasses

    [Serializable]
    public class PlayerJSON
    {
        public string name;
    }
    #endregion
}
