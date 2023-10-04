using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform naveTransform;

    [SerializeField] float offsetZ = 18;
    [SerializeField] float offsetY = 9;

    //Variables para suavizado
    Vector3 currentPos;
    Vector3 smoothMoveVelocity = Vector3.zero;
    float MoveVelocity = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        offsetZ = 25;
        offsetY = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Seguimiento en X, Y pero sin seguir en Z
        Vector3 destino = naveTransform.position - new Vector3(0, -offsetY, offsetZ);
        //transform.position = destino;

        currentPos = Vector3.SmoothDamp(currentPos, destino, ref smoothMoveVelocity, MoveVelocity);

        transform.position = currentPos;
        /*
       transform.position = naveTransform.position - new Vector3(0f, -offsetY, offsetZ) ;    
       transform.LookAt(naveTransform);
        */
    }
}
