using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public Transform cameraTransform; //카메라위치
    public GameObject bulletPrefab; //총알
    public Transform firePosition;// 발사위치

    public float power = 25f; //총알파워
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = firePosition.position;
            bullet.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power;
        }
    }
}
