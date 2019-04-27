using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClass
{

    public string playerType;
    public int playerHealth;
    public int attackLevel;
    public int defenseLevel;
    public int attackSpeed;

    public string name;

    public SpriteRenderer spriteR;
    public bool isAttacking;

    public bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {

    }



}
