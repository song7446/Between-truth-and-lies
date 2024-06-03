using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private int count = 0;
    private int storyCount = 0;

    void Start()
    {
        OpeningScript.instance.openingScript();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            if (TextPrintScript.instance.printBool)
            {
                StoryScript.instance.coroutineSkip();
                TextPrintScript.instance.printBool = false;
            }
            else
            {
                storyProceeding();
                count++;
            }
        }
    }

    void storyProceeding()
    {
        switch (count)
        {
            case 0:
                OpeningScript.instance.openingImageFadeOut();
                break;
            case 1:
                StoryScript.instance.UpdateScript(storyCount);
                storyCount++;
                break;
            case 2:
                PoliceImgScript.instance.policeImageFadeIn();
                break;
            case 3:
                StoryScript.instance.UpdateScript(storyCount);
                storyCount++;
                break;
            case 4:
                StoryScript.instance.UpdateScript(storyCount);
                storyCount++;
                break;
            case 5:
                StoryScript.instance.UpdateScript(storyCount);
                storyCount++;
                break;
            case 6:
                StoryScript.instance.UpdateScript(storyCount);
                storyCount++;
                break;
        }
    }
}
