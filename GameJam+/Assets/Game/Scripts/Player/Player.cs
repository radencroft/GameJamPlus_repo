using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Collider2D col;
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public bool facingRight;

    public string currState;

    [Header("MOVE STATS")]
    public float ST;
    public float jumpForce;
    public float gravity;

    public void GenericMove()
    {
        float speed = ST;
        Vector2 dir = inputManager.GetMoveVector();
        anim.SetFloat("speed", Mathf.Abs(dir.x) + Mathf.Abs(dir.y));
        rb.velocity = dir * speed * Time.deltaTime;
    }

    public void GenericFlip()
    {
        if (facingRight && rb.velocity.x < 0f || (!facingRight && rb.velocity.x > 0f))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
