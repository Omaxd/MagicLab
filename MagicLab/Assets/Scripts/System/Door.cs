using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsPositiveValue;

    private const float OPEN_VALUE = 1.3f;

    private Transform _door;

    private float _openValue;

    private bool _isOpen;
    private bool _hasAction;

    // Start is called before the first frame update
    void Start()
    {
        _door = GetComponent<Transform>();
        _hasAction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasAction)
            Move();
    }

    private void Move()
    {
        float newOpenValue = 0.015f * MovingMultiplier();
        _openValue += newOpenValue;
        
        if (Math.Abs(_openValue) >= OPEN_VALUE)
        {
            //_hasAction = false;
            _isOpen = !_isOpen;

            _openValue = 0;

            return;
        }

        _door.Translate(
            newOpenValue,
            0,
            0
        );
    }

    private int MovingMultiplier()
    {
        if (IsPositiveValue && !_isOpen)
            return 1;

        if (!IsPositiveValue && _isOpen)
            return 1;

        return -1;
    }
}
