using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    private AudioSource musicPlayer;         // 음악플레이어
    public AudioClip backgroundMusic;       // 배경음악

    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        playSound(backgroundMusic, musicPlayer); // 배경음악 실행
    }

    public static void playSound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
}

