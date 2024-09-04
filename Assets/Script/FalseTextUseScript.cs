using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTextUseScript : MonoBehaviour
{
    public static FalseTextUseScript instance;

    private void Awake()
    {
        if (FalseTextUseScript.instance == null)
        {
            FalseTextUseScript.instance = this;

        }
    }

    public GameObject falTxtObj;

    void Start()
    {
        falTxtObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
