using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;


[RequireComponent(typeof(PhotonView))]
public class AvatarSetup : MonoBehaviour
{
    public int selectedCharacterValue;
    private PhotonView photonView;
    
    // Start is called before the first frame update
    void Start()
    {
        this.photonView = this.GetComponent<PhotonView>();
        int parentView = this.photonView.ViewID;

        //Set the parent of the avatar (the parent is the corresponding PhotonNetworkPlayer object)
        object[] incomeCustomData = this.photonView.InstantiationData;
        int parentPhotonViewID = (int)incomeCustomData[0];
        PhotonView parentPhotonView = PhotonView.Find(parentPhotonViewID);
        
        if (parentPhotonView != null)
        {
            // Set the instantiated object as a child of the parent object
            this.transform.SetParent(parentPhotonView.transform);
        }

        if (this.photonView.IsMine)
        {
            object[] customData = new object[] { parentView };
            AddCharacter(PlayerInfo.playerInfo.selectedCharacter, customData);
        }
    }

    private void AddCharacter(int selectedCharacter, object[] customData)
    {           
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", PlayerInfo.playerInfo.allCharacters[selectedCharacter].name),
                                                           this.transform.position, 
                                                           this.transform.rotation, 
                                                           0, 
                                                           customData);        
    }
}
