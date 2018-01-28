using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public Vector2 moveAmount;
    private float moveDirection = 1.0f;

	void Update ()
    {
        EnemyMovement();
    }

    void EnemyMovement ()
    {
         moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount); 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            Flip();
        }
    }

    public void Flip()
    {
        moveDirection *= -1;

        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

}