using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpeechSmiley : MonoBehaviour
{
    public TMPro_Text textBox;
    private static string[] motivationalTexts = {
        "Don't let your fish be fish.",
        "Just keep swimming.",
        "Even the smallest fish can make the biggest waves.";
        "You weren't born to stay in the fish bowl: explore the ocean.",
        "A smooth sea never made a skilled fish.",
        "Seas the day.",
        "You're fintastic the way you are.",
        "The world is your oyster.",
        "Don't be afraid to swim against the school.",
        "A fish doesn't wait for the tide, it swims where it needs to go.",
    };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RefreshMotivationalQuote);
    }

    public IEnumerator RefreshMotivationalQuote() {
        Random rnd = new Random();
        while(true) {
            textBox.text = motivationalTexts[rnd.Next(0, motivationalTexts.Length)];
            yield return new WaitForSeconds(3f);
        }
    }
}
