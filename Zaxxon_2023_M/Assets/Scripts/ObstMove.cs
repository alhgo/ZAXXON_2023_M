using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstMove : MonoBehaviour
{
    float speed;
    //Creo una instancia de PlayerManager VACIA
    PlayerManager playerManager;


    // Start is called before the first frame update
    void Start()
    {
        //En cuanto salga a escena busca el GameObject que tiene el componente PlayerManager donde esta la velocidad
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();    
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 patras = Vector3.back * Time.deltaTime * speed;
       // Vector3 pabajo = Vector3.down * Time.deltaTime * 9.8f;
        //Vector3 despl = patras + pabajo;
        speed = playerManager.speed;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if(transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
