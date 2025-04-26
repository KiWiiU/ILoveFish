using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyFood : MonoBehaviour
{
    // variables reference a main object that controls the minigame
    main main;
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
       tr = GetComponent<Transform>(); 
       main = GameObject.Find("scripts").GetComponent<main>();
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
        if (collision.gameObject.name == "Herring")
        {
            Destroy(this.gameObject);
            main.ScoreAdd();
            collision.gameObject.GetComponent<Fish>().AddHunger(3);
        }
    }
}
