using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public int score;
    public bool GameOver;
    public GameObject intro;
    public Text scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GameOver = false;
        scoreboard.text = "0";

        StartCoroutine("RemoveBox");
    }

    IEnumerator RemoveBox() {
        yield return new WaitForSeconds(5f);
        intro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreAdd()
    {
        score++;
        scoreboard.text = "" + score;
    }

}
