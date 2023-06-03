using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo playerInfo;
    public int  selectedCharacter;
    public GameObject[] allCharacters;

    private void OnEnable()
    {
        if(PlayerInfo.playerInfo == null)
        {
            PlayerInfo.playerInfo = this;
        }
        else
        {
            if(PlayerInfo.playerInfo != this)
            {
                Destroy(PlayerInfo.playerInfo.gameObject);
                PlayerInfo.playerInfo = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCharacterPick(int character)
    {
        selectedCharacter = character;
    }
}
