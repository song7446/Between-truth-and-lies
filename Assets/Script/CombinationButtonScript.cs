using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationButtonScript : MonoBehaviour
{
    public static CombinationButtonScript Instance;

    private void Awake()
    {
        if (CombinationButtonScript.Instance == null)
        {
            CombinationButtonScript.Instance = this;
        }
    }

    public Button comBtn;

    void Start()
    {
        comBtn.onClick.AddListener(comBtn_onClick);
        comBtn.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    void comBtn_onClick()
    {
        Debug.Log("조합 버튼 클릭");
    }
}
