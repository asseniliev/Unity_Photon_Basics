using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    private PhotonView photonView;
    private CharacterController myCharController;

    
    // Start is called before the first frame update
    void Start()
    {
        this.photonView = this.GetComponent<PhotonView>();
        this.myCharController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.photonView.IsMine)
        {
            Move();
            Rotate();
        }
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.myCharController.Move(this.transform.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.myCharController.Move(-this.transform.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.myCharController.Move(this.transform.right * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.myCharController.Move(-this.transform.right * Time.deltaTime * movementSpeed);
        }
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * this.rotationSpeed;
        this.transform.Rotate(new Vector3(0, mouseX, 0));
    }
}
