using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 호출할 씬과 씬 로드 방식을 저장할 딕셔너리
    public Dictionary<string, LoadSceneMode> loadScenes = new Dictionary<string, LoadSceneMode>();

    // 호출할 씬의 정보 설정
    void InitSceneInfo()
    {
        // 호출할 씬의 정보를 딕셔너리에 추가
        loadScenes.Add("Lobby", LoadSceneMode.Additive);
        loadScenes.Add("Room", LoadSceneMode.Additive);
        loadScenes.Add("Game", LoadSceneMode.Additive);
    }

    // CanvasGroup 컴포넌트를 저장할 변수
    public CanvasGroup fadeCg;

    // Fade In 처리 시간
    [Range(0.5f, 2.0f)]
    public float fadeDuration = 1.0f;

    IEnumerator Start()
    {
        InitSceneInfo();

        foreach (var _loadScene in loadScenes)
        {
            yield return StartCoroutine(LoadScene(_loadScene.Key, _loadScene.Value));
        }
    }

    IEnumerator LoadScene(string sceneName, LoadSceneMode mode)
    {
        yield return new WaitForSeconds(fadeDuration);

        // Fade In 함수 호출
        StartCoroutine(Fade(0.0f));

        // 기존의 씬을 언로드
        if (sceneName == "Room")
            SceneManager.UnloadSceneAsync("Lobby");
        else if (sceneName == "Game")
            SceneManager.UnloadSceneAsync("Room");

        // 씬을 로드
        SceneManager.LoadScene(sceneName, mode);
    }

    // Fade In/Out 시키는 함수
    IEnumerator Fade(float finalAlpha)
    {
        // 처음 알파값을 설정(불투명)
        fadeCg.alpha = 1.0f;

        fadeCg.blocksRaycasts = true;

        // 알파값을 조정
        while (!Mathf.Approximately(fadeCg.alpha, finalAlpha))
        {
            // MoveTowoard 함수는 Lerp 함수와 동일한 함수로 알파값을 보간함
            fadeCg.alpha = Mathf.MoveTowards(fadeCg.alpha, finalAlpha, fadeDuration * Time.deltaTime);

            yield return null;
        }
        fadeCg.blocksRaycasts = false;
    }
}
