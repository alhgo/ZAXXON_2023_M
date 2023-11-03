using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image imageLifes;
    [SerializeField] Sprite[] lifesSprites;

    [SerializeField] TMP_Text textDistancia;

    PlayerManager playerManager;

    float distancia;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLifes();

        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        textDistancia.text = "Hola mundo";
    }

    // Update is called once per frame
    void Update()
    {
        
        ActualizarDistancia();

    }

    void ActualizarDistancia()
    {
        distancia = Time.time * playerManager.speed;
        distancia = distancia / 1000f;
        distancia = Mathf.Round(distancia * 100) / 100;

        textDistancia.text = distancia + " Kmts.";
    }

    public void UpdateLifes()
    {
        int n = GameManager.lifes;
        imageLifes.sprite = lifesSprites[n];
    }
}
