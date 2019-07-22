using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Events
{
    public class EventManager : MonoBehaviour
    {
        private static EventManager eventManager;

        private Dictionary<EventId, UnityEvent> eventDictionary;

        public static EventManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!eventManager)
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    else
                        eventManager.Init();
                }

                return eventManager;
            }
        }

        void Init()
        {
            if (eventDictionary == null)
                eventDictionary = new Dictionary<EventId, UnityEvent>();
        }

        public static void StartListening(EventId eventId, UnityAction listener)
        {
            if (instance.eventDictionary.TryGetValue(eventId, out UnityEvent thisEvent))
                thisEvent.AddListener(listener);
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventId, thisEvent);
            }
        }

        public static void StopListening(EventId eventId, UnityAction listener)
        {
            if (eventManager == null)
                return;

            if (instance.eventDictionary.TryGetValue(eventId, out UnityEvent thisEvent))
                thisEvent.RemoveListener(listener);
        }

        public static void TriggerEvent(EventId eventId)
        {
            if (instance.eventDictionary.TryGetValue(eventId, out UnityEvent thisEvent))
                thisEvent.Invoke();
        }
    }
}