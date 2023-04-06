using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 500f; //°¨µµ
    public float rotationX;
    public float rotationY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        if (rotationX > 25)
            rotationX = 25;
        if (rotationX < -30)
            rotationX = -30;

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
    }
}
