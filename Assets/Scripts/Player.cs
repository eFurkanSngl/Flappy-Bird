using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _dir;  // playerımızın yönü
    [SerializeField]private float _gravity = -9.8f;  // playere uygulayacağımız yer çekimi.
    [SerializeField] private float _strength = 5f; // Player yukarı hareketi vereceğimiz güç kadar yapacak
    private SpriteRenderer _spriteRenderer;
    public Sprite[] spirtes;  // spriteları tuttuğumuz liste.
    private int spriteIndex;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
        // Methodu tekrar ederk calıştırır.
        // method adı - başlamı zamanı - kaç sn de bir tekrar edeceği parametrelerini alır.
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // KeyCode her framde Tuş basılıysa True döner.
        {
            _dir = Vector3.up * _strength; // Yön yukarı * güç kadar.
        }

        _dir.y += _gravity * Time.deltaTime;
        transform.position += _dir * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= spirtes.Length) // listenin uzunluğundan büyük ve eşitse
        {
            spriteIndex = 0; // sıfıra eşitledik
        }

        _spriteRenderer.sprite = spirtes[spriteIndex];
    }
}
