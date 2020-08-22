using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public Rigidbody2D rb;

    public void knockback(GameObject vihu)
    {
        print("alkaa");

        Vector2 difference = rb.transform.position - vihu.transform.position;
        difference = difference * thrust;
        gameObject.transform.position = difference;

        print("loppu");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
