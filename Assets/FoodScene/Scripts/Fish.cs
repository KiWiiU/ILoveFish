using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    // variables for the fish
    Transform tr;
    // variables managing hunger (like max value and min)
    public int maxHunger = 100;
    public int hunger = 0;
    // game objects for UIs
    public GameObject HungerBar;
    public GameObject end;
    public GameObject failed;
    public generator gen;

    // Start is called before the first frame update
    void Start()
    {
        // Get the fish component for movement
        tr = GetComponent<Transform>();
        // Initialize the hunger value
        AddHunger(0);      
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // move fish right if right key pressed
        if (Input.GetKey("right") == true) 
        {
            if (tr.position.x < 4f) 
            {
                tr.position += new Vector3(0.2f, 0f, 0f);
            }
        }

        // move fish left if left key pressed
        if (Input.GetKey("left") == true) 
        {
            if (tr.position.x > -4f) 
            {
                tr.position += new Vector3(-0.2f, 0f, 0f);
            }
        }
    }

    // method to add to the hunger amount by a certain value
    public void AddHunger(int change) {
        // update the value of hunger by the value and max at 100 if it goes over
        hunger = Mathf.Min(100, hunger+change);
        // update the hunger bar based on new value
        HungerBar.transform.GetChild(1).transform.localScale = new Vector3((float)hunger/maxHunger, 1, 1); 

        // if the hunger bar is at the max value, game over and switch it back to main
        if (hunger == maxHunger) {
            // set the item generator to stop
            gen.run = false;

            // show win screen and set back to main screen
            end.SetActive(true);
            StartCoroutine("Switch2Main");
        }
    }

    // method to switch to main screen after 5 seconds
    IEnumerator Switch2Main() {
        yield return new WaitForSeconds(5f);
        //switch
    }

    // method to remove a certain value from the hunger value
    public void RemoveHunger(int change) {
        // change the hunger value by the certain value and set it to 0 if it becomes negative
        hunger = Mathf.Max(0, hunger-change);
        // modify the hunger bar to reflect the new value
        HungerBar.transform.GetChild(1).transform.localScale = new Vector3((float)hunger/maxHunger, 1, 1); 

        // show the losing screen and switch back to the main screen after 5 seconds if hunger is 0
        if (hunger == 0) {
            failed.SetActive(true);
            StartCoroutine("Switch2Main");
        }
    }
}
