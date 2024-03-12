using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float smoothing = 10.0f;

    private float xMousePos;
    private float smoothedMousePos;

    private float currentLookingPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1/smoothing);
    }

    void MovePlayer()
    {
        currentLookingPos += smoothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);
    }
}
