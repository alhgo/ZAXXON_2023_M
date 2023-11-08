using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image imageLifes;
    [SerializeField] Sprite[] lifesSprites;

    [SerializeField] TMP_Text textDistancia;

    PlayerManager playerManager;

    float distancia;

    //Barra de escudo
    [SerializeField] Slider sliderShield;

    //Texto con el tiempo transcurrido
    [SerializeField] TMP_Text textoTiempo;
    float tiempoTranscurrido;
    float tiempoAlLanzar;

    //Combustible
    public float combustible;
    [SerializeField] Slider sliderFuel;


    // Start is called before the first frame update
    void Start()
    {
        UpdateLifes();

        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        textDistancia.text = "Hola mundo";

        combustible = 100f;

        //Reseteo los tiempos
        tiempoTranscurrido = 0.0f;
        tiempoAlLanzar = Time.time;

        //Inicio el gasto de combustible
        StartCoroutine("ActualizarCombustible");
    }

    // Update is called once per frame
    void Update()
    {
        
        ActualizarDistancia();

    }

    void ActualizarDistancia()
    {

        tiempoTranscurrido = Time.time - tiempoAlLanzar;

        textoTiempo.text =  Mathf.Round(tiempoTranscurrido) + " segs.";

        distancia = tiempoTranscurrido * playerManager.speed;
        distancia = distancia / 1000f;
        distancia = Mathf.Round(distancia * 100) / 100;

        textDistancia.text = distancia + " Kmts.";
    }

    public void UpdateLifes()
    {
        int n = GameManager.lifes;
        imageLifes.sprite = lifesSprites[n];
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ActualizarBarraEscudo(float escudo)
    {
        sliderShield.value = escudo;
    }

    IEnumerator ActualizarCombustible()
    {
        while(GameManager.alive)
        {
            combustible -= 0.1f;
            sliderFuel.value = combustible;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
