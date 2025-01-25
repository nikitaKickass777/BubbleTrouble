using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BubbleGum : Bubble
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
    } 
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Transform bubble = this.transform;
        bubble.localScale = new Vector3(bubble.localScale.x + 0.2f, bubble.localScale.y + 0.2f, bubble.localScale.z);
        if (hp <= 0)
        {
            DestroyBubble();
            //play sound
            //AudioManager.instance.PlayOneShot(bubblePop, this.transform.position);
            //play animation
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
