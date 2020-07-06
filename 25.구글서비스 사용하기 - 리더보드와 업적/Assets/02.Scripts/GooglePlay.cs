using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlay : MonoBehaviour
{
    public Text scoreText;
    public Text myLog;
    public RawImage myImage;

    private bool bWaitingForAuth = false;

    static long myScore = 100;
    static long myTime = 90000;

    void Awake()
    {
        myLog.text = "Ready...";

        // 구글게임서비스 활성화(초기화)
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    void Start()
    {
        // 게임 시작시 자동 로그인
        doAutoLogin();
    }
    ///////////////////////////////////////////////////////////////////
    // 자동 로그인
    public void doAutoLogin()
    {
        myLog.text = "...";
        if (bWaitingForAuth)
            return;

        // 구글 로그인이 되어있지 않다면
        if (!Social.localUser.authenticated)
        {
            myLog.text = "Authenticating...";
            bWaitingForAuth = true;

            // 로그인 인증 처리과정(콜백함수)
            Social.localUser.Authenticate(AuthenticateCallback);
        }
        else
        {
            myLog.text = "Login Fail\n";
        }
    }
    // 수동 로그인
    public void OnBtnLoginClicked()
    {
        //이미 인증된 사용자는 바로 로그인 성공된다.
        if (Social.localUser.authenticated)
        {
            Debug.Log(Social.localUser.userName);
            myLog.text = "name : " + Social.localUser.userName + "\n";
        }
        else
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log(Social.localUser.userName);
                    myLog.text = "name : " + Social.localUser.userName + "\n";
                }
                else
                {
                    Debug.Log("Login Fail");
                    myLog.text = "Login Fail\n";
                }
            });
    }
    // 수동 로그아웃
    public void OnBtnLogoutClicked()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
        myLog.text = "LogOut...";
    }
    ///////////////////////////////////////////////////////////////////
    // 인증 Callback
    void AuthenticateCallback(bool sucess)
    {
        myLog.text = "Loding";
        if (sucess)
        {
            // 사용자 이름을 띄어줌
            myLog.text = "Welcome" + Social.localUser.userName + "\n";

            StartCoroutine(UserPictureLoad());
        }
        else
        {
            myLog.text = "Login Fail\n";
        }
    }

    // 유저 이미지 받아오기
    IEnumerator UserPictureLoad()
    {
        myLog.text = "image Loding...";
        //// 최초 유저 이미지 가져오기
        Texture2D pic = Social.localUser.image;

        // 구글 아바타 이미지 여부를 확인 후 이미지 생성
        while (pic == null)
        {
            pic = Social.localUser.image;
            yield return null;
        }
        myImage.texture = pic;
        myLog.text = "image Create";
    }

    // 업적(1회성)
    public void doAchievementOne()
    {
        myLog.text = "doAchievementOne called...";

        string unLock_id = "CgkI9unB1csCEAIQBA";
        Social.ReportProgress(unLock_id, 100.0f,
                             (bool sucess) =>
                             {
                                 myLog.text = "Dod";
                             });
    }

    // 업적(단계별)
    public void doAchievementStep()
    {
        myLog.text = "doAchievementStep called...";

        string unLockAchievement_id = "CgkI9unB1csCEAIQBQ";
        Social.ReportProgress(unLockAchievement_id, 100.0f,
                             (bool sucess) =>
                             {
                                 myLog.text = "doAchievementStep ReportProgress...";
                             });
    }

    // 업적 보기
    public void doAchievementShow()
    {
        myLog.text = "doAhievementShow called...";
        Social.ShowAchievementsUI();
    }

    // 리더보드 보기
    public void doLeaderboardShow()
    {
        myLog.text = "doLeaderboardShow called...";
        Social.ShowLeaderboardUI();
    }
}


