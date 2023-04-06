using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public Transform cameraTransform; //ī�޶���ġ
    public GameObject bulletPrefab; //�Ѿ�
    public Transform firePosition;// �߻���ġ

    public float power = 25f; //�Ѿ��Ŀ�
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
