using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sheep : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed;
    SheepSpawn spawnObject;
    void Start()
    {
        spawnObject = transform.parent.gameObject.GetComponent<SheepSpawn>();
        System.Random rnd = new System.Random();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2((float)rnd.Next(-20, -5), 0f);
    }

    void OnMouseDown()
    {
        spawnObject.MoreSheep();
        spawnObject.Score(1);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "DeathBarrier")
        {
            spawnObject.MoreSheep();
            spawnObject.lives -= 1;
            spawnObject.Score(-1);
            Destroy(gameObject);
        }
    }
}
