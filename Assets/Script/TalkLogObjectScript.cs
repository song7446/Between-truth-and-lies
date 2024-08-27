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

    public Text Name;
    public Text Text;

    private void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ㅇㅁㄻㅇㄴㄹ");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("텍스트 버튼 클릭");
            Vector2 mousePosition = Input.mousePosition;
            TextUseButtonScript.instance.textUseBtn.transform.position = mousePosition;
            TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(true);
            Name.color = Color.red;
            Text.color = Color.red;
        }
    }
}
