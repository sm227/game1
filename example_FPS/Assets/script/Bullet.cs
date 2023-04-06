using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Bullet : MonoBehaviour
{
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}
