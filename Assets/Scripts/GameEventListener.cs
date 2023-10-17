using MegaCat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MegaCat
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField]
        private GameEvent @event;
        [SerializeField]
        private UnityEvent response;

        private void OnEnable()
        {
            Debug.Log($"Register event {@event.name} from {name}");
            if (@event != null) @event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Debug.Log($"Deregister event {@event.name} from {name}");
            if (@event != null) @event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response?.Invoke();
        }
    }

}
