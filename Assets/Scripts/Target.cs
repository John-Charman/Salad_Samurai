using UnityEngine;

public class Target : MonoBehaviour
{
    protected Rigidbody2D targetRb;
    private GameManager gameManager;
    private float minSpeed = 0.5f;
    private float maxSpeed = 1.1f;
    private float minHeight = 12;
    private float maxHeight = 15;
    private float maxTorque = 8;
    private float xRange = 8;
    private float ySpawnPos = -6;

    private bool clicked;


    // Start is called before the first frame update
    void Awake()
    {
        targetRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    protected virtual void OnEnable()
    {
        clicked = false;
        transform.position = RandomSpawnPos();
        targetRb.AddForce(RandomForce(), ForceMode2D.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode2D.Impulse);
        

    }
    //ABSTRACTION
    Vector2 RandomSpawnPos()
    {
        return new Vector2(Random.Range(-xRange, xRange), ySpawnPos);
    }
    // ABSTRACTION
    Vector2 RandomForce() 
    {
        return new Vector2(Random.Range(-transform.position.x * minSpeed,-transform.position.x * maxSpeed), 
        Random.Range(minHeight,maxHeight));
    }
    //ABSTRACTION
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    protected virtual void OnMouseDown()
    {
        //if (gameManager.isGameActive)
        //{
            clicked = true;
            gameManager.UpdateScore(1);
            gameObject.SetActive(false);
            //gameManager.UpdateScore(pointValue);
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!clicked)
        {
            gameManager.GameOver();
            gameObject.SetActive(false);
        }
    }
}
