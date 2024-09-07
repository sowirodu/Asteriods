using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    public GameManager gameManager;
    public int size = 3;
    public Sprite[] asteroidSprites; // Array of sprites

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AssignRandomSprite();

        transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        float spawnSpeed = Random.Range(4f - size, 5f - size);

        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);

        gameManager.asteriodCount++;
    }

    private void AssignRandomSprite()
    {
        if (asteroidSprites.Length > 0)
        {
            int index = Random.Range(0, asteroidSprites.Length);
            spriteRenderer.sprite = asteroidSprites[index];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            gameManager.asteriodCount--;
            Destroy(collision.gameObject);

            if (size > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Asteriod newAsteriod = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteriod.size = size - 1;
                    newAsteriod.gameManager = gameManager;
                }
            }
            Destroy(gameObject);
        }
    }
}
