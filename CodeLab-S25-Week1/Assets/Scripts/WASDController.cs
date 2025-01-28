using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WASDController : MonoBehaviour
{
    public static Action<string> PlayerCollectsCoin = delegate { };
    
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;

    public Rigidbody rb;

    public float moveForce = 10f;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("START!!!");

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update...");
        
        //stop it from sliding too much after the key is pressed
        rb.linearVelocity *= 0.99f;

        if (Input.GetKey(keyUp))
        {
            rb.AddForce(Vector3.up * moveForce);
        }

        if (Input.GetKey(keyDown))
        {
            rb.AddForce(Vector3.down * moveForce);
        }

        if (Input.GetKey(keyLeft))
        {
            rb.AddForce(Vector3.left * moveForce);
        }

        if (Input.GetKey(keyRight))
        {
            rb.AddForce(Vector3.right * moveForce);
        }

        //wraparound technique didn't work 
        // if (newPos.x > 9)
        // {
        //     Debug.Log("moved to other side of screen");
        //     newPos.x = -9;
        // }
        //
        
    }

    // this code is when they collide with the collectable 
     private void OnTriggerEnter(Collider collision)
     {
         Debug.Log("Triggered");
         
         if (collision.GetComponent<Coin>())
         {
             Debug.Log("Coin collected");
             PlayerCollectsCoin(name);
             Destroy(collision.gameObject);
         }
     }
    
    
}
