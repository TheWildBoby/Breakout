using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isFalling = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6) {
            rb.velocity = (new Vector2(0, 8));

        }
    }

    public void Hit() {
        rb.velocity = (new Vector2(0, 3));
        rb.gravityScale = 1;
        if (!isFalling) {
            GameManager.brickCount--;
        }
        isFalling = true;
        StartCoroutine(fallTimer());
    }

    private IEnumerator fallTimer() {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }
}