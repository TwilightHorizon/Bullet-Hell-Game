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
<<<<<<< Updated upstream
=======
    private IEnumerator coroutine;
    private int startMoving = 0;
>>>>>>> Stashed changes
    void Start()
    {
        transform.position = initialPosition;
    }
    
    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        transform.position += Vector3.down * speed * Time.deltaTime;
        if(transform.position.y < -36f){
            transform.position = new Vector3(0,34f,0); 
=======
        yield return new WaitForSeconds(3);
        startMoving = 1;
    }
    public void Update()
    {
        
        transform.position += Vector3.down * speed * Time.deltaTime * startMoving;
        if (transform.position.y < -36f) {
            transform.position = new Vector3(0, 34f, 0);
>>>>>>> Stashed changes
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
}
