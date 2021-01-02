using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] FishMove fish1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    //State
    Vector2 fishToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        fishToBallVector = transform.position - fish1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPanel();
            LaunchBallOnMouseClick();
        }

    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            myRigidbody2d.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPanel()
    {
        Vector2 fishPos = new Vector2(fish1.transform.position.x, fish1.transform.position.y);
        transform.position = fishPos + fishToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityChange = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor)
            );
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            // Play one shot means play the whole way through
            myAudioSource.PlayOneShot(clip);

            myRigidbody2d.velocity += velocityChange;
        }
    }
}
