using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTowerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector2 initialPosition;
    [SerializeField]
    private float speed;
    private IEnumerator coroutine;
    private bool startMoving = false;
    void Start()
    {
        transform.position = initialPosition;
        coroutine = startPause();
        StartCoroutine(coroutine);
        
    }

    // Update is called once per frame
    private IEnumerator startPause()
    {
        yield return new WaitForSeconds(3);
        startMoving = true;
    }
    public void Update()
    {
        if (startMoving){
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y < -36f) {
                transform.position = new Vector3(0, 34f, 0);
            }
        }
    }
    public void turnOnPlatformCollision()
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
    public void turnOffPlatformCollision()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    private IEnumerator Wait(float waitTime) 
    { 
        yield return new WaitForSeconds(waitTime);
    }
}
