using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform; //카메라 위치를 담을 트렌스폼


    public float moveSpeed = 10f; //이동속도
    public float jumpSpeed = 10f; //점프속도
    public float gravity = -20f; //중력
    public float yVelocity = 0; //y움직임 감지용
    public Transform rotation;
    public Transform translate;

    public CharacterController characterController; //캐릭터 컨트롤러 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent < CharacterController > ();
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(h, 0, v);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
       

        if (characterController.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
            }
        }
        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    
}
