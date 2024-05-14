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

    private string text;
    private float delay = 0.05f;

    int scriptCount = 0;
    public bool printBool = false;

    void Start()
    {
        countObj = GameObject.Find("CrimeSceneBackGround");
        textObj = GameObject.Find("Scene1ScriptObj");

        ScriptTxt.text = "";
        Name.text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            scriptCount++;
            if (scriptCount % 2 == 0)
            {
                UpdateScript(scriptCount);
            }
        }
    }

    public void UpdateScript(int num)
    {
        text = textObj.GetComponent<Scene1Script>().ScriptCollection(num);
        string name = textObj.GetComponent<Scene1Script>().NameCollection(num);

        Name.text = name;
        ScriptTxt.text = "";
        StartCoroutine(TextPrint(delay));

    }

    public IEnumerator TextPrint(float d)
    {
        int count = 0;
        while (count != text.Length)
        {
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                ScriptTxt.text = text;
                yield break;
            }
            if (count < text.Length)
            {
                ScriptTxt.text += text[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(d);
        }
        scriptCount++;
    }
}
