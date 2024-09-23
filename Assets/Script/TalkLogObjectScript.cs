using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TalkLogObjectScript : MonoBehaviour, IPointerDownHandler
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static TalkLogObjectScript instance;

    private void Awake()
    {
        if (TalkLogObjectScript.instance == null)
        {
            TalkLogObjectScript.instance = this;

        }
    }

    // ��ȭ ��� ������Ʈ 
    public GameObject talkLogObj;

    // ȭ�� �̸� 
    public Text Name;

    // ��ȭ ���� 
    public Text Text;

    private void Start()
    {

    }

    // ��ȭ ��� ������Ʈ Ŭ�� �Լ� 
    public void OnPointerDown(PointerEventData eventData)
    {
        // ��Ŭ���� �� 
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // ���콺 ��ġ ���� 
            Vector2 mousePosition = Input.mousePosition;
            
            // �˾� UI ��ġ ���콺 ��ġ�� ����  
            TextUseButtonScript.instance.textUseBtnObj.transform.position = mousePosition;
            
            // ���õ� ������Ʈ�� �θ� ������Ʈ ã�� = ���õ� ��ȭ ��� ������Ʈ ã��  
            talkLogObj = Name.transform.parent.gameObject;

            // ���õ� ��ȭ ��� ������Ʈ ������
            TextUseButtonScript.instance.GetTalkObj(talkLogObj);

            // �̸� ���� �Ͼ���̸� - �ֿ� �ؽ�Ʈ�� ���õǾ����� �ʾҴٸ�
            if (Name.color==Color.white)
            {
                // �ֿ� �ؽ�Ʈ ��� ��ư Ȱ��ȭ 
                TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(true);

                // ���� �ؽ�Ʈ ��� ��ư ��Ȱ��ȭ 
                TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(false);
            }
            // �̸��� �������̸� - �ֿ� �ؽ�Ʈ�� ���� �Ǿ��ִٸ� 
            else if(Name.color==Color.red) 
            {
                // ���� �ؽ�Ʈ ��� ��ư Ȱ��ȭ 
                TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(true);

                // �ֿ� �ؽ�Ʈ ����ư ��Ȱ��ȭ 
                TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(false);
            }
        }
        // ��Ŭ���� �ƴϸ�
        else
        {
            // �ֿ� �ؽ�Ʈ ��� ��ư ��Ȱ��ȭ 
            TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(false);

            // ���� �ؽ�Ʈ ��� ��ư ��Ȱ��ȭ 
            TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(false);
        }
    }
}