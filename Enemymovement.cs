using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }

        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }
}
