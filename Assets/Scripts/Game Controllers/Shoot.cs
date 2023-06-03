using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class Shoot : MonoBehaviour
{
    public int damage = 1;
    
    private new Transform camera;
    private PhotonView photonView;
    
    // Start is called before the first frame update
    void Start()
    {
        this.camera = Camera.main.transform;
        this.photonView = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && this.photonView.IsMine)
        {
            CastRay();
        }
    }

    private void CastRay()
    {       
        RaycastHit hit;
        if(Physics.Raycast(this.camera.position, this.camera.forward, out hit))
        {
            EventManager.eventManager.CallMakeDamageEvent(hit.transform.name, this.damage);
        }
    }
}
