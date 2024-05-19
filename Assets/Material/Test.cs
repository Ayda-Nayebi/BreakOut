using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float power;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("OnCollisionEnter2D: "+ collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("OnCollisionExit2D: " + collision.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("OnCollisionStay2D: " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2D: "+ collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("OnTriggerExit2D: " + collision.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("OnTriggerStay2D: " + collision.gameObject.name);
    }
}
