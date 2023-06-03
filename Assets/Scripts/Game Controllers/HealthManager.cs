using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]

public class HealthManager : MonoBehaviour
{
    public Text text;
    public int health;

    private PhotonView photonView;
    
    // Start is called before the first frame update
    void Start()
    {
        this.photonView = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        this.text.text = health.ToString();
        
        if(this.photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.T))
                this.photonView.RPC("RPC_ModifyHealth", RpcTarget.AllBuffered, -1);
        }

    }

    [PunRPC]
    private void RPC_ModifyHealth(int modifier)
    {
        this.health += modifier;
    }


}
