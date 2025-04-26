using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SheepSpawn : MonoBehaviour
{
    public GameObject sheep;
    Vector3 pos = new Vector3(10.53, -4.11, 0);
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(sheep, pos);
    }

}
