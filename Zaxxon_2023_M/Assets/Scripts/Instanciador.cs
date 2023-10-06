using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    //Necesito el prefab que voy a instanciar
    [SerializeField] GameObject columna;

    //El intervalo depende de el espacio entre obst y la velocidad
    float espacioEntre = 30f;
    float speed;
    float interval;

    //Datospara crear las columnas intermedias
    float primeraColumna = 40f;

    //Necesito acceder a la instancia de PlayerManager que tiene la nave
    [SerializeField] PlayerManager playerManager;


    [SerializeField] bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        CrearColumnasIntermedias();

        //CrearColumna();
        StartCoroutine("InstanciarObst");


        
        
        /*
        for(int i = 0; i < 40; i++)
        {

            Instantiate(columna, transform.position, Quaternion.identity);

            transform.position +=  Vector3.right;
        }

       */

    }

    void CrearColumnasIntermedias()
    {
        //Averiguola distancia entre la primera y la instanci
        float distancia = transform.position.z - primeraColumna;
        //Cuantas intermedias hay
        float numCols = distancia / espacioEntre;
        numCols = Mathf.FloorToInt(numCols);
        

       
    }

    IEnumerator InstanciarObst()
    {
        while(alive)
        {
            speed = playerManager.speed;
            interval = espacioEntre / speed;
            //print(interval);
            
            yield return new WaitForSeconds(interval);
            CrearColumna();

        }
        
    }

    void CrearColumna()
    {
        Vector3 instPos = new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f), transform.position.z);
        //transform.position += Vector3.right * Random.Range(-30f, 30f);
        Instantiate(columna,instPos,Quaternion.identity);
        /*
        if(alive)
        {
            Invoke("CrearColumna", interval);
        }

        */
        
        
    }

    private void Update()
    {
        
    }
}
