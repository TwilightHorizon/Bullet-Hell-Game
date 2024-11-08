using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class GroundZeroMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float timer;
    
    // Update is called once per frame

    // private void Awake()
    // {
    //     StartCoroutine(nameof(Process));
    // }
    // private void OnEnable()
    // {
    //     print("onEnable");
    //     StartCoroutine(nameof(Process));
    // }

    // private void OnDisable()
    // {
    //     StopCoroutine(nameof(Process));
    //     transform.position = new Vector3(0, -4, 0);
    // }
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        
    }
    // private IEnumerator Process()
    // {
    //     float startTime = Time.deltaTime;
    //     float destinationY = -7;
    //     yield return new WaitForSeconds(1f);
    //     
    //     gameObject.SetActive(true);
    //     while (true)
    //     {
    //         transform.position += Vector3.down * speed * (Time.deltaTime - startTime);
    //         if (gameObject.transform.position.y < destinationY)
    //         {
    //             gameObject.SetActive(false);
    //             yield break;
    //         }
    //     }
    //     
    //     
    //     yield return null;
    //     
    // }
}

