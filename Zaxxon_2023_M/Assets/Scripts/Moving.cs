using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float speedRotation;
    [SerializeField] float moveY;
    [SerializeField] float moveX;
    [SerializeField] float rotation;
    float maxRot = 60f;

    [SerializeField] bool alive = true;


    // Start is called before the first frame update
    void Start()
    {
        speed = 50f;
        speedRotation = 2f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
            MoverNave();
    }

    void MoverNave()
    {
        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        rotation = Input.GetAxis("HorizontalJ2");
        /*
        transform.position += Vector3.up * moveY * Time.deltaTime * speed;
        transform.position += Vector3.right * moveX * Time.deltaTime * speed;
        */
        transform.Translate(Vector3.up * moveY * Time.deltaTime * speed, Space.World);
        transform.Translate(Vector3.right * moveX * Time.deltaTime * speed, Space.World);

        //transform.Rotate(Vector3.forward * Time.deltaTime * -speedRotation * 360f * rotation);
        transform.rotation = Quaternion.Euler(Vector3.forward * -maxRot * moveX);
       
    }
}
