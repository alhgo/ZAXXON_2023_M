using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{

    [SerializeField] TMP_Text text_music;
    [SerializeField] Slider sliderMusic;
    float sliderMusicValue;

    //Control de la mesa de sonido
    [SerializeField] AudioMixer audioMixer;

    private void Start()
    {
        //ActualizarSliderMusic();

        //Ajusto el volumen del Audio Mixer
        sliderMusic.value = GameManager.volumeMusic;
        float dbs = 20 * Mathf.Log10(GameManager.volumeMusic);
        audioMixer.SetFloat("VolumeMusic", dbs);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ActualizarSliderMusic()
    {
        if(sliderMusic != null)
        {
            sliderMusicValue = sliderMusic.value;
            GameManager.volumeMusic = sliderMusicValue;

            //Actualizo el texto
            text_music.text = sliderMusicValue.ToString();

            //Ajusto el volumen del Audio Mixer
            float dbs = 20 * Mathf.Log10(sliderMusicValue);
            
            audioMixer.SetFloat("VolumeMusic", dbs);

            

        }
        
    }
}
