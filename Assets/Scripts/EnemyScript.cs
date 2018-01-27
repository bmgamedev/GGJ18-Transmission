using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    //public float min = 2.0f;
    //public float max = 3.0f;
    //replace these with 2 empty game objects marking the turning points for easier manipulation of paths


    //public float Speed;
    //private Animator animator;


    // float dist = 5.0f;
    // float moveSpeed = 1.0f;
    // float rot = 90.0f;

    //private Vector3 v = Vector3.zero;
    //private float x;

    public float moveSpeed = 1.0f;
    public Vector2 moveAmount;
    private float moveDirection = 1.0f;


    void Start ()
    {
        //animator = GetComponent<Animator>();

        //min = transform.position.x;
        //max = transform.position.x + 3; //don't hard code this in future...

        //x = transform.localPosition.x;

    }
	
	void Update ()
    {
        EnemyMovement();
    }

    void FixedUpdate()
    {
        //EnemyMovement();
    }

    void EnemyMovement ()
    {
        //transform.position = new Vector3(
        //    Mathf.PingPong(Time.time * 3, max - min) + min,
        //    transform.position.y,
        //    transform.position.z);  

        moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount); //Move the enemy
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Checkpoint" && gameObject.tag == "Enemy")
        {
            Flip();
        }
    }

    public void Flip()
    {
        moveDirection *= -1;

        // Flip the sprite by multiplying the x component of localScale by -1.
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

}