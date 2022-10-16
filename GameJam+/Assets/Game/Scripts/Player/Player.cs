using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Collider2D col;
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public bool facingRight;
    [HideInInspector] public bool ceilingDetected;
    [HideInInspector] public AudioManager audioManager;
    [HideInInspector] public AudioSource runningSound;


    public string currState;

    [Header("MOVE STATS")]
    public float ST;
    public float gravity;

    [Header("JUMP")]
    public float jumpHeight;
    public float jumpSpeedUP, jumpSpeedDOWN;
    public float ceilingDistanceFromHead;
    public LayerMask whatIsCeiling;

    [Header("ATTACK")]
    public GameObject bullet;
    public Transform firePos;

    [Header("DASH")]
    public float dashSpeed;
    public float dashTime;

    [Header("HEALTH")]
    public int HP;
    public int health;
    public TMP_Text healthUI;

    [Header("COOLDOWN")] 
    public float  FCTimer;
    [HideInInspector] public bool startFireCooldown;
    [HideInInspector] public bool canFire;
     
    public float dashCooldownTime;
    public float DCTimer;
    [HideInInspector] public bool startDashCooldown;
    [HideInInspector] public bool canDash;

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

    protected void CeilingCheck()   // check if player can jump.
    {
        ceilingDetected = Physics2D.Raycast(col.bounds.center, Vector2.up, ceilingDistanceFromHead, whatIsCeiling);
        Debug.DrawRay(col.bounds.center, Vector2.up *  ceilingDistanceFromHead, Color.yellow);  // draw line for ceiling check in Scene View.
    }

    public void FireCooldown()
    {
        if (startFireCooldown)
        {
            canFire = false;
            FCTimer -= Time.deltaTime;
            if (FCTimer <= 0f)
            {
                canFire = true;
                FCTimer = bullet.GetComponent<Bullet>().reloadSpeed;
                startFireCooldown = false;
            }
        }
    }
    public void DashCooldown()
    {
        if (startDashCooldown)
        {
            canDash = false;
            DCTimer -= Time.deltaTime;
            if (DCTimer <= 0f)
            {
                canDash = true;
                DCTimer = dashCooldownTime;
                startDashCooldown = false;
            }
        }
    }
}
