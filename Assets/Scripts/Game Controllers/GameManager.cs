using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public static GameManager gameManager;
    public Transform[] spawnPoints;
    public Text healthText; 

    public GameObject myAvatar;

    private void OnEnable()
    {
        if(GameManager.gameManager == null)
        {
            GameManager.gameManager = this;
        }
    }

}
