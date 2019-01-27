using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent <int> { }


public class victoryManager : MonoBehaviour
{

    public int eventCount = 5;
    public int currentEventCount = 0;

    public GameObject door;

    public IntEvent OnStepIncrease;
    public UnityEvent OnFinish;

    public void increaseEvents()
    {
        currentEventCount++;
        OnStepIncrease.Invoke(currentEventCount);
        if (currentEventCount >= eventCount)
        {
            door.active = false;
            OnFinish.Invoke();
            //doorMaterial.color = Color.white;
        }
    }

    public void loadCredits()
    {
    }
}
