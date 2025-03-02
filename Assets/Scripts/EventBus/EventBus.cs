using System;
using UnityEngine;


public abstract class Event { }

public class EventBus<T> where T : Event
{
    public static event Action<T> OnEvent;

    public static void Publish(T pEvent)
    {
        OnEvent?.Invoke(pEvent);
    }
}

//Dummy logic to remember the syntax
//This is not meant to be used nor is the syntax correct, but it's essentially a cheat sheet
//public
class TestEvent : Event
{
    public int testInt;

    public TestEvent(int ptestInt)
    {
        testInt = ptestInt;
    }

    void ListenerScript(TestEvent e)
    {
        Debug.Log("Test listener script, value broadcasted is: " + e.testInt);
    }

    void AddListener()
    {
        EventBus<TestEvent>.OnEvent += ListenerScript;
    }

    void PublishEvent(int value)
    {
        EventBus<TestEvent>.Publish(new TestEvent(value));
    }
}
//------------------------------------------ACTUAL EVENTS-------------------------------------------------------\\
public class SelectAnswer : Event
{
    public int answer;
    public SelectAnswer(int pAnswer)
    {
        answer = pAnswer; 
    }

}
