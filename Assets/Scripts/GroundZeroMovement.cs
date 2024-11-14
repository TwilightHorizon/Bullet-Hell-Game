using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundZeroMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    // Update is called once per frame
<<<<<<< Updated upstream
    void Update()
=======

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
    private IEnumerator coroutine;
    private int startMoving = 0;
    private void Awake()
>>>>>>> Stashed changes
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        
    }
<<<<<<< Updated upstream
=======
    private IEnumerator startPause()
    {
        yield return new WaitForSeconds(3);
        startMoving = 1;
    }
    public void Update()
    {
       
        
         transform.position += Vector3.down * speed * Time.deltaTime * startMoving;
        
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
>>>>>>> Stashed changes
}
