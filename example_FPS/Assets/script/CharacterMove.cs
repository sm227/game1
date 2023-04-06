using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform; //ī�޶� ��ġ�� ���� Ʈ������


    public float moveSpeed = 10f; //�̵��ӵ�
    public float jumpSpeed = 10f; //�����ӵ�
    public float gravity = -20f; //�߷�
    public float yVelocity = 0; //y������ ������
    public Transform rotation;
    public Transform translate;

    public CharacterController characterController; //ĳ���� ��Ʈ�ѷ� ������Ʈ
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
