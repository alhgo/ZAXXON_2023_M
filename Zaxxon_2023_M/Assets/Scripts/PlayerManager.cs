using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] float speedDespl;
    [SerializeField] float speedRotation;
    [SerializeField] float moveY;
    [SerializeField] float moveX;
    //[SerializeField] float rotation;
    float maxRotZ = 60f;
    float maxRotX = 30f;

    [SerializeField] bool alive = true;

    //Valores para el suavizado en la rotacion
    [SerializeField] float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;

    //Limites
    float limitX = 50f;
    float limitXY = 60f;

    // Start is called before the first frame update
    void Start()
    {
        speedDespl = 80f;
        //speedRotation = 2f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
            MoverNave();
            Rotar();
        }
            
    }

    void MoverNave()
    {
        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        //rotation = Input.GetAxis("HorizontalJ2");
        /*
        transform.position += Vector3.up * moveY * Time.deltaTime * speed;
        transform.position += Vector3.right * moveX * Time.deltaTime * speed;
        */
        transform.Translate(Vector3.up * moveY * Time.deltaTime * speedDespl, Space.World);
        transform.Translate(Vector3.right * moveX * Time.deltaTime * speedDespl, Space.World);

        if(transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, 0f);
        }
        else if(transform.position.x < -limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y, 0f);
        }



    }

    void Rotar()
    {
        //transform.Rotate(Vector3.forward * Time.deltaTime * -speedRotation * 360f * rotation);
        //transform.rotation = Quaternion.Euler(Vector3.forward * -maxRot * moveX);

        //Sumo el vector de rotacion en Z mas el de rotacion en X parabascrular
        Vector3 vectorRotZ = Vector3.forward * -maxRotZ * moveX;
        Vector3 vectorRotX = Vector3.right * -maxRotX * moveY;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;
    }
}
