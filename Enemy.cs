using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public string enemyType;
    private bool _isWalking;
    private bool _inRange;
    public bool isDead;
    public int enemyHealth;
    private int _enemyDamage;
    public float speed;
    public Transform _target;
    public Sprite[] walk;
    public SpriteRenderer spriteR;
    public Sprite[] death;
    
    // Start is called before the first frame update
    void Start()
    {
        //Switch statement for choosing the enemy type
        switch (enemyType)
        {
                
            case "slime1":

                walk = Resources.LoadAll<Sprite>("slimeOne/Walk");
                death = Resources.LoadAll<Sprite>("slimeOne/Death");
                speed = 0.5f;
                enemyHealth = 5;
                break;
            
            case "slime2":

                walk = Resources.LoadAll<Sprite>("slimeTwo/Walk");
                death = Resources.LoadAll<Sprite>("slimeTwo/Death");
                speed = 0.5f;
                enemyHealth = 6;
                break;
            
            case "skeleton1":

                walk = Resources.LoadAll<Sprite>("skeletonOne/Walk");
                death = Resources.LoadAll<Sprite>("skeletonOne/Death");
                speed = 1;
                enemyHealth = 7;
                break;
            
            case "skeleton2":

                walk = Resources.LoadAll<Sprite>("skeletonTwo/Walk");
                death = Resources.LoadAll<Sprite>("skeletonTwo/Death");
                speed = 1;
                enemyHealth = 9;
                break;
            
            case "goblin1":

                walk = Resources.LoadAll<Sprite>("goblinOne/Walk");
                death = Resources.LoadAll<Sprite>("goblinOne/Death");
                speed = 2;
                enemyHealth = 3;
                break;
            
            case "goblin2":

                walk = Resources.LoadAll<Sprite>("goblinTwo/Walk");
                death = Resources.LoadAll<Sprite>("goblinTwo/Death");
                speed = 2;
                enemyHealth = 4;
                break;
            
        }

        _isWalking = false;
        _inRange = false;
        isDead = false;
    }

    // Updates the enemy once per frame
    void Update()
    {
        //As long as the enemy is in range of the player and not dead, enemy will start walking towards the player.
        if (_inRange == true && isDead == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
            if (_isWalking == false)
            {
               
                _isWalking = true;
                StartCoroutine(AnimateWalk());
            }
        }

        //If the enemy has no health remaining, set it as dead and run death animation
        if (enemyHealth == 0)
        {
            isDead = true;
            StartCoroutine(AnimateDeath());
       }
    }

    //Set inRange to true if player is within range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _inRange = true;
        }
    }

    //function for animating the enemy walk
    IEnumerator AnimateWalk()
    {
        for(int i = 0; i < walk.Length; i++)
        {
            spriteR.sprite = walk[i];
            yield return new WaitForSeconds(0.25f);
        }

        spriteR.sprite = walk[0];
        _isWalking = false;
    }

    //Function for animating when an enemy dies
    IEnumerator AnimateDeath()
    {

        for (int i = 0; i < death.Length; i++)
        {
            spriteR.sprite = death[i];
            yield return new WaitForSeconds(0.25f);
        }

        GameObject.Find("gmPrefab(Clone)").GetComponent<gameManager>().numKills += 1;
        Destroy(gameObject);
    }
}
