using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class talking : MonoBehaviour {
    public GameObject bubble1, bubble2, bubble3, bubble4, bubbletext;
    // Start is called before the first frame update
    private float bubblestarttime = -10.0f;
    private float spinning = -5;
    public TMP_Text text;
    void Start() {
        bubble1.SetActive(false);
        bubble2.SetActive(false);
        bubble3.SetActive(false);
        bubble4.SetActive(false);
        bubbletext.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        float currtime = Time.time - bubblestarttime;
        spinning += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 90+Mathf.Clamp(spinning, 0, 1)*360, 0);
        if (Random.Range(0f,1f)<0.000001/Time.deltaTime && spinning > 1) {
            spinning = 0;
        }
        if (currtime > 0.5) {
            bubble1.SetActive(true);
        }
        if (currtime > 1) {
            bubble2.SetActive(true);
        }
        if (currtime > 1.5) {
            bubble3.SetActive(true);
        }
        if (currtime > 2) {
            bubble4.SetActive(true);
            bubbletext.SetActive(true);
        }
        if (currtime > 3) {
            bubble1.SetActive(false);
        }
        if (currtime > 3.5) {
            bubble2.SetActive(false);
        }
        if (currtime > 4) {
            bubble3.SetActive(false);
        }
        if (currtime > 4.5) {
            bubble4.SetActive(false);
            bubbletext.SetActive(false);
        }
        if (currtime > 1.5 && currtime < 3.5) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void OnEndEdit(string s) {
        bubblestarttime = Time.time;
        
    }
}

