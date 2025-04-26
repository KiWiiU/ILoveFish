using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed;
    RealEstateMarket spawnObject;
    void Start()
    {
        spawnObject = transform.parent.gameObject.GetComponent<RealEstateMarket>();
        System.Random rnd = new System.Random();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2((float)rnd.Next(-15, -5), 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "DeathBarrier")
        {
            spawnObject.Score(1);
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Herring")
        {
            spawnObject.Score(-1);
            spawnObject.Lives(1);
            Destroy(gameObject);
        }
    }
}
