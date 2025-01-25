using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;  // Upward movement speed
    public float maxHorizontalDrift=1f;
    public float bpm= 80f; 
    public int hp = 1;        // Bubble health
    public const float SCREEN_HEIGHT = 10f; // Screen height
    public string functionName= "sin";
    void Start()
    {
        maxHorizontalDrift= Random.Range(0.3f,2.5f);
        if (Random.Range(0f,1f)> 0.5)
            {
                functionName="cos";
            }
            

        
    }
    void Update()
    {
        MoveUpwards();
        if(transform.position.y > 10f) // destroy bubble if it goes out of screen
        {
            DestroyBubble();
        }
    }

    void MoveUpwards()
    {

        float drift = horizontalMovementFunction(this.functionName,Time.time*(bpm/60f)*2f*Mathf.PI)*maxHorizontalDrift;
        transform.Translate(Vector3.up * speed * Time.deltaTime + Vector3.right *drift*Time.deltaTime );
    }

    void OnMouseDown()
    {
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            DestroyBubble();
        }
    }

    void DestroyBubble()
    {
        Destroy(gameObject);
        // Add score increment logic here if needed
    }

    float horizontalMovementFunction(string functionName, float value)
    {
        switch(functionName.ToLower())
        {
            case "cos":
                return Mathf.Cos(value);
            case "sin":
                return Mathf.Sin(value);
            default:
                return Mathf.Sin(value);
        }
    }
}
