using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameField;
    public GameObject ConnectStatus;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if ( instance != this)
        {
            Debug.Log("Instanec already exists, destroying object!");
            Destroy(this);
        }
    }


    //private void Start()
    //{
    //    StartCoroutine("CheckConnectStatus");
    //}


    public void ConnectionStatus()
    {
        
        if (Client.instance.isConnected)
        {
            ConnectStatus.GetComponent<Text>().text = "Connected";
            ConnectStatus.GetComponent<Text>().color = Color.green;
        }

        if (!Client.instance.isConnected)
        {
            ConnectStatus.GetComponent<Text>().text = "Disconnect";
            ConnectStatus.GetComponent<Text>().color = Color.red;
        }

        if (Client.instance.waitingForServer)
        {

            ConnectStatus.GetComponent<Text>().text = "Waiting for Server . . .";
            ConnectStatus.GetComponent<Text>().color = Color.white;
        }

    }


    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene(1);
    }



    public void ConnectToServer()
    {

        Client.instance.ConnectToServer();
    }

}
