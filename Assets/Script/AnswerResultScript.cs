using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerResultScript : MonoBehaviour
{
    public static AnswerResultScript instance;

    private void Awake()
    {
        if (AnswerResultScript.instance == null)
        {
            AnswerResultScript.instance = this;

        }
    }

    public GameObject corObj;
    public GameObject worObj;

    void Start()
    {
        corObj.SetActive(false);
        worObj.SetActive(false);
    }

    void Update()
    {
        
    }
}
