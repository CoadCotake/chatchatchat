using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButton_Thema : MonoBehaviour
{
    //테마 방에서 눌렀을때 버튼이미지 바뀌는

    public Button[] Button; //바뀔 버튼들

    // Start is called before the first frame update
    void Update()
    {
        if (EnterRoom.i == 0)   //기본
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_돌아가기");
        }
        if (EnterRoom.i == 1)   //봄
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_돌아가기");
        }
        if (EnterRoom.i == 2)   //여름
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_돌아가기");
        }
        if (EnterRoom.i == 3)   //가을
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_돌아가기");
        }
        if (EnterRoom.i == 4)   //겨울
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Winter/btn_돌아가기");
        }
    }
}
