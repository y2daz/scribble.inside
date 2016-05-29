using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[System.Serializable]

public class PointerListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public UnityEvent onLongPress = new UnityEvent();
    bool _pressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    void Update()
    {
        if (_pressed)
            onLongPress.Invoke();
            return;

        
    }
}