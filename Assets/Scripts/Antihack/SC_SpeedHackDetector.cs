using System;
using UnityEngine;

public class SC_SpeedHackDetector : MonoBehaviour
{
    //Speed hack protection
    public int timeDiff = 0; 
    private int _previousTime = 0;
    private int _realTime = 0;
    private float _gameTime = 0;
    private bool _detected = false;

    // Use this for initialization
    private void Awake()
    {
        _previousTime = DateTime.Now.Second;
        _gameTime = 1;
    }

    // Update is called once per frame 
    private void FixedUpdate()
    {
        if (_previousTime != DateTime.Now.Second)
        {
            _realTime++;
            _previousTime = DateTime.Now.Second;

            timeDiff = (int)_gameTime - _realTime;
            if (timeDiff > 7)
            {
                if (!_detected)
                {
                    _detected = true;
                    SpeedHackDetected();
                }
            }
            else
            {
                _detected = false;
            }
        }
        _gameTime += Time.deltaTime;
    }

    private void SpeedHackDetected()
    {
        //Speedhack was detected, do something here (kick player from the game etc.)
        print("Speedhack detected.");
    }
}
