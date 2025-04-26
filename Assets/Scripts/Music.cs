using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance = null;
    public static Music Instace { get { return instance; } }
    // This makes sure that the object that plays the music is not destroyed between scenes so the music always continues
    void Awake()
    {
       if(instance == null)
        {
            instance = this;
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
        }
       if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

}
