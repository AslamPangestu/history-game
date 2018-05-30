using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    private class TimedEvent
    {
        public float timeToExecute;
        public CallBack method;
    }

    public delegate void CallBack();
    private List<TimedEvent> events;

    private void Awake()
    {
        events = new List<TimedEvent>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(events.Count == 0)
        {
            return;
        }
        for(int i = 0; i < events.Count; i++)
        {
            var timedEvent = events[i];
            if (timedEvent.timeToExecute <= Time.time)
            {
                timedEvent.method();
                events.Remove(timedEvent);
            }
        }
	}

    public void Add(CallBack callback, float inSec)
    {
        events.Add(new TimedEvent
        {
            method = callback,
            timeToExecute = Time.time + inSec
        });
    }
}
