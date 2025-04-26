using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    Transform tr;
    public int maxHunger = 100;
    public int hunger = 0;
    public GameObject HungerBar;
    public GameObject end;
    public GameObject failed;
    public generator gen;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        AddHunger(0);    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("right") == true) 
        {
            if (tr.position.x < 4f) 
            {
                tr.position += new Vector3(0.2f, 0f, 0f);
            }
        }

        if (Input.GetKey("left") == true) 
        {
            if (tr.position.x > -4f) 
            {
                tr.position += new Vector3(-0.2f, 0f, 0f);
            }
        }
    }

    public void AddHunger(int change) {
        hunger = Mathf.Min(100, hunger+change);
        HungerBar.transform.GetChild(1).transform.localScale = new Vector3((float)hunger/maxHunger, 1, 1); 

        if (hunger == maxHunger) {
            gen.run = false;

            end.SetActive(true);
            StartCoroutine("Switch2Main");
        }
    }

    IEnumerator Switch2Main() {
        yield return new WaitForSeconds(5f);
        //switch
    }

    public void RemoveHunger(int change) {
        hunger = Mathf.Max(0, hunger-change);
        HungerBar.transform.GetChild(1).transform.localScale = new Vector3((float)hunger/maxHunger, 1, 1); 
        if (hunger == 0) {
            failed.SetActive(true);
            StartCoroutine("Switch2Main");
        }
    }
}
