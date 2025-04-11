using System;
using System.Collections.Generic;
using System.Linq;
using Catching;

namespace Common
{
    using UnityEngine;

    public class UpdateHandler : MonoBehaviour
    {
        
        private List<IUpdateReceiver> _receivers = new();
        private bool changed;

        public void Register(IUpdateReceiver receiver)
        {
            changed = false;
            _receivers.Add(receiver);
        }
        
        public void Deregister(IUpdateReceiver receiver)
        {
            changed = true;
            _receivers.Remove(receiver);
        }
        
        private void Update()
        {
            if (changed)
            {
                _receivers = _receivers.OrderByDescending(r => r.Priority).ToList();
                changed = false;
            }
            
            for (int i = _receivers.Count - 1; i >= 0; i--)
            {
                _receivers[i].Tick(Time.deltaTime);
            }
        }

        private void OnDestroy()
        {
            for (var index = _receivers.Count - 1; index >= 0; index--)
            {
                Deregister(_receivers[index]);
            }
        }
    }
}