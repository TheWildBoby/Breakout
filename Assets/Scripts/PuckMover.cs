using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMover : MonoBehaviour
{
    private Rigidbody2D rb;
    float movement;
    public float speed;
    public BallMover ball;
    public bool GameBegin = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBegin)
        {
            movement = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(movement, 0) * speed;
        }

        //game start
        if (GameBegin && ball.speed == 0 && rb.velocity != Vector2.zero) {
            ball.speed = 1;
            ball.setVelocity(new Vector2(0, 3));
        }

    }

    private IEnumerator StartDelay() // wait for a second before registering inputs
    {
        yield return new WaitForSeconds(0.2f);
        GameBegin = true;
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick2") {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, 4));
        }
    }
}
