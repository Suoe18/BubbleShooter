using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaCat
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        readonly List<IGameEventListener> eventListeners = new List<IGameEventListener>();

        public void Raise()
        {
            foreach (IGameEventListener e in new List<IGameEventListener>(eventListeners))
            {
                e.OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            eventListeners.Remove(listener);
        }
    }

    public interface IGameEventListener
    {
        void OnEventRaised();
    }

}
