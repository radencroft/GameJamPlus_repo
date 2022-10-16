using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    private int hit;
    [SerializeField] private int HP;
    [SerializeField] private int DamageToPlayer;

    private void Start()
    {
        hit = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "bullet")
        {
            if (hit > HP)
            {
                Destroy(this.gameObject);
            }
            else
            {
                hit += other.gameObject.GetComponent<Bullet>().damage;
            }
        } 
    }

    private void OnTriggerStay2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Immortal>().health -= DamageToPlayer;
        }
    }
}
