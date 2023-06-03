using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform mainCamera;

    private void Start()
    {
        this.mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(-Camera.main.gameObject.transform.position);
        this.transform.rotation = Quaternion.LookRotation(this.transform.position - this.mainCamera.position);
    }
}
