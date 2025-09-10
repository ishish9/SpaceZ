using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    void Start()
    {
        Application.targetFrameRate = 120;
        AudioManager.instance.PlayMusic(AudioManager.instance.audioClips.MainMenuMusic);
    }
}
