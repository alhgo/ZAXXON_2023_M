using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform naveTransform;

    [SerializeField] float offsetZ = 7;
    [SerializeField] float offsetY = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Seguimiento en X, Y pero sin seguir en Z
        Vector3 destino = new Vector3(naveTransform.position.x, naveTransform.position.y + offsetY, -offsetZ);
        transform.position = destino;
        /*
       transform.position = naveTransform.position - new Vector3(0f, -offsetY, offsetZ) ;    
       transform.LookAt(naveTransform);
        */
    }
}
