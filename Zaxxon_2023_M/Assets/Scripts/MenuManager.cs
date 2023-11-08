using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    [SerializeField] TMP_Text text_music;
    [SerializeField] Slider sliderMusic;
    float sliderMusicValue;

    private void Start()
    {
        ActualizarSliderMusic();
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ActualizarSliderMusic()
    {
        sliderMusicValue = sliderMusic.value;
        text_music.text = sliderMusicValue.ToString();
    }
}
