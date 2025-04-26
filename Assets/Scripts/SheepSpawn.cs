using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SheepSpawn : MonoBehaviour
{
    public GameObject sheep;
    public TMP_Text scoreText;
    private int score;
    public int lives;
    // Start is called before the first frame update
    public void Start()
    {
        lives = 3;
        score = 0;
        MoreSheep();
    }

    public void MoreSheep()
    {
        Instantiate(sheep, gameObject.transform);
    }

    public void Score(int change)
    {
        score += change;
        scoreText.text = score.ToString();
        if (lives == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
