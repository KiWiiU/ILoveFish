using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    // value for the timer for when the objects get summoned
    float timer = 1;
    // game object array to store all of the objects
    public GameObject[] gm;
    // boolean that lets the generator know its safe to run the code
    public bool run;

    // Start is called before the first frame update
    void Start()
    {
        // set run to false and use the IEumerator to make it true after 5 seconds when the intro screen goes away
        run = false;
        StartCoroutine("StartGame");
    }

    // method to start generator after 5 seconds (when the intro screen goes away)
    IEnumerator StartGame() {
        yield return new WaitForSeconds(5f);
        run = true;
    }

    // Update is called once per frame
    void Update()
    {
        // conditional to ensure that no code starts until the generator has the all clear to run (i.e. run var is true)
        if (run)
        {
            // decrease the timer if it's above 0
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            } 
            else 
            {
                // *if it is not above 0, this code will run meaning that it will summon a random object

                // chance is used to determine if an object created is good or bad
                int chance = Random.Range(1, 101);
                // determine which of the foods will be summoned (there are 5 in each category)
                int type = Random.Range(1, 6);
                // pick a random position on a small range
                float pos_x = Random.Range(-4.0f, 4.0f);

                // if chance is less than 40%, it will create an unhealthy game object
                if (chance <= 40) 
                {
                    // create a new, upscaled, unhealthy game object with a velocity and prefab (in gm array)
                    GameObject obj = Instantiate(gm[type + 4], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
                    obj.transform.localScale *= 1.5f;
                }
                else
                {
                    // create a new, upscaled, unhealthy game object with a velocity and prefab (in gm array)
                    GameObject obj = Instantiate(gm[type - 1], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
                    obj.transform.localScale *= 1.5f;
                }

                // reset the timer
                timer = 0.7f;
            }
        }
    }
}
