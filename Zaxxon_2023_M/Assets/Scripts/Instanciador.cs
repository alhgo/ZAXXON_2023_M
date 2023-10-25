using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject obstacle;

    float distanciaEntreObst = 50f;
    float speed;
    float intervalo;

    //Rango de instanciacion
    float rangoX = 1000f;
    float rangoY = 150f;

    //Variables para los obstaculos intermedios
    float distanciaInst;
    float distaniaPrimerObst;
    float distanciaTotal;
    float numeroObstaculosIniciales;

    [SerializeField] PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        CrearObstaculosIniciales();
        StartCoroutine("Instanciar");

    }

    // Update is called once per frame
    void Update()
    {

        speed = playerManager.speed;
        intervalo = distanciaEntreObst / speed;
        //print(intervalo);

    }

    void CrearObstaculosIniciales()
    {
        distanciaInst = transform.position.z;
        distaniaPrimerObst = 50f;
        distanciaTotal = distanciaInst - distaniaPrimerObst;
        numeroObstaculosIniciales = distanciaTotal / distanciaEntreObst;
        numeroObstaculosIniciales = Mathf.FloorToInt(numeroObstaculosIniciales);
        //print(numeroObstaculosIniciales);

        //Creo el vector donde pondre cada obstaculo
        Vector3 intPos;

        //Creo el bucle
        for(int i = 0; i < numeroObstaculosIniciales ; i++)
        {
            float desplX = Random.Range(rangoX, -rangoX);
            float desplY = Random.Range(10f, rangoY);
            intPos = transform.position - new Vector3(desplX, -desplY, distanciaEntreObst * i);
            Instantiate(obstacle, intPos, Quaternion.identity);
        }
    }

    IEnumerator Instanciar()
    {
        while(GameManager.alive == true)
        {
            float desplX = Random.Range(rangoX, -rangoX);
            float desplY = Random.Range(10f, 150f);
            Vector3 instPos = transform.position + new Vector3(desplX,desplY,0f);
            Instantiate(obstacle, instPos, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);
        }
    }
}
