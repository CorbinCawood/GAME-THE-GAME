using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class spriteAnimator : MonoBehaviour
{

    private string _idleNames;
    private string _attackNames;
    private string _walkNames;
    public SpriteRenderer spriteR;
    public Sprite[] walk;
    public Sprite[] attack;
    public Sprite[] idle;
    private float _walkDelay;
    private float _attackDelay;
    private float _idleDelay;
    private float _timer;
    private bool _attackComplete;
    private bool _attackInProgress;
    public bool idleInProgress;
    public bool walkInProgress;
    private int _frameNum = 0;
    public int playerType;

    // Start is called before the first frame update
    void Start()
    {
        
        switch(playerType){
            case 0:

                _idleNames = "Axe/levelZero/Idle";
                _walkNames = "Axe/levelZero/Walk";
                _attackNames = "Axe/levelZero/Attack";
                break;
            
            case 1:

                _idleNames = "Sword/levelZero/Idle";
                _walkNames = "Sword/levelZero/Walk";
                _attackNames = "Sword/levelZero/Attack";
                
                break;
            
            case 2:

                _idleNames = "Scepter/levelZero/Idle";
                _walkNames = "Scepter/levelZero/Walk";
                _attackNames = "Scepter/levelZero/Attack";
                break;
            
            case 3:

                _idleNames = "Special/Idle";
                _walkNames = "Special/Walk";
                _attackNames = "Special/Attack";
                break;
        }

        idle = Resources.LoadAll<Sprite>(_idleNames);
        attack = Resources.LoadAll<Sprite>(_attackNames);
        walk = Resources.LoadAll<Sprite>(_walkNames);
        _timer = 0.0f;
        _idleDelay = 0.5f;
        _walkDelay = 0.2f;
        _attackDelay = 2.0f;
        _frameNum = 0;
        
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
                if ((Input.GetKey("right") && !Input.GetKey("left")))
                {
                    spriteR.flipX = false;
                }else if ((Input.GetKey("left")) && !Input.GetKey("right"))
                {
                    spriteR.flipX = true;
                }

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
            if (Input.GetAxis("Horizontal") == 0.0f && Input.GetAxis("Vertical") == 0.0f)
            {
                break;
            }

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
}
