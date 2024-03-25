using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public float fadeSpeed = 0.25f;
    public bool fadeInOnStart = true;
    public bool fadeOutOnExit = true;

    GameObject gc;
    SpriteRenderer sr;

    void Start()
    {
        gc = GameObject.Find("PoliceImg");
        sr = gc.GetComponent<SpriteRenderer>();
        sr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        //if (fadeInOnStart)
        //{
        //    Debug.Log(sr);
        //    sr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        //    StartCoroutine(FadeIn());
        //}
    }

    void Update()
    {
        if (fadeInOnStart && Input.GetMouseButtonUp(0))
        {
            Debug.Log(sr);
            sr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        float fade = 0.0f;
        while (sr.material.color.a < 1.0f)
        {
            fade += Time.deltaTime * fadeSpeed;
            sr.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float fade = 1.0f;
        while (sr.material.color.a > 0.0f)
        {
            fade -= Time.deltaTime * fadeSpeed;
            sr.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }
    }
}
