using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void SwapScene(string s)
    {
        SceneManager.LoadScene(s);
    }
}
