using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 dir;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.Normalize();
    }
    private void FixedUpdate()
    { 
        rb.velocity = dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
