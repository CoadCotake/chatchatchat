using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButton_Room : MonoBehaviour
{
    //룸선택방에서 테마가 바뀌었을때 이미지 바꾸는 코드

    public Button[] Button; //바뀔 버튼들

    // Start is called before the first frame update
    void Start()
    {
        if (EnterRoom.i == 0)   //기본
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_Name");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_Theme");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_Chat1");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_Chat2");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_Chat3");
            Button[5].image.sprite = Resources.Load<Sprite>("Button/Default/btn_Default_Chat4");
        }
        if (EnterRoom.i == 1)   //봄
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_NickName");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_Theme");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_Chat1");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_Chat2");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_Chat3");
            Button[5].image.sprite = Resources.Load<Sprite>("Button/Spring/btn_Spring_Chat4");
        }
        if (EnterRoom.i == 2)   //여름
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_닉네임");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_Theme");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_Chat1");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_Chat2");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_Chat3");
            Button[5].image.sprite = Resources.Load<Sprite>("Button/Summer/btn_Summer_Chat4");
        }   
        if (EnterRoom.i == 3)   //가을
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_닉네임");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_Theme");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_Chat1");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_Chat2");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_Chat3");
            Button[5].image.sprite = Resources.Load<Sprite>("Button/Autumn/btn_Autumn_Chat4");
        }
        if (EnterRoom.i == 4)   //겨울
        {
            Button[0].image.sprite = Resources.Load<Sprite>("Button/Winter/닉네임");
            Button[1].image.sprite = Resources.Load<Sprite>("Button/Winter/btn_Winter_Theme");
            Button[2].image.sprite = Resources.Load<Sprite>("Button/Winter/1챗");
            Button[3].image.sprite = Resources.Load<Sprite>("Button/Winter/2챗");
            Button[4].image.sprite = Resources.Load<Sprite>("Button/Winter/3챗");
            Button[5].image.sprite = Resources.Load<Sprite>("Button/Winter/4챗");
        }
        



    }

}
