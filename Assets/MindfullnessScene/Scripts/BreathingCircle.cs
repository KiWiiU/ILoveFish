using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreathingCircle : MonoBehaviour
{
    public RectTransform circle; 
    public TMP_Text messageText; 

    public AudioSource audioSource;
    public AudioClip getReady;
    public AudioClip bIn;
    public AudioClip bOut;
    public AudioClip swim;
    public AudioClip awareness;

    public float smallScale = 0.33f;
    public float largeScale = 1f;
    public float duration = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AwarenessClip());
    }

    IEnumerator AwarenessClip() {
        audioSource.clip = awareness;
        messageText.text = "Bring awareness to your breath";
        audioSource.Play();
        yield return new WaitForSeconds(5f);
        StartCoroutine(SwiMClip());
    }

    IEnumerator SwiMClip() {
        audioSource.clip = swim;
        messageText.text = "Swim like a fish in the sea";
        audioSource.Play();
        yield return new WaitForSeconds(5f);
        StartCoroutine(GetReady());
    }

    IEnumerator GetReady() {
        audioSource.clip = getReady;
        messageText.text = "Get ready";
        audioSource.Play();
        yield return new WaitForSeconds(5f);
        StartCoroutine(BreatheLoop());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BreatheLoop()
    {
        while (true)
        {
            audioSource.clip = bOut;
            audioSource.Play();
            yield return StartCoroutine(ScaleCircle(largeScale, smallScale, "Breathe in"));
            audioSource.clip = bIn;
            audioSource.Play();
            yield return StartCoroutine(ScaleCircle(smallScale, largeScale, "Breathe out"));
        }
    }

    IEnumerator ScaleCircle(float fromScale, float toScale, string message)
    {
        messageText.text = message;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            t = EaseInOut(t);

            float scale = Mathf.Lerp(fromScale, toScale, t);
            circle.localScale = new Vector3(scale, scale, scale);

            yield return null; 
        }

        circle.localScale = new Vector3(toScale, toScale, toScale);
    }

    float EaseInOut(float t)
    {
        return t * t * (3f - 2f * t);
    }

}
