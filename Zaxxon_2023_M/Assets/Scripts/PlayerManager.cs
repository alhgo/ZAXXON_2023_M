using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

   

    float speedRot = 3f;
    [SerializeField] float desplSpeed;
    [SerializeField] float moveY;
    [SerializeField] float moveX;

    //Velocidad de los obstaculos
    public float speed;

    //Limites
    float posX;
    float posY;
    float limitX = 1000f;
    float limitY = 450f;
    bool inlimitX = true;
    bool inlimitY = true;

    float axisRot;

    //Valores para el suavizado en la rotacion
    [SerializeField] float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;

    //Componente que gestiona el HUD
    [SerializeField] UIManager uiManager;

    private void Awake()
    {
        //Velocidad a la que avanza la nave
        //Esta en Awake para que se cargue antes que la escena
        GameManager.alive = true;
        GameManager.lifes = 3;
        GameManager.level = 1;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        desplSpeed = 75f;
        speed = 120f;

    }

    // Update is called once per frame
    void Update()
    {
        


        if(GameManager.alive)
        {
            speed += 0.01f;

            CheckLimits();
            Mover();
            Rotar();

        }
        

            
    }

    void Mover()
    {
        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        //Desplazar un GameObject
        Vector3 despl = Vector3.up * Time.deltaTime * desplSpeed * moveY;
        transform.Translate(despl, Space.World);

        /*
        if(transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, 0f);  
        }
        */


        transform.position += Vector3.up * Time.deltaTime * desplSpeed * moveY;

        posX = transform.position.x;


        if(inlimitX == true)
        {
            Vector3 desplX = Vector3.right * Time.deltaTime * desplSpeed * moveX;
            transform.Translate(desplX, Space.World);
        }


        // transform.Translate(Vector3.right * Time.deltaTime * speed * moveX);
    }
    
    void CheckLimits()
    {
        if (posX > limitX && moveX > 0 || posX < -limitX && moveX < 0)
        {
            inlimitX = false;
        }
        else
        {
            inlimitX = true;
        }
    }

    void Rotar()
    {
        
        //ROTACION CON SUAVIZADO
        //Sumo el vector de rotacion en Z mas el de rotacion en X parabascrular
        Vector3 vectorRotZ = Vector3.forward * -60f * moveX;
        Vector3 vectorRotX = Vector3.right * -30f * moveY;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;

        //ROTACION SIN SUAVIZADO //
        /*
        Vector3 rotZ = Vector3.forward * moveX * -60f;
        Vector3 rotX = Vector3.right * moveY * -20f;
        Vector3 rot = rotZ + rotX;
        transform.rotation = Quaternion.Euler(rot);
        */

        //ROTACION CONTINUA CON JOYSTICK DERECHOO
        /*
        axisRot = Input.GetAxis("HorizontalJR");
        transform.Rotate(Vector3.forward * Time.deltaTime * -speedRot * 360f * axisRot);
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.lifes--;
            if(GameManager.lifes < 0 )
            {
                Morir();
            }
            else
            {
               uiManager.UpdateLifes();
            }
            
            /*
            GameManager.lifes--;
            print("Vidas " + GameManager.lifes);
            if(GameManager.lifes < 0)
            {
                Morir();
            }
            else
            {
                Destroy(other.gameObject);
            }
            ^*/
        }
        else if(other.gameObject.tag == "PowerUp")
        {
            print("BIEWEEEEN");
        }


    }

    void Morir()
    {
        GameManager.alive = false;
        speed = 0;
        //Destroy(gameObject);
          
    }
}
