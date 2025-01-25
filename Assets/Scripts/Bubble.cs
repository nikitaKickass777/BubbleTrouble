using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;  // Upward movement speed
    public int hp = 1;        // Bubble health
    public const float SCREEN_HEIGHT = 8f; // Screen height
    void Start()
    {
        
    }
    void Update()
    {
        MoveUpwards();
        if(transform.position.y > SCREEN_HEIGHT) // destroy bubble if it goes out of screen
        {
            DestroyBubble();
        }
    }

    void MoveUpwards()
    {
        //TODO: make more chaotic movement
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnMouseDown()
    {
        if(RhythmManager.Instance.InRhythm) TakeDamage(1);
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            DestroyBubble();
            //play sound
            //play animation
            
        }
    }

    void DestroyBubble()
    {
        Destroy(gameObject);
        ScoreManager.instance.IncrementScore(1);
    }
}
