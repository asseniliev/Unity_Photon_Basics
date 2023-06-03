using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


[RequireComponent(typeof(PhotonView))]
public class SetParentAvatar : MonoBehaviour
{
    private PhotonView photonView;
    
    // Start is called before the first frame update
    void Start()
    {
        this.photonView = this.GetComponent<PhotonView>();
        object[] incomeCustomData = this.photonView.InstantiationData;
        int parentPhotonViewID = (int)incomeCustomData[0];
        PhotonView parentPhotonView = PhotonView.Find(parentPhotonViewID);
        if (parentPhotonView != null)
        {
            // Set the instantiated object as a child of the parent object
            this.transform.SetParent(parentPhotonView.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
