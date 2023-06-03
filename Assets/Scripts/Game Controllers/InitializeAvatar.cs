using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


[RequireComponent(typeof(PhotonView))]
public class InitializeAvatar : MonoBehaviour
{
    public Transform cameraPosition;
    
    private PhotonView photonView;
    
    // Start is called before the first frame update
    void Start()
    {
        SetParent();
        if(this.photonView.IsMine)
            SetCameraPosition();
    }

    private void SetParent()
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

    private void SetCameraPosition()
    {
        Transform camera = Camera.main.transform;
        camera.SetParent(this.cameraPosition);
        camera.localPosition = new Vector3(0, 0, 0);
    }

}
