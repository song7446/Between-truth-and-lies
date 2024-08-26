using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public Button useTextBtn;

    private void Start()
    {
        useTextBtn.onClick.AddListener(useTextBtn_onClick);
    }

    public void useTextBtn_onClick()
    {
        Debug.Log("텍스트 버튼 클릭");
        Vector2 mousePosition = Input.mousePosition;
        TextUseButtonScript.instance.textUseBtn.transform.position = mousePosition;
        TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(true);
        Name.color = Color.red;
        Text.color = Color.red;
    }
}
