using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTextObjScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static NoteTextObjScript instance;

    private void Awake()
    {
        if (NoteTextObjScript.instance == null)
        {
            NoteTextObjScript.instance = this;
        }
    }

    // ��ȭ ����� ��Ʈ�� �ؽ�Ʈ�� ��ȯ�ϱ� ���� ��ųʸ�
    public Dictionary<string, string> noteWrites = new Dictionary<string, string>()
    {
        { "�� ���� ��� ���� �ƹ����� �����߽��ϴ�.","���� �ƹ����� ������" },
        { "�װ� �� ������ �߽��ϴ�.","�� ������ ���� �Ű���" },
        { "��� �����ð� ������ ���ݱ��� ���忡 �ִ� ����� �����ڿ� ������ �ѻ��̰�","���忡 �ִ� ����� �����ڿ� ������ �ѻ���" },
        { "ħ���� ������ ���µ��ٰ�","ħ���� ������ ����" },
        { "��⿡�� ���� �������� ���� �����Դϴ�.","��⿡�� �������� �������� �����" },
        { "�ڽ��� ������ �͵� �°� �ڼ��ϴ� �͵� �´ٰ� �ϴµ�","�����ڴ� �ڽ��� ������ ������" },
        { "��ü������ ��� �������� �ʽ��ϴ�.","�����ڴ� �ڽ��� ������ ���������� ������� �����" },
        { "�׳� �ڽ��� �� ���̶�� �� �ܿ��� �ƹ� ��⵵ ���մϴ�.","�����ڴ� �ڽ��� ������ ���������� ������� �����" },
        { "�Ű� �ð��� ��� ��û �ð��� �� ���̰� ���ϴ�.","�Ű� �ð��� ��������ð��� ���̰� ����" },
        { "�׷��� �ѵ� ��Ȳ�� ���������� ���Դϴ�.","���� ����� ���������� ����" },
    };

    // ��Ʈ �ؽ�Ʈ �θ� ������Ʈ
    public GameObject noteTxtObj;

    // ���� �ؽ�Ʈ ������Ʈ 
    public GameObject leftTextObj;

    // �ؽ�Ʈ ������Ʈ
    public GameObject textObj;

    // ��Ʈ �ؽ�Ʈ ������ �ҷ������ ������Ʈ   
    public GameObject loadTextObj;

    // ��Ʈ �ؽ�Ʈ ������Ʈ 
    public GameObject noteTextObj;

    // ȭ�� �̸�
    public Text talkName;

    // ����
    public Text talkText;

    // ��Ʈ �ؽ�Ʈ ������Ʈ �Լ� 
    public bool updateNoteText(GameObject obj)
    {
        // �޾ƿ� ������Ʈ�� �ڽ� ��ҷ� �̸��� ���� �޾ƿ��� / 0 = �̸� 1 = ����
        talkName = obj.transform.GetChild(0).gameObject.GetComponent<Text>();
        talkText = obj.transform.GetChild(1).gameObject.GetComponent<Text>();

        // �޾ƿ� ������ ��ųʸ��� �ִٸ�  
        if (noteWrites.ContainsKey(talkText.text)) 
        {
            // ��Ʈ �ؽ�Ʈ ������ �ҷ����� 
            loadTextObj = Resources.Load<GameObject>("PreFab/NoteText");

            // �ҷ��� ������ ���� 
            noteTextObj = GameObject.Instantiate<GameObject>(loadTextObj);

            // �θ��� ����
            noteTextObj.transform.SetParent(leftTextObj.transform, false);

            // ������Ʈ �̸� ���� 
            noteTextObj.name = talkText.text;

            // ��ȭ ������ ��Ʈ �ؽ�Ʈ�� �°� ���� 
            noteTextObj.GetComponent<Text>().text = talkName.text + "�� ���ϸ� " + noteWrites[talkText.text];

            // ��ȭ ������ ��ųʸ��� �ִٸ� true ��ȯ 
            return true;
        }
        else
        {// ��ȭ ������ ��ųʸ��� ���ٸ� false ��ȯ 
            return false;
        }       
    }

    // ��Ʈ �ؽ�Ʈ ���� �Լ� 
    public void deleteNoteText(GameObject obj)
    {
        // ��Ʈ �ؽ�Ʈ ����� ������ ��� �̸����� ã�� 
        textObj = GameObject.Find(obj.transform.GetChild(1).gameObject.GetComponent<Text>().text);
        // ������Ʈ ���� 
        Destroy(textObj);
    }

    void Start()
    {
        // ��Ʈ �ؽ�Ʈ �θ� ������Ʈ ��Ȱ��ȭ 
        noteTxtObj.SetActive(false);
    }


    void Update()
    {
        
    }
}
