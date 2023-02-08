using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody coinRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        coinRigidbody = GetComponent<Rigidbody>();
        coinRigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
