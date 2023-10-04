using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    float speed = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back *Time.deltaTime * speed);
        if(transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
