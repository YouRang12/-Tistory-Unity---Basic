using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ADMgr : MonoBehaviour {

    public Text coinText;
    private int coin = 0;

    // 광고 보여주기
    public void ShowAD()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    // 보상형 광고 보여주기
    public void ShowReward()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAds };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    // 광고 실행 후 결과
    void ResultAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown");
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end");
                break;
            case ShowResult.Finished:
                coin += 100;
                coinText.text = coin.ToString();
                Debug.Log("The ad was successfully shown");
                break;
        }
    }
}


