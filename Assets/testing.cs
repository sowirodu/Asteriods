using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private List<KeyCode> keysPressed = new List<KeyCode>();
    Rigidbody2D rb;
    private float horizontal;

    void Start()
    {
        // Debug.Log("Hello World");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        // if (keysPressed.Contains(KeyCode.D))
        // {
        //     transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

        // }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void OnJump(InputValue value)
    {
        Debug.Log("Jumping");
        if (value.isPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        else if (rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }
    }
    void OnMove(InputValue value)
    {
        Debug.Log("Moving " + value.Get<float>());
    }
}
