using System.Collections;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;
using TMPro;


public class Bubble : MonoBehaviour, IDataPersistence
{
    [SerializeField] private EventReference bubblePop;
    // Start is called before the first frame update
    public float speed = 1f;  // Upward movement speed
    public float maxHorizontalDrift=1f;
    public float bpm= 80f; 
    public int hp = 1;        // Bubble health
    public string functionName= "sin";
    public const float SCREEN_HEIGHT = 8f; // Screen height
    ParticleSystem particleSystem;
    public SpriteRenderer image;
    public GameObject scoreText;

    private int playerExperience;
    void Start()
    {
        maxHorizontalDrift= Random.Range(0.3f,2.5f);
        if (Random.Range(0f,1f)> 0.5)
            {
                functionName="cos";
            }
            
        bpm = RhythmManager.Instance.bpm;
        image = this.gameObject.GetComponent<SpriteRenderer>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        scoreText.SetActive(false);
        
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

        float drift = horizontalMovementFunction(this.functionName,Time.time*(bpm/60f)*2f*Mathf.PI)*maxHorizontalDrift;
        transform.Translate(Vector3.up * speed * Time.deltaTime + Vector3.right *drift*Time.deltaTime );
    }

    void OnMouseDown()
    {
        if(RhythmManager.Instance.inRhythm != RhythmScore.SKILLISSUE  ) TakeDamage(1);
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            DestroyBubble();
            
            //play sound
            AudioManager.instance.PlayOneShot(bubblePop, this.transform.position);  
            //increase score 
            ScoreManager.instance.IncrementScore(RhythmManager.Instance.inRhythm);
            
        }
    }

    public void DestroyBubble()
    {
        particleSystem.Play();
        image.color = new Color(1.0f, 1.0f,1.0f,0.0f);
        showBubbleHitText();
        StartCoroutine(PlayParticlesCoroutine());
        
    }

    public void showBubbleHitText(){
        scoreText.SetActive(true);
        TextMeshPro bubbleText = scoreText.GetComponent<TextMeshPro>();
        Debug.Log(RhythmManager.Instance.inRhythm.ToString());
        bubbleText.text = RhythmManager.Instance.inRhythm.ToString();
        switch(RhythmManager.Instance.inRhythm){
            case RhythmScore.PERFECT: 
            bubbleText.color = Color.green;
            break;
            case RhythmScore.GOOD:
            bubbleText.color = Color.cyan;
            break;
            case RhythmScore.MEDIOCRE:
            bubbleText.text += " :(";
            bubbleText.color = Color.grey;
            break;
            default:
            break;
        }
        scoreText.transform.position = this.transform.position;
    }

    private IEnumerator PlayParticlesCoroutine(){
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
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

    public void SaveData(GameData data)
    {
        data.playerExperience = this.playerExperience;
    }
}
