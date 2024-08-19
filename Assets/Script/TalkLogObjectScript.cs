using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkLogObjectScript : MonoBehaviour
{
    public static TalkLogObjectScript instance;
    
    private void Awake()
    {
        if (TalkLogObjectScript.instance == null)
        {
            TalkLogObjectScript.instance = this;

        }
    }

    public Text Name;
    public Text Text;
}
