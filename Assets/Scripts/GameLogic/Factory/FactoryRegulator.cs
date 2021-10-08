using System;
using GameLogic.Obstacles;
using UnityEngine;

namespace GameLogic.Factory
{
    public class FactoryRegulator : MonoBehaviour
    {
        [SerializeField] private ObstacleAbstractFactory[] abstractFactories;

        public void InitAll(Action<ObstacleBehaviour> beforeDestroy)
        {
            foreach (var abstractFactory in abstractFactories)
            {
                abstractFactory.Init(beforeDestroy);
            }
        }
        
        public void StartAll()
        {
            foreach (var abstractFactory in abstractFactories)
            {
                abstractFactory.Active = true;
            }
        }
        
        public void StopAll()
        {
            foreach (var abstractFactory in abstractFactories)
            {
                abstractFactory.Active = false;
            }
        }
        
        public void ClearAll()
        {
            foreach (var abstractFactory in abstractFactories)
            {
                abstractFactory.Clear();
            }
        }
    }
}
