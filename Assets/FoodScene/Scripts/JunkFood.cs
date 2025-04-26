using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFood : MonoBehaviour
{
    
    Transform tr;

    void Start()
    {
       tr = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.position -= new Vector3(0f, 0.12f, 0f);

        if (tr.position.y < -7f) 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fish")
        {
            Destroy(this.gameObject);
            Fish fish = collision.gameObject.GetComponent<Fish>();
            fish.RemoveHunger(25);
            if(fish.hunger == 0) {
                Destroy(collision.gameObject);
            }
        }
    }
}
