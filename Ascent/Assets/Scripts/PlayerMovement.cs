using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 20f;
    private CharacterController controller;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float Gravity = -10f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Horizontal"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * Speed) + (Vector3.up * Gravity);
    }

    void MovePlayer()
    {
        controller.Move(movementVector * Time.deltaTime);
    }
}

