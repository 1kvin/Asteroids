using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Obstacles;
using GameLogic.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic.Factory
{
    public abstract class ObstacleAbstractFactory : MonoBehaviour
    {
        [SerializeField] protected ObstacleBehaviour obstacleBehaviourPrefab;
        [SerializeField] protected int maxObjectOnMap;

        [SerializeField] protected float objectGenerateTime;
        [SerializeField] protected int numObjectInTime;

        [SerializeField] protected float minSize;
        [SerializeField] protected float maxSize;

        [SerializeField] protected float minSpeed;
        [SerializeField] protected float maxSpeed;

        private Transform _transform;
        private readonly List<ObstacleBehaviour> objects = new List<ObstacleBehaviour>();

        private Coroutine activeCoroutine;
        private Action<ObstacleBehaviour> beforeDestroyAction;

        private bool active;

        public bool Active
        {
            get => active;
            set
            {
                active = value;
                ChangeActive();
            }
        }

        public void Init(Action<ObstacleBehaviour> beforeDestroy)
        {
            this.beforeDestroyAction = beforeDestroy;
        }

        public void Clear()
        {
            objects.Clear();
        }

        public void InstantiateObjects(int number, Vector3 pos)
        {
            for (int i = 0; i < number; i++)
            {
                var obj = InstantiateObject(pos);
                obj.BeforeDestroy += beforeDestroyAction;
                obj.BeforeDestroy += OnDestroyObject;
                objects.Add(obj);
            }
        }

        private void Awake()
        {
            _transform = transform;
        }
        
        protected virtual ObstacleBehaviour InstantiateObject(Vector3 pos)
        {
            var size = Random.Range(minSize, maxSize);
            var speed = Random.Range(minSpeed, maxSpeed);
            var rotation = Random.Range(0, 360);

            var asteroid = Instantiate(obstacleBehaviourPrefab, pos, _transform.rotation, _transform);
            asteroid.Init(pos, size, speed, rotation);

            return asteroid;
        }
        

        protected virtual void OnDestroyObject(ObstacleBehaviour obstacleBehaviour)
        {
            objects.Remove(obstacleBehaviour);
        }

        private void ChangeActive()
        {
            if (active)
            {
                if(maxObjectOnMap != 0)
                    activeCoroutine = StartCoroutine(nameof(GenerateAsteroidCoroutine));
            }
            else
            {
                if(activeCoroutine != null)
                    StopCoroutine(activeCoroutine);
            }
        }

        private IEnumerator GenerateAsteroidCoroutine()
        {
            while (Active)
            {
                if (objects.Count < maxObjectOnMap)
                {
                    InstantiateObjects(numObjectInTime, ScreenUtilities.GetRandomPointOuterScreen());
                }

                yield return new WaitForSeconds(objectGenerateTime);
            }
        }
    }
}