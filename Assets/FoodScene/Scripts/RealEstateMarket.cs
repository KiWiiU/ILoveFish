using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RealEstateMarket : MonoBehaviour
{
    public GameObject house;
    public TMP_Text scoreText;
    private int score;
    public int lives;
    // Start is called before the first frame update
    public void Start()
    {
        lives = 3;
        score = 0;
        StartCoroutine("MakeHouse");
    }

    public void MoreHomes()
    {
        Instantiate(house, gameObject.transform);
    }

    public void Score(int change)
    {
        score += change;
        scoreText.text = score.ToString();
    }
    
    public void Lives(int change)
    {
        lives -= change;
        if (lives == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public IEnumerator MakeHouse()
    {
        while (true) {
            yield return new WaitForSeconds(1.5f);
            MoreHomes();
        }
    }
}
