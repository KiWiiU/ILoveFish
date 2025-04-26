using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    float timer = 1;
    public GameObject[] gm;
    public bool run;
    // Start is called before the first frame update
    void Start()
    {
        run = false;
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame() {
        yield return new WaitForSeconds(5f);
        run = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            } 
            else 
            {
                int chance = Random.Range(1, 101);
                int type = Random.Range(1, 6);
                float pos_x = Random.Range(-4.0f, 4.0f);

                if (chance <= 40) 
                {
                    GameObject obj = Instantiate(gm[type + 4], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
                    obj.transform.localScale *= 1.5f;
                }
                else
                {
                    GameObject obj = Instantiate(gm[type - 1], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
                    obj.transform.localScale *= 1.5f;
                }

                timer = 0.7f;
            }
        }
    }
}
