using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class Test : MonoBehaviour {

    bool bWaitingForAuth = false;
    bool bImageLoad = false;

    public Text scoreText;
    public Text myLog;
    public RawImage myImage;

    static long myScore = 100;
    static long Score = 00000;

    void Awake()
    {
        myLog.text = "Ready...";

        // 구글게임서비스 활성화(초기화)
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
        {
            return;
        }
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
            myLog.text = "Authentication failed.";
        }
    }

    // 직접 로그인
    public void doMyLogin()
    {
        myLog.text = "...";
        // 로그인 여부 확인
        if (!Social.localUser.authenticated)
        {
            //// 로그인 인증 처리과정
            // 로그인 인증 처리과정(콜백함수)
            Social.localUser.Authenticate(AuthenticateCallback);
        }
        else
        {
            // 로그인 실패
            myLog.text = "Signing out.";
            // 로그 아웃
            ((PlayGamesPlatform)Social.Active).SignOut();
        }
    }

    // 로그아웃
    public void doMyLogout()
    {
        ((GooglePlayGames.PlayGamesPlatform)Social.Active).SignOut();
        myLog.text = "LogOut";
    }

    ///////////////////////////////////////////////////////////////////
    // 업적(1회성)
    public void doAchievementOne()
    {
        myLog.text = "doAchievementOne called...";
        string unLockAchievement_id = "CgkIkLS43ukHEAIQAQ";
        // 업적 등록(아케이먼트ID값, 진행률, 성공여부)
        Social.ReportProgress(unLockAchievement_id, 100.0f, (bool success) =>
        {
            // handle success or failure
            myLog.text = "doAchievementOne ReportProgress...";
        });
    }

    // 업적(단계별)
    public void doAchievementStep()
    {
        myLog.text = "doAchievementStep called...";
        string unLockAchievement_id = "CgkIkLS43ukHEAIQAg";
        // 업적 등록(아케이먼트ID값, 진행률, 성공여부)
        Social.ReportProgress(unLockAchievement_id, 100.0f, (bool success) =>
        {
            // handle success or failure
            myLog.text = "doAchievementStep ReportProgress...";
        });
    }

    // 업적보기
    public void doAchievementShow()
    {
        myLog.text = "doAchievementShow called...";
        // 업적을 보여줌
        Social.ShowAchievementsUI();
    }

    ///////////////////////////////////////////////////////////////////   
    // 리더보드에 점수를 업데이트
    public void LeaderboardUpdate()
    {
        string leader_board_id = "";
        leader_board_id = "CgkIkLS43ukHEAIQAw";

        //(스코어, 리더보드 ID, 성공여부 Callback)
        Social.ReportScore(myScore, leader_board_id, ScoreCallback);
    }

    // 점수 올리기
    public void ScoreUp()
    {
        Score += 100;
        scoreText.text = Score.ToString();
    }


    ///////////////////////////////////////////////////////////////////
    // 인증 Callback
    void AuthenticateCallback(bool sucess)
    {
        myLog.text = "Loding";
        if (sucess)
        {
            // 사용자 이름을 띄어줌
            myLog.text = "Welcome" + Social.localUser.userName;

            StartCoroutine(UserPictureLoad());
        }
        else
        {
            myLog.text = "Authentication failed.";
        }
    }
    // 스코어 Callback
    public void ScoreCallback(bool sucess)
    {
        if (sucess)
        {
            // 리더보드 페이지 출력
            Social.ShowLeaderboardUI();
        }
        else
        {
            // 실패
        }

    }

    // 유저 이미지 받아오기
    IEnumerator UserPictureLoad()
    {
        //// 최초 유저 이미지 가져오기
        Texture2D pic = Social.localUser.image;

        // 구글 아바타 이미지 여부를 확인 후 이미지 생성
        while (pic == null)
        {
            //Rect rect = new Rect(0, 0, tex.width, tex.height);
            //Sprite newSprite = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f), 100);
            pic = Social.localUser.image;
            yield return null;
        }
        myImage.texture = pic;
    }
}
