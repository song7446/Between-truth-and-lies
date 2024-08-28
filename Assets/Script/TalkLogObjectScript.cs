using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TalkLogObjectScript : MonoBehaviour, IPointerDownHandler
{
    public static TalkLogObjectScript instance;

    private void Awake()
    {
        if (TalkLogObjectScript.instance == null)
        {
            TalkLogObjectScript.instance = this;

        }
    }

    public GameObject talkLogObj;

    public Text Name;
    public Text Text;

    private void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Vector2 mousePosition = Input.mousePosition;
            TextUseButtonScript.instance.textUseBtnObj.transform.position = mousePosition;
         
            talkLogObj = Name.transform.parent.gameObject;
            TextUseButtonScript.instance.getTalkObj(talkLogObj);

            if (Name.color==Color.white)
            {
                TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(true);
                TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(false);
            }
            else if(Name.color==Color.red) 
            {
                TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(true);
                TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(false);
            }
        }
        else
        {
            TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(false);
            TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(false);
        }
    }
}