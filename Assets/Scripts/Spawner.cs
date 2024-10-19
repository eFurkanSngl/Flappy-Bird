using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
   [SerializeField] private GameObject _prefab;
   [SerializeField] private float _spawnRate = 1f;
   [SerializeField] private float _minHeight = -1f;
   [SerializeField] private float _maxHeight = 1f;

   private void OnEnable()
   {
      InvokeRepeating("Spawn",_spawnRate,_spawnRate);
   }

   private void OnDisable()
   {
      CancelInvoke("Spawn");
   }

   private void Spawn()
   {
      GameObject pipes = Instantiate(_prefab, transform.position, quaternion.identity);
      pipes.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
   }
}
