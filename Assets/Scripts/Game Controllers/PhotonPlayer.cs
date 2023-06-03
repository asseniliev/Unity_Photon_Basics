using UnityEngine;
using Photon.Pun;
using System.IO;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView photonView;
    public GameObject myAvatar;
    
    // Start is called before the first frame update
    void Start()
    {
        this.photonView = this.GetComponent<PhotonView>();
        int parentView = this.photonView.ViewID;
        int spawnPicker = Random.Range(0, GameSetup.gameSetup.spawnPoints.Length);
        if(this.photonView.IsMine)
        {
            object[] customData = new object[] { parentView };
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), 
                                      GameSetup.gameSetup.spawnPoints[spawnPicker].position, 
                                      GameSetup.gameSetup.spawnPoints[spawnPicker].rotation, 0, customData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
