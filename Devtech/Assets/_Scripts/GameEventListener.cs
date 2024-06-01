using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//  usa Component em vez de MonoBehaviour porque é mais genérico ainda
//  System.Serializable pra ver dentro do Inspetor
[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }

[System.Serializable]
public class CustomGameEventNoData : UnityEvent<Component> { }

public class GameEventListener : MonoBehaviour
{
    // Qual evento quer escutar
    public GameEvent gameEvent;

    // UnityEvent permite linkar chamadas de metodo direto no inspetor
    public CustomGameEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(Component sender, object data)
    {
        response.Invoke(sender, data);
    }
}
