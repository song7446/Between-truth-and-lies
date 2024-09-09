using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public static EndingScript instance;

    private void Awake()
    {
        if (EndingScript.instance == null)
        {
            EndingScript.instance = this;
        }
    }

    public GameObject endFrontGround;
    public Text endingText;
    public bool endingImgBool;

    void Start()
    {
        endFrontGround.SetActive(false);
    }

    void Update()
    {
        
    }
}
