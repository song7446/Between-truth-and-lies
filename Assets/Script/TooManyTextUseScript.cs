using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooManyTextUseScript : MonoBehaviour
{
    public static TooManyTextUseScript instance;

    private void Awake()
    {
        if (TooManyTextUseScript.instance == null)
        {
            TooManyTextUseScript.instance = this;

        }
    }

    public GameObject tooManyTextUseObj;

    void Start()
    {
        tooManyTextUseObj.SetActive(false);
    }

    void Update()
    {
        
    }
}
