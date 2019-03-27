using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteAnimator : MonoBehaviour
{

    private string frameNames;
    public SpriteRenderer spriteR;
    public Sprite[] _frames;
    private float delay;
    private float timer;
    
    private int _frameNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        frameNames = "Idle";
        _frames = Resources.LoadAll<Sprite>(frameNames);
        timer = 0.0f;
        delay = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            _frameNum++;
            if (_frameNum > 3)
            {
                _frameNum = 0;
            }
            
            spriteR.sprite = _frames[_frameNum];
            timer = 0f;
        }
        
    }
}
