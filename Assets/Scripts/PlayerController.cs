using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private CharacterController characterController;

    private GameObject playerCamera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main.gameObject;
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * inputVertical + transform.right * inputHorizontal;

        characterController.Move(move * Time.deltaTime * speed);
    }

    void RotatePlayer()
    {
        transform.rotation = Quaternion.Euler(0, playerCamera.transform.rotation.eulerAngles.y, 0);
    }
}
