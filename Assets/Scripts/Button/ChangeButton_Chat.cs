using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButton_Chat : MonoBehaviour
{
    //테마가 바뀔시 채팅방 버튼을 바꾸게 하는 코드

    public Button[] Button;     //바뀔 버튼들

    // Start is called before the first frame update
    void Start()
    {
        if (EnterRoom.i == 0)   //기본
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_돌아가기");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_멈춰");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_금칙어");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_끝말잇기");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_두글자");
        }
        if (EnterRoom.i == 1)   //봄
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_돌아가기");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_정지");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_금칙어");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_끝말잇기");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_2글자");
        }
        if (EnterRoom.i == 2)   //여름
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_돌아가기");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_멈춰");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_금칙어");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_끝말잇기");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_두글자");
        }
        if (EnterRoom.i == 3)   //가을
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_돌아가기");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_멈춰");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_금칙어");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_끝말잇기");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_두글자");
        }
        if (EnterRoom.i == 4)   //겨울
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Winter/btn_돌아가기");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Winter/btn_정지");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Winter/btn_금칙어");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Winter/btn_끝말잇기");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Winter/btn_두글자");
        }

    }
}
