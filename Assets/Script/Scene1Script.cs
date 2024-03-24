using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Script : MonoBehaviour
{
    public string scriptCollection(int num)
    {
        string scriptText = "";
        switch (num)
        {
            case 0:
                scriptText = "오셨습니까 선배님";
                break;
            case 1:
                scriptText = "그래 무슨 일인지 설명해 봐.";
                break;
            case 2:
                scriptText = "복잡한 사건은 아닙니다.";
                break;
            case 3:
                scriptText = "이 집에 살던 딸이 아버지를 살해했습니다.";
                break;
            case 4:
                scriptText = "신고는 누가 했지?";
                break;
            case 5:
                scriptText = "그게 딸 본인이 했습니다.";
                break;
            case 6:
                scriptText = "지금까지 조사해본 바로는";
                break;
            case 7:
                scriptText = "사망 추정시각 전부터 지금까지 현장에 있던 사람이 피해자와 용의자 둘뿐이고";
                break;
            case 8:
                scriptText = "침입의 흔적도 없는데다가";
                break;
            case 9:
                scriptText = "흉기에서 딸의 지문까지 나온 상태라서요.";
                break;
            case 10:
                scriptText = "아버지를 살해하고 바로 자수라...";
                break;
            case 11:
                scriptText = "그런데 그게...";
                break;
            case 12:
                scriptText = "왜";
                break;
            case 13:
                scriptText = "무슨 특이한 점이 있었나?";
                break;
            case 14:
                scriptText = "용의자가 말하기로는 ";
                break;
            case 15:
                scriptText = "자신이 살해한 것도 맞고 자수하는 것도 맞다고 하는데";
                break;
            case 16:
                scriptText = "구제척으로 설명을 해주지 않습니다.";
                break;
            case 17:
                scriptText = "그냥 자신이 한 것이라는 것 외에는 아무 얘기도 안합니다.";
                break;
            case 18:
                scriptText = "무언가를 숨기고 있군.";
                break;
            case 19:
                scriptText = "그리고 또 하나 이상한 점이 있습니다.";
                break;
            case 21:
                scriptText = "뭔데?";
                break;
            case 22:
                scriptText = "신고 시간과 사망 추청 시간이 좀 차이가 납니다.";
                break;
            case 23:
                scriptText = "증거도 나왔다며";
                break;
            case 24:
                scriptText = "차이는 좀 있을 수도 있는 것 아닌가";
                break;
            case 25:
                scriptText = "그럴수도 있지만 용의자가 무슨 얘기를 해주지를 않아서 알 수가 없습니다";
                break;
            case 26:
                scriptText = "음...";
                break;
            case 27:
                scriptText = "살해 동기도 얘기해주지 않았지?";
                break;
            case 28:
                scriptText = "그렇긴 한데 정황상 성폭행인 것으로 보입니다.";
                break;
            case 29:
                scriptText = "...";
                break;
            case 30:
                scriptText = "둘이 부녀관계라고 하지 않았나?";
                break;
            case 31:
                scriptText = "맞습니다.";
                break;
            case 32:
                scriptText = "젠장...";
                break;
        }

        return scriptText;
    }

    public string nameCollection(int num)
    {
        string name = "";

        string juniorDetective = "후배 형사";
        string protagonist = "주인공";

        switch (num)
        {
            case 0:
                name = juniorDetective;
                break;
            case 1:
                name = protagonist;
                break;
            case 2:
                name = juniorDetective;
                break;
            case 3:
                name = juniorDetective;
                break;
            case 4:
                name = protagonist;
                break;
            case 5:
                name = juniorDetective;
                break;
            case 6:
                name = juniorDetective;
                break;
            case 7:
                name = juniorDetective;
                break;
            case 8:
                name = juniorDetective;
                break;
            case 9:
                name = juniorDetective;
                break;
            case 10:
                name = protagonist;
                break;
            case 11:
                name = juniorDetective;
                break;
            case 12:
                name = protagonist;
                break;
            case 13:
                name = protagonist;
                break;
            case 14:
                name = juniorDetective;
                break;
            case 15:
                name = juniorDetective;
                break;
            case 16:
                name = juniorDetective;
                break;
            case 17:
                name = juniorDetective;
                break;
            case 18:
                name = protagonist;
                break;
            case 19:
                name = juniorDetective;
                break;
            case 21:
                name = protagonist;
                break;
            case 22:
                name = juniorDetective;
                break;
            case 23:
                name = protagonist;
                break;
            case 24:
                name = protagonist;
                break;
            case 25:
                name = juniorDetective;
                break;
            case 26:
                name = protagonist;
                break;
            case 27:
                name = protagonist;
                break;
            case 28:
                name = juniorDetective;
                break;
            case 29:
                name = protagonist;
                break;
            case 30:
                name = protagonist;
                break;
            case 31:
                name = juniorDetective;
                break;
            case 32:
                name = protagonist;
                break;
        }

        return name;
    }
}

