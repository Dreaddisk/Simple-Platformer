using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnHitSpikeAction();
    public delegate void OnHitGoombaAction();
    public delegate void OnHitOrbAction();

    public OnHitGoombaAction OnHitGoomba;
    public OnHitSpikeAction OnHitSpike;
    public OnHitOrbAction OnHitOrb;

    float speed = 1000.0f;
    float jumpSpeed = 5000.0f;

    Vector3 leftBound;
    Vector3 rightBound;
    bool canJump;

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(Input.GetKeyDown("left") || (Input.GetKeyDown("a")))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown("right") || (Input.GetKeyDown("d")))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * Time.deltaTime);
        }

        if(Input.GetKeyDown("Space"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpSpeed * Time.deltaTime);
        }
    }

    void Jump(bool force = false)
    {
        if(canJump || force)
        {
            canJump = false;

            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bound")
        {
            canJump = true;
        }

        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();

            if (this.transform.position.y > enemy.transform.position.y + enemy.GetComponent<BoxCollider2D>().size.y / 2)
            {
                GameObject.Destroy(collision.gameObject);

                Jump(true);

                if(OnHitGoomba != null)
                {
                    OnHitGoomba();
                }
            }
            else
            {
                if(OnHitSpike != null)
                {
                    OnHitGoomba();
                }
            }
        }


    }
} // main class
