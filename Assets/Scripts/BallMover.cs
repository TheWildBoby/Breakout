using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    Vector2 Direction;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVelocity(Vector2 newDirection) {
        Direction = newDirection;
        rb.velocity = Direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            gameManager.GameOver();
        }
        if (collision.gameObject.tag == "Puck")
        {
            float distanceDelta = transform.position.x - collision.gameObject.transform.position.x;
            Quaternion.AngleAxis((distanceDelta / 1.625f) * 60, Vector3.forward);
            setVelocity(Quaternion.AngleAxis((-distanceDelta / 1.625f) * 60, Vector3.forward) * Vector3.up * speed * 3);
        }
        else
        {
            Vector3 BrickPos = collision.gameObject.transform.position;
            setVelocity(Vector2.Reflect(rb.velocity, collision.contacts[0].normal));

            if (collision.gameObject.tag == "Brick")
            {
                Destroy(collision.gameObject);
                GameManager.brickCount--;
            }

            if (collision.gameObject.tag == "Brick2")
            {
                collision.gameObject.GetComponent<Brick2>().Hit();
            }
        }
    }
}