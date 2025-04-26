using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Outdoors : MonoBehaviour
{
    public bool inAir;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "House")
        {
            SceneManager.LoadScene("SampleScene");
        }
        if(other.gameObject.name == "Trigger")
        {
            inAir = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10f, 0);
            inAir = true;
        }
    }
}
