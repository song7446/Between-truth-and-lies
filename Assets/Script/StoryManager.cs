using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private int count = 0;

    void Start()
    {
        OpeningScript.instance.openingScript();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            storyProceeding();
            count++;
        }
    }

    void storyProceeding()
    {
        switch (count)
        {
            case 0:
                OpeningScript.instance.openingImage();
                break;
            case 1:
                break;
            case 2:
                PoliceImgScript.instance.policeImageFadeIn();
                break;
        }
    }
}
