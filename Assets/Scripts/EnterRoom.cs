using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterRoom : MonoBehaviour
{
    
    public static string ChannelName = "Channel 001";   //기본 방
    
    public Image ThemaImage; //기존에 존제하는 이미지
    public Sprite[] ChageSprite; //바뀌어질 이미지
    public static int i = 0;    //바꿀 이미지 번호

    private void Start()
    {
        ThemaImage.sprite = ChageSprite[i]; //이미지 바꾸기
    }

    public void change()    //기본선택
    {
        i = 0;
        ThemaImage.sprite = ChageSprite[i];
    }
    public void change1()   //1번선택
    {
        i = 1;
        ThemaImage.sprite = ChageSprite[i];
    }
        
    public void change2()   //2번선택
    {
        i = 2;
        ThemaImage.sprite = ChageSprite[i];
    }
    public void change3()   //3번선택
    {
        i = 3;
        ThemaImage.sprite = ChageSprite[i];
    }
    public void change4()    //4번선택
    {
        i = 4;
        ThemaImage.sprite = ChageSprite[i];
    }
    

    public void ChangeImage()   
    {
        ThemaImage.sprite = ChageSprite[i]; //이미지 바꾸기
    }

    public void BackChat()  //룸선택창으로 가기
    {
        SceneManager.LoadScene("Room");
    }

    public void thema() //테마창으로 가기
    {
        SceneManager.LoadScene("Thema");
    }

    public void chat1() //1번방
    {
        ChannelName = "chat1";
        SceneManager.LoadScene("MainScene");
    }
    public void chat2() //2번방
    {
        ChannelName = "chat2";
        SceneManager.LoadScene("MainScene");
    }
    public void chat3() //3번방
    {
        ChannelName = "chat3";
        SceneManager.LoadScene("MainScene");
    }
    public void chat4() //4번방
    {
        ChannelName = "chat4";
        SceneManager.LoadScene("MainScene");
    }

    public void Namechoose()    //뒤로가기
    {
        SceneManager.LoadScene("Name");
    }
}
