using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;  // Upward movement speed
    public int hp = 1;        // Bubble health
    void Start()
    {
        
    }
    void Update()
    {
        MoveUpwards();
    }

    void MoveUpwards()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
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
}
