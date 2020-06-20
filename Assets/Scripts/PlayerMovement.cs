using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public float health = 100f;
    public float damage = 20f;
    public EnemyGrafix enemy;
    public LayerMask attackMask;
    public GameManager gm;

    private Vector2 movement;
    private float lastDamage = 1;

    void Update() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            this.Attack();
        }

        if (this.health <= 0)
        {
            gm.EndGame();
        }
    }

    void FixedUpdate()
    {
        if (this.lastDamage >= 1)
        {
            this.lastDamage = 0;
        }
        this.lastDamage += Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void Attack() 
    {
        Vector3 pos = transform.position;
        pos += transform.right * Input.GetAxisRaw("Horizontal");
        pos += transform.up * Input.GetAxisRaw("Vertical");

        Collider2D collinfo = Physics2D.OverlapCircle(pos, 0.5f, attackMask);
        if (collinfo != null)
        {
            enemy.takeDamage(damage);
        }
        
    }

    public void takeDamage(float damage)
    {
        this.health = this.health - damage;
        animator.SetFloat("health", health);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && this.lastDamage >= 1)
        {
            this.takeDamage(enemy.damage);
        }
    }
}
