using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image imageLifes;
    [SerializeField] Sprite[] lifesSprites; 

    // Start is called before the first frame update
    void Start()
    {
        UpdateLifes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLifes()
    {
        int n = GameManager.lifes;
        imageLifes.sprite = lifesSprites[n];
    }
}
