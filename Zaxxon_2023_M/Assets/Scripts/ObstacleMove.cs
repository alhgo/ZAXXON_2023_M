using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    PlayerManager playerManager;   
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("Nave").GetComponent<PlayerManager>();  
        //playerManager =
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.speed;
        transform.Translate(Vector3.back *Time.deltaTime * speed);
        if(transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
