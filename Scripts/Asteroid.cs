using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite rockSprite0;
    [SerializeField]
    Sprite rockSprite1;
    [SerializeField]
    Sprite rockSprite2;
    [SerializeField]
    GameObject prefabAsteroid;

    /// <summary>
    /// This method randomizes the sprites for the astroids.
    /// </summary>
    void Start()
    {
        //Random Sprite is chosen
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float ranSprite = Random.Range(0, 3);
        if (ranSprite < 1)
        {
            spriteRenderer.sprite = rockSprite0;
        }
        else if (ranSprite < 2)
        {
            spriteRenderer.sprite = rockSprite1;
        }
        else
            spriteRenderer.sprite = rockSprite2;
    }
    /// <summary>
    /// Initilize method that gives an asteroid a specific direction and a location to spawn at. The direction
    /// is randomized from 0 to 30 radians.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="location"></param>
    public void Initialize(Direction direction, Vector3 location)
    {
        // moves asteroid to passed through location
        transform.position = location;
       
        //if statements that dictate the direction of the astroid;
        if (direction == Direction.Up)
        {
     
            float angle = (75*Mathf.Deg2Rad);
            StartMoving(angle);
        }
        if (direction == Direction.Left)
        {
        
            float angle =  (165 * Mathf.Deg2Rad);
            StartMoving(angle);

        }
        if (direction == Direction.Right)
        {
            float angle =  (315 * Mathf.Deg2Rad);
            StartMoving(angle);
        }
        if (direction == Direction.Down)
        {
            float angle = ( 255 * Mathf.Deg2Rad);
            StartMoving(angle);
        }

       

    }
    /// <summary>
    /// Checks for collision and creates two new astroids that will be destroyed if hit again.
    /// NOTE: SCALE IS NOT RIGHT, OOPS
    /// </summary>
    /// <param name="colli"></param>
    void OnCollisionEnter2D(Collision2D colli)
        {
            // only blow up when colliding with a bullet
            if (colli.gameObject.tag == "Bullet")
            {
            // play the audio for hit
            AudioManager.Play(AudioClipName.AsteroidHit);

            float angle = Random.Range(0, 360);
                float angleNew = angle * Mathf.Deg2Rad;
                float angle2 = Random.Range(0, 360);
                float angle2New = angle2 * Mathf.Deg2Rad;

                Vector3 variable = transform.localScale;
                variable.x *= 0.5f;
                variable.y *= 0.5f;
                transform.localScale = variable;

                GetComponent<CircleCollider2D>().radius *= 0.5f;


                GameObject astroid1 = Instantiate(prefabAsteroid) as GameObject;
                astroid1.GetComponent<Asteroid>().StartMoving(angleNew);
                GameObject astroid2 = Instantiate(prefabAsteroid) as GameObject;
                astroid2.GetComponent<Asteroid>().StartMoving(angle2New);
                Destroy(gameObject);

            
            if (astroid1.transform.localScale.x <= 0.05f)
            {
                Destroy(astroid1);
               
            }
          if (astroid2.transform.localScale.x <= 0.05f)
            {
                Destroy(astroid2);

            }
        }
        }
    /// <summary>
    /// This allows the objects to move in the given angle thats random.
    /// </summary>
    /// <param name="angle"></param>
    public void StartMoving( float angle)
    {
        const float MinImpulseForce = 0.25f;
        const float MaxImpulseForce = 1.0f;
       
        float changeRandom = Random.Range(0, 30 * Mathf.Deg2Rad);
        float newAngle = changeRandom + angle;
        Vector2 moveDirection = new Vector2(
        Mathf.Cos(newAngle), Mathf.Sin(newAngle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

}

 
   

