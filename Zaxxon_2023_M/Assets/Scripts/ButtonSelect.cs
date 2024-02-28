using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
{

    //Arrastramos el Audio Source que contiene el sonido que queremos ejecutar
    AudioSource m_Source;

    private void Start()
    {
        m_Source = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }
    //Do this when the selectable UI object is selected.
    public void OnSelect(BaseEventData eventData)
    {
        m_Source.Play();
    }

}