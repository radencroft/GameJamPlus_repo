using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public float speed;
    public int damage;
    public float reloadSpeed;

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
