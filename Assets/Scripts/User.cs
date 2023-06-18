using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class User : MonoBehaviour
{
    public static string Name="User";       //기본이름 및 변수 선언

    public void setname(string name)    //이름 받은 즉시 이름 바꿔주기
    {
        // ChatTest chat = GameObject.Find("EventSystem").GetComponent<ChatTest>();
        // chat.setname(name);
        Name = name;    
        SceneManager.LoadScene("Room");
    }
   
    
    

}
