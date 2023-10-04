using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    //Necesito el prefab que voy a instanciar
    [SerializeField] GameObject columna;

    //El intervalo depende de el espacio entre obst y la velocidad
    float espacioEntre = 10f;
    [SerializeField] float speed = 10f;
    float interval;


    [SerializeField] bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
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

    IEnumerator InstanciarObst()
    {
        while(alive)
        {
            interval = espacioEntre / speed;
            
            yield return new WaitForSeconds(interval);
            CrearColumna();

        }
        
    }

    void CrearColumna()
    {
        Vector3 instPos = new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f), 50f);
        transform.position += Vector3.right * Random.Range(-30f, 30f);
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
