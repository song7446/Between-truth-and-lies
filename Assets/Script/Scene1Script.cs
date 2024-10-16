using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1Script : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static Scene1Script instance;
    
    private void Awake()
    {
        if (Scene1Script.instance == null)
        {
            Scene1Script.instance = this;

        }
    }

    // ���丮 ���� 
    public bool storyEnd = false;

    // ��#1 ���丮 ��ũ��Ʈ
    public string ScriptCollection(int num)
    {
        // ��ȯ�� �ؽ�Ʈ ���� �ʱ�ȭ 
        string scriptText = "";

        // ���丮 ��ũ��Ʈ 
        string[] storyScript = {"�̰��ΰ�?", "���̽��ϱ� �����", "�׷� ���� ������ ������ ��.", "������ ����� �ƴմϴ�.", "�� ���� ��� ���� �ƹ����� �����߽��ϴ�.", "�Ű�� ���� ����?", "�װ� �� ������ �߽��ϴ�.",
                                "�ƹ����� �����ϰ� �ٷ� �ڼ��Ѱǰ�...", "���ݱ��� �����غ� �ٷδ�", "��� �����ð� ������ ���ݱ��� ���忡 �ִ� ����� �����ڿ� ������ �ѻ��̰�", "ħ���� ������ ���µ��ٰ�",
                                "��⿡�� ���� �������� ���� �����Դϴ�.","�׷� ���� ���� �� �ƴѰ�?","�� �̷��� ����� ����?" ,"�װ�...", "�� ���� Ư���� ���� �־���?", "�����ڰ� ���ϱ�δ�",
                                "�ڽ��� ������ �͵� �°� �ڼ��ϴ� �͵� �´ٰ� �ϴµ�", "��ü������ ��� �������� �ʽ��ϴ�.", "�׳� �ڽ��� �� ���̶�� �� �ܿ��� �ƹ� ��⵵ ���մϴ�.","��..." ,"���𰡸� ����� �ֱ�.",
                                "�׸��� ��...","����?" , "�Ű� �ð��� ��� ��û �ð��� �� ���̰� ���ϴ�.","���ŵ� ���Դٸ�" , "�������� ���� �ƴ� ���� �ִ� �� �ƴѰ�" ,
                                "�׷����� ������ �����ڰ� ���� ��⸦ �������� �ʾƼ� �� ���� �����ϴ�", "��..." , "���� ���⵵ ��������� �ʾ���?" , "�׷��� �ѵ� ��Ȳ�� ���������� ���Դϴ�." ,
                                "..." , "���� �γ������ ���� �ʾҳ�?" , "�½��ϴ�.", "����...", "������� ��ġ ������..." };
        try
        {
            // ���丮 ī��Ʈ�� �´� �ؽ�Ʈ ����
            scriptText = storyScript[num];
        }
        // ���丮�� ������
        catch (IndexOutOfRangeException)
        {
            // �߰��� ������ ����ٸ�
            if (CombinationButtonScript.Instance.ansCheckBool)
            {
                // ������ �̹��� ��Ȱ�� 

                // ������ �ؽ�Ʈ ���� 
                OpeningScript.instance.openingTxt.text = "";

                // ������ �̹��� ����ȭ 
                OpeningScript.instance.obgsp.color = new Color(0,0,0,0);

                // ������ �̹��� Ȱ��ȭ 
                OpeningScript.instance.openingBackGround.SetActive(true);

                // ������ �̹��� ���̵��� �ڷ�ƾ 
                StartCoroutine(FadeInOut.instance.FadeOut(OpeningScript.instance.obgsp, 0.25f));

                // 10�� �� ���� �� �ε� 
                Invoke("nextSceneLoad", 10);
            }
            // �߰��� ������ �������� ��� 
            else
            {
                // ���� �̹��� Ȱ��ȭ 
                EndingScript.instance.endFrontGround.SetActive(true);

                // ���� �̹��� ���̵���
                StartCoroutine(FadeInOut.instance.FadeOut(EndingScript.instance.endFrontGround.GetComponent<Image>(), 0.25f));

                // ���� �ؽ�Ʈ ���̵���
                StartCoroutine(FadeInOut.instance.FadeOut(EndingScript.instance.endingText, 0.25f));
            }

            // ���丮 ����� ���� ��ȯ
            storyEnd = true;
        }

        // ���丮 ī��Ʈ�� �´� �ؽ�Ʈ ��ȯ 
        return scriptText;
    }

    // ��#1 ȭ�� �̸� ��ũ��Ʈ
    public string NameCollection(int num)
    {
        // ��ȯ�� �̸� ���� �ʱ�ȭ 
        string name = "";

        // ȭ�� �̸� 
        string[] nameScript = { "���ΰ�", "�Ĺ� ����", "���ΰ�", "�Ĺ� ����", "�Ĺ� ����", "���ΰ�", "�Ĺ� ����",
                                "���ΰ�","�Ĺ� ����", "�Ĺ� ����","�Ĺ� ����",
                                "�Ĺ� ����","���ΰ�","���ΰ�", "�Ĺ� ����","���ΰ�" ,"�Ĺ�����",
                                "�Ĺ� ����","�Ĺ� ����","�Ĺ� ����","���ΰ�","���ΰ�",
                                "�Ĺ� ����", "���ΰ�","�Ĺ� ����","���ΰ�","���ΰ�",
                                "�Ĺ� ����","���ΰ�","���ΰ�","�Ĺ� ����",
                                "���ΰ�", "���ΰ�","�Ĺ� ����","���ΰ�","���ΰ�"};
        try
        {
            // ���丮 ī��Ʈ�� �´� �̸� ���� 
            name = nameScript[num];
        }
        // ���丮�� ������ 
        catch (IndexOutOfRangeException)
        {
            // ���丮 ���� ����� ��ȯ 
            storyEnd = true;
        }

        // ���丮 ī��Ʈ�� �´� �̸� ��ȯ 
        return name;
    }


    // ���� �� �ε� �Լ� 
    public void NextSceneLoad()
    {
        SceneManager.LoadScene("Scene#2");
    }
}

