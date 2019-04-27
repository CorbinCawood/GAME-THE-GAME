using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class spriteAnimator : MonoBehaviour
{

    public string _idleNames;
    public string _attackNames;
    public string _walkNames;
    public SpriteRenderer spriteR;
    public Sprite[] walk;
    public Sprite[] attack;
    public Sprite[] idle;
    public Sprite[] death;
    public float _walkDelay;
    public float _attackDelay;
    public float _idleDelay;
    public float _timer;
    public bool _attackComplete;
    public bool _attackInProgress;
    public bool idleInProgress;
    public bool walkInProgress;
    public bool damageDelay;
    public int _frameNum = 0;
    public int playerType;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {


        death = Resources.LoadAll<Sprite>("Death/regDeath/");
        idle = Resources.LoadAll<Sprite>(_idleNames);
        attack = Resources.LoadAll<Sprite>(_attackNames);
        walk = Resources.LoadAll<Sprite>(_walkNames);
        _timer = 0.0f;
        _idleDelay = 0.5f;
        _walkDelay = 0.2f;
        _attackDelay = 2.0f;
        _frameNum = 0;
        damageDelay = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp("space"))
        {
            if (!_attackInProgress)
            {
                StartCoroutine(animateAttack());
                _attackInProgress = true;
            }
        }
        else if(Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            if(!walkInProgress)
            {

                StartCoroutine(animateWalk());
                walkInProgress = true;
            }
        }
        else
        {
            if(!idleInProgress)
            StartCoroutine(animateIdle());
            idleInProgress = true;
        }

    }

    IEnumerator animateIdle()
    {
        for (int i = 0; i < idle.Length; i++)
        {
            spriteR.sprite = idle[i];
            yield return new WaitForSeconds(0.5f);
        }

        idleInProgress = false;
    }

    IEnumerator animateWalk()
    {


        for (int i = 0; i < walk.Length; i++)
        {
            bool originalRight = Input.GetKey("right");
            bool originalLeft = Input.GetKey("left");
            
            if (Input.GetAxis("Horizontal") == 0.0f && Input.GetAxis("Vertical") == 0.0f)
            {
                break;
            }
            else if (Input.GetKey("right") && !Input.GetKey("left"))
            {
                spriteR.flipX = false;
                if (GetComponent<CircleCollider2D>().offset.x < 0)
                {
                    GetComponent<CircleCollider2D>().offset *= new Vector2(-1, 1);
                }
            }
            else if(Input.GetKey("left") && !Input.GetKey("right"))
            {

                spriteR.flipX = true;
                if (GetComponent<CircleCollider2D>().offset.x > 0)
                {
                    GetComponent<CircleCollider2D>().offset *= new Vector2(-1, 1);
                }
            }

            print("Walking");
            spriteR.sprite = walk[i];
            yield return new WaitForSeconds(0.25f);
        }

        walkInProgress = false;
    }

    IEnumerator animateAttack()
    {

        for(int i = 0; i < attack.Length; i++)
        {
            spriteR.sprite = attack[i];
            yield return new WaitForSeconds(0.10f);
            
        }

        _attackInProgress = false;
    }

    public IEnumerator animateDeath()
    {

        print("Death In Progress");
        print(death.Length);
        for (int i = 0; i < death.Length; i++)
        {
            spriteR.sprite = death[i];
            yield return new WaitForSeconds(0.5f);
            
        }

        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    private void OnTriggerStay2D(Collider2D other)
    {


        if (playerType != 2)
        {
            if (other.tag == "Enemy" && other.GetType() != typeof(CircleCollider2D))
            {
                print("INRANGE");
                if (_attackInProgress && !damageDelay)
                {

                    if (spriteR.flipX == true)
                    {
                        other.gameObject.transform.position += new Vector3(-1f, 0, 0);
                    }
                    else
                    {
                        other.gameObject.transform.position += new Vector3(0.5f, 0, 0);
                    }

                    other.gameObject.GetComponent<Enemy>().enemyHealth -= 1;
                    damageDelay = true;
                    StartCoroutine(attackPause());
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.GetType() == typeof(BoxCollider2D) && gameObject.GetComponent<BoxCollider2D>().IsTouching(collision) == true)
        {
            GM = GameObject.Find("gmPrefab(Clone)");
            GM.GetComponent<gameManager>().damagePlayer();

            if (collision.gameObject.transform.position.x < GM.GetComponent<gameManager>().P1.transform.position.x)
            {
                print("Damage From Left");
                gameObject.transform.position += new Vector3(0.5f, 0, 0);
            }
            else
            {
                print("Damage From Right");
                gameObject.transform.position += new Vector3(-0.5f, 0, 0);
            }
        }
    }
   

    IEnumerator attackPause()
    {
        
        yield return new WaitForSeconds(0.5f);
        damageDelay = false;
    }
}
