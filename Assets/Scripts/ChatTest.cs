using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Photon.Chat;
using UnityEngine.SceneManagement;

/*
 기본적인 서버 연결 및 채팅 ,오류까진 구현이 되어 있고 
 귓속말 , 시스템 말, 이름 바꾸기, 스크롤바 등 다른것은 전부 저희가 구현하였습니다.
 그리고 여기서 사용한 그림들도 전부 저희가 자체 제작하여 사용하였습니다.

 그리고 유니티에 구현이 되어 있는것들은 전부 저희가 하였습니다. (배치 밑 기능넣는것)

  참고한 사이트 : https://photonkr.tistory.com/category/Photon/Chat (하지만 정보가 띄엄띠엄있어서 스크립트만 참고함)

 *Photon chat에 대한 정보가 너무 없어서 구현하기가 힘들었어요..
*/

public class ChatTest : MonoBehaviour, IChatClientListener
{

    private ChatClient chatClient;      //서버
    private string userName;        //유저이름 
    private string currentChannelName;      //방이름

    public InputField inputField;   //입력창
    public Text outputText;     //보여주는창
    public ScrollRect scrollRect;
    public float textsize = 14;

    public float height = 551;  //창크기
    public float width = 851;   //창크기

    public GameObject Endbutton;    //게임끄는 버튼

    // Use this for initialization
    void Start()
    {

        Application.runInBackground = true;
        userName = User.Name;
        currentChannelName = EnterRoom.ChannelName;     //채널이름

        chatClient = new ChatClient(this);      //채팅 방?
        chatClient.Connect(ChatSettings.Instance.AppId, "1.0", new AuthenticationValues(userName)); //연결

        AddLine(string.Format("연결시도", userName));   //연결시도 한다는것을 알려주기 위함 _기능x

    }

    public void AddLine(string lineString)      //채팅 올라오게 하는거
    {
        outputText.text += lineString + "\r\n";
    }

    public void OnApplicationQuit()    //나가는거?
    {
        if (chatClient != null)
        {
            chatClient.Disconnect();
        }
    }

    public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)  //오류생기면 어떤오류인지 보여줌
    {
        if (level == ExitGames.Client.Photon.DebugLevel.ERROR)
        {
            Debug.LogError(message);
        }
        else if (level == ExitGames.Client.Photon.DebugLevel.WARNING)
        {
            Debug.LogWarning(message);
        }
        else
        {
            Debug.Log(message);
        }
    }

    public void OnConnected()
    {
        AddLine("서버에 연결되었습니다.");

        chatClient.Subscribe(new string[] { currentChannelName }, 10);  //currentChannelName이름 서버연결
    }

    public void OnDisconnected()
    {
        AddLine("서버에 연결이 끊어졌습니다.");
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log("OnChatStateChange = " + state);
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        AddLine(string.Format("채널 입장 ({0})", string.Join(",", channels)));
    }

    public void OnUnsubscribed(string[] channels)
    {
        AddLine(string.Format("채널 퇴장 ({0})", string.Join(",", channels)));
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)  //내가 메시지를 받을떄
    {
        if (EndWordGameCheak == true)
        {
            if (messages[messages.Length - 1].ToString().Contains("(#4)"))  //끝났는지 체크
            {
                EndWordGameCheak = false;
            }
            //첫단어인지 체크
            if (messages[messages.Length - 1].ToString().Substring(messages.Length,1).Equals("@")) FristWord = true;

            GetWord = messages[messages.Length - 1].ToString();
            GetWord = GetWord.Trim();
            GetWord = GetWord.Substring(GetWord.Length - 1, 1);

            for (int i = 0; i < messages.Length; i++)
            {
                AddLine(string.Format("{0} : {1}", senders[i], messages[i].ToString()));
            }
        }
        else
        {
            // 상대방이 시작하거나 끝낼때 체크하여서 함께 하도록 하는 코드
            if (messages[messages.Length - 1].ToString().Contains("(#1)")) BanwordCheak = true;
            if (messages[messages.Length - 1].ToString().Contains("(#2)")) EndWordGameCheak = true;
            if (messages[messages.Length - 1].ToString().Contains("(#3)")) Character_2_GameCheak = true;
            if (messages[messages.Length - 1].ToString().Contains("(#4)"))
            {
                BanwordCheak = false;
                EndWordGameCheak = false;
                Character_2_GameCheak = false;
            }

            for (int i = 0; i < messages.Length; i++)
            {
                AddLine(string.Format("{0} : {1}", senders[i], messages[i].ToString()));
            }
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)     //귓말이나 시스템으로 메시지를 받을경우
    {
        Debug.Log("OnPrivateMessage : " + message);
        outputText.text += sender + "(whisper): " + message + "\r\n"; //귓말 or 나에게만 보이는
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log("status : " + string.Format("{0} is {1}, Msg : {2} ", user, status, message));
    }

    void Update()
    {
        chatClient.Service();   //서버 돌림
    }

    //정한 금지어들 
    string ban1 = "ㅅㅂ";
    string ban2 = "ㅈㄹ";
    string ban3 = "ㅈㄴ";
    string ban4 = "ㅋㅋㅋ";

    public void Input_OnEndEdit(string text)    //입력할때 사용하는 함수
    {

        if (chatClient.State == ChatState.ConnectedToFrontEnd)
        {
            bool ban1Bool = inputField.text.Contains(ban1);
            bool ban2Bool = inputField.text.Contains(ban2);
            bool ban3Bool = inputField.text.Contains(ban3);
            bool ban4Bool = inputField.text.Contains(ban4);

            if (BanwordCheak == true)   //금지어게임이 시작된다면
            {
                if (inputField.text.Equals("@ㅅㅂ") || inputField.text.Equals("@ㅈㄹ") || inputField.text.Equals("@ㅈㄴ") ||
                               inputField.text.Equals("@ㅋㅋㅋ"))  //정답일때
                {
                    chatClient.PublishMessage(currentChannelName, "정답입니다!!! 게임종료!(#4)"); //메시지 보내는 것
                    SetContentSize();
                    inputField.text = "";
                }
                else if (inputField.text.Length >= 7)
                {
                    if (ban1Bool == true || ban2Bool == true || ban3Bool == true || ban4Bool == true)   //금지어일시
                    {
                        // chatClient.SendPrivateMessage(userName, "금지!");
                        chatClient.PublishMessage(currentChannelName, "님이 금지어발견!"); //다른사람들이 추측할 수 있게 공개적으로 알린다.
                        SetContentSize();
                        inputField.text = "";
                    }
                    else
                    {
                        chatClient.PublishMessage(currentChannelName, inputField.text); //메시지 보내는 것
                        SetContentSize();
                        inputField.text = "";
                    }
                }
                else
                {
                    chatClient.SendPrivateMessage(userName, "7글자 이상으로 적으세요");   //7이하적었다면
                    SetContentSize();
                    inputField.text = "";
                }
            }
            else if (EndWordGameCheak == true)  //끝말잇기 게임이 시작된다면
            {

                if (GetWord == inputField.text.Substring(0, 1) || !FristWord)   //끝말잇기 규칙이 맞다면
                {
                    //chatClient.SendPrivateMessage("User", inputField.text);
                    chatClient.PublishMessage(currentChannelName, inputField.text); 
                    SetContentSize();
                    inputField.text = "";
                    FristWord = true;
                }
                else
                {
                    if (FristWord == true)  //틀릴시
                    {
                        //chatClient.SendPrivateMessage("User", inputField.text);
                        chatClient.PublishMessage(currentChannelName, "게임종료(#4)"); 
                        Endbutton.SetActive(false);
                        SetContentSize();
                        EndWordGameCheak = false;
                        FristWord = false;
                        inputField.text = "";
                    }
                }
            }
            else if (Character_2_GameCheak == true) //2단어게임
            {
                if (inputField.text.Length < 3) //2단어적을때
                {
                    chatClient.PublishMessage(currentChannelName, inputField.text);
                    SetContentSize();
                    inputField.text = "";
                }
                else
                {   //이하로 적을때
                    chatClient.SendPrivateMessage(userName, "2글자 이하로 적으세요");
                    SetContentSize();
                    inputField.text = "";
                }
            }
            else
            {
                chatClient.PublishMessage(currentChannelName, inputField.text); //메시지 보내는 것
                SetContentSize();
                inputField.text = "";
            }
        }
    }


    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    void SetContentSize()   //스크롤바 영역 생기게하는 함수
    {
        height += textsize;
        scrollRect.content.sizeDelta = new Vector2(width, height);
        scrollRect.content.transform.localPosition += Vector3.up * textsize;
    }

    public void setname(string a) //이름정하기
    {
        userName = a;
    }

    public void BackChat()  //뒤로가기
    {
        chatClient.Disconnect();
        SceneManager.LoadScene("Room");
    }

    bool Character_2_GameCheak = false; //2글자게임체크

    bool BanwordCheak = false;    //금지어체크
    bool AnswerCheak = false;   //금지어정답체크

    bool EndWordGameCheak = false;  //끝말잇기 체크
    string GetWord; //끝말잇기 단어
    bool FristWord = false; // 첫단어

    public void BanWordGame()   //금지어게임 설명 및 시작
    {
        if (EndWordGameCheak == false && Character_2_GameCheak == false)
        {
            if (BanwordCheak == false)
            {
                Endbutton.SetActive(true);
                chatClient.PublishMessage(currentChannelName, "님이 게임을 시작하였습니다.\n게임을 시작합니다.\n게임종류: 금지어찾기_7글자이상말하기(#1)\n시작!   정답은 @~ 으로 하세요   ex) @사과 ");
                SetContentSize();
                SetContentSize();
                SetContentSize();
                SetContentSize();
                BanwordCheak = true;
            }
            else
            {
                chatClient.SendPrivateMessage(userName, "!게임진행중입니다!");
                SetContentSize();
            }
        }
        else
        {
            chatClient.SendPrivateMessage(userName, "!게임진행중입니다!");
            SetContentSize();
        }
    }

    public void EndWordGame()   //끝말잇기 게임 설명 및 시작
    {
        if (BanwordCheak == false && Character_2_GameCheak == false)
        {
            if (EndWordGameCheak == false)
            {
                Endbutton.SetActive(true);
                chatClient.PublishMessage(currentChannelName, "님이 게임을 시작하였습니다.\n게임을 시작합니다.\n게임종류: 끝말잇기(#2)\n시작!    시작을 @~ 로 해주세요    ex)@과일");
                SetContentSize();
                SetContentSize();
                SetContentSize();
                SetContentSize();
                EndWordGameCheak = true;
            }
            else
            {
                chatClient.SendPrivateMessage(userName, "!게임진행중입니다!");
                SetContentSize();
            }
        }
        else
        {
            chatClient.SendPrivateMessage(userName, "!게임진행중입니다!");
            SetContentSize();
        }
    }

    public void Character_2_Game()      //2글자로만 말하는 게임설명 및 시작
    {
        if (EndWordGameCheak == false && BanwordCheak == false)
        {
            if (Character_2_GameCheak == false)
            {
                Endbutton.SetActive(true);
                chatClient.PublishMessage(currentChannelName, "님이 게임을 시작하였습니다.\n게임을 시작합니다.\n게임종류: 2글자로만 말하기(#3)\n시작");
                SetContentSize();
                SetContentSize();
                SetContentSize();
                SetContentSize();
                Character_2_GameCheak = true;
            }
            else
            {
                chatClient.SendPrivateMessage(userName, "!게임진행중입니다!");
                SetContentSize();
            }
        }
        else
        {
            chatClient.SendPrivateMessage(userName, "!게임진행중입니다!");
            SetContentSize();
        }
    }

    public void EndGame()   //모든게임 중간종료
    {
        if (EndWordGameCheak == true)
        {
            chatClient.PublishMessage(currentChannelName, "님이 게임을 종료하였습니다(#4)");
            EndWordGameCheak = false;
            Endbutton.SetActive(false);
        }
        else if (BanwordCheak == true)
        {
            chatClient.PublishMessage(currentChannelName, "님이 게임을 종료하였습니다(#4)");
            BanwordCheak = false;
            Endbutton.SetActive(false);
        }
        else if (Character_2_GameCheak == true)
        {
            chatClient.PublishMessage(currentChannelName, "님이 게임을 종료하였습니다(#4)");
            Character_2_GameCheak = false;
            Endbutton.SetActive(false);
        }
    }
}
