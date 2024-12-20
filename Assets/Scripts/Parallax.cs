using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
   private MeshRenderer _meshRenderer;
   [SerializeField] private float _animationSpeed = 1f;

   private void Awake()
   {
      _meshRenderer = GetComponent<MeshRenderer>();
      // Awakte compent Meshrenderi buluyoruz
   }

   private void Update()
   {
      _meshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed * Time.deltaTime, 0);
      // meshrenderda materialinden anaTexture!ın offsetini vector2 tipte verdiğimiz hız ve Time.deltatime kadar arttıyoruz.
   }
}
