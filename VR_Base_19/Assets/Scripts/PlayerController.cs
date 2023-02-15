using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 directionToMove;
    float gravity;
    CharacterController characterController;

    Transform mainCameraTransform;
    public float speed;

    void Start()
    {
        directionToMove = Vector3.zero;
        gravity = -9.81f;
        characterController = this.GetComponent<CharacterController>();

        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (!characterController.isGrounded)
        {
            directionToMove.y += gravity * Time.deltaTime;
        }
        else
        {
            if (mainCameraTransform.eulerAngles.x >= 10f && mainCameraTransform.eulerAngles.x <= 30f)
            {
                directionToMove = mainCameraTransform.TransformDirection(Vector3.forward);
                directionToMove = directionToMove * speed;
            }
            else
            {
                directionToMove = Vector3.zero;
            }
        }

        //if (Input.acceleration.y >= 0.5f)
        if(Input.GetMouseButtonDown(1))
        {
            directionToMove.y = 5.0f;
        }


        characterController.Move(directionToMove * Time.deltaTime);
    }
}


