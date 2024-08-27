using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TalkLogObjectScript : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Vector2 mousePosition = Input.mousePosition;
            TextUseButtonScript.instance.textUseBtn.transform.position = mousePosition;
            TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(true);
            talkLogObj = Name.transform.parent.gameObject;
            TextUseButtonScript.instance.getTalkObj(talkLogObj);
        }
    }
}