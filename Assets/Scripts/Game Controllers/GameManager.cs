using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public static GameManager gameManager;
    public Transform[] spawnPoints;
    public Text healthText;
    public Text messageText;

    public GameObject myAvatar;


    private void OnEnable()
    {
        if(GameManager.gameManager == null)
        {
            GameManager.gameManager = this;
        }

        EventManager.eventManager.distributeMessage += DisplayMessage;
    }

    private void OnDisable()
    {
        EventManager.eventManager.distributeMessage -= DisplayMessage;
    }

    public void DisconnectPlayer()
    {
        StartCoroutine(LeaveRoom());
    }

    private void Start()
    {
        this.messageText.text = "";
    }

    private IEnumerator LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        while(PhotonNetwork.InRoom)
        {
            yield return null;
        }
        SceneManager.LoadScene(PhotonRoom.room.menuScene);
    }

    private void DisplayMessage(string message)
    {
        StartCoroutine(ActivateMessage(message));
    }

    private IEnumerator ActivateMessage(string message)
    {
        this.messageText.text = message;
        yield return new WaitForSeconds(5);
        this.messageText.text = "";
    }
}
