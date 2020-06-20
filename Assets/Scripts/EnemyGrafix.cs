using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGrafix : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    public float health = 100f;
    public float damage = 30f;
    public GameObject endTrigger;

    private Vector2 movement;

    void Start()
    {
        animator.SetFloat("health", health);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = aiPath.desiredVelocity.x;
        movement.y = -aiPath.desiredVelocity.y;

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    public void takeDamage(float damage)
    {
        this.health = this.health - damage;
        animator.SetFloat("health", health);
        if (this.health <= 0f)
        {
            aiPath.canMove = false;
        }
    }

    public void die() 
    {
        gameObject.SetActive(false);
        endTrigger.SetActive(true);
    }
}
