using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public Text ScriptTxt;
    public Text Name;

    GameObject countObj;
    GameObject textObj;

    string juniorDetective = "후배 형사";
    string protagonist = "주인공";

    private string text;
    private float delay = 0.05f;

    int scriptCount = 0;
    bool printBool = true;

    void Start()
    {
        countObj = GameObject.Find("BackGround");
        textObj = GameObject.Find("Scene1ScriptObj");
    }

    void Update()
    {
        int exCount = scriptCount;
        scriptCount = countObj.GetComponent<BackgroundScript>().count;
        if(exCount != scriptCount)
        {
            printBool = true;
        }

        if (printBool)
        {
            updateScript();
            printBool = false;
        }
    }


    void updateScript()
    {
        text = textObj.GetComponent<Scene1Script>().scriptCollection(scriptCount);
        string name = textObj.GetComponent<Scene1Script>().nameCollection(scriptCount);

        Name.text = name;
        ScriptTxt.text = "";
        StartCoroutine(textPrint(delay));
    }

    IEnumerator textPrint(float d)
    {
        int count = 0;

        while (count != text.Length)
        {
            if (count < text.Length)
            {
                ScriptTxt.text += text[count].ToString();
                count++;
            }

            yield return new WaitForSeconds(d);
        }
    }
}
