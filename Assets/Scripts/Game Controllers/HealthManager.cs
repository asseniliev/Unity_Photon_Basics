using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]

public class HealthManager : MonoBehaviour
{
    public Text text;
    
    [SerializeField] private int health;
    private PhotonView photonView;

    private void OnEnable()
    {
        EventManager.eventManager.makeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        EventManager.eventManager.makeDamage -= TakeDamage;
    }

    public int Health { get => this.health; private set => this.health = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.photonView = this.GetComponent<PhotonView>();
        if(this.photonView.IsMine)
            GameManager.gameManager.healthText.text = this.Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        this.text.text = this.Health.ToString();
        if (this.photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.T))
                TakeDamage(this.transform.name, 1);
            
            GameManager.gameManager.healthText.text = this.Health.ToString();
        }
    }

    private void TakeDamage(string name, int damage)
    {
        if(this.transform.name == name)
        {
            this.Health -= damage;
            if (this.Health < 0)
                this.Health = 0;

            
            this.photonView.RPC("RPC_ModifyHealth", RpcTarget.OthersBuffered, this.Health);
        }
    }

    [PunRPC]
    private void RPC_ModifyHealth(int health)
    {
        this.Health = health;
    }


}
