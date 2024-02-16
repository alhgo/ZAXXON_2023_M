using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpeed : MonoBehaviour
{

    [SerializeField] Material waterMat;
    [SerializeField] float speed;
    [SerializeField] Color myColor;

    [SerializeField] PlayerManager playerManager;
    // Start is called before the first frame update

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        speed = playerManager.speed;
        waterMat.SetFloat("_Speed", -speed / 400f);
    }
}
