using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAndActivities : MonoBehaviour
{
    public GameObject PlayerModel;

    private const float MOVEMENT_SPEED = 2;
    public const float MIN_Y_ANGLE= -50f;
    public const float MAX_Y_ANGLE = 50f;

    private float _currentX = 0f;
    private float _currentY = 0f;

    private float _currentYRotation = 0f;
    private float _additionalGravidation = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        ChangePlayerPosition();
        MakeAction();
    }

    private void ChangePlayerPosition()
    {
        if (Input.GetKey(GameInput.Keys[GameInput.Forward]))
            GoForward();

        if (Input.GetKey(GameInput.Keys[GameInput.Backward]))
            GoBackward();

        if (Input.GetKey(GameInput.Keys[GameInput.Left]))
            GoLeft();

        if (Input.GetKey(GameInput.Keys[GameInput.Right]))
            GoRight();

        // Postać nie porusza się samoistnie po kontakcie z nietypowymi przeszkodami
        Rigidbody playerRigidbody = PlayerModel.GetComponent<Rigidbody>();
        Vector3 vectorTemp = playerRigidbody.velocity;
        vectorTemp.x = 0.0f;
        playerRigidbody.velocity = vectorTemp;
    }

    #region Movement (Horizontal and vertical)
    private void Move(int axisModificator, Axis axis)
    {
        float movement = MOVEMENT_SPEED * Time.deltaTime * axisModificator;

        float yPosition = PlayerModel.transform.position.y;

        if (axis == Axis.X)
        {
            PlayerModel.transform.Translate(
                movement,
                0,
                0
            );
        }

        if (axis == Axis.Z)
        {
            PlayerModel.transform.Translate(
                0,
                0,
                movement
            );
        }

        // Reset Y axis
        PlayerModel.transform.position = new Vector3(
            PlayerModel.transform.position.x,
            yPosition,
            PlayerModel.transform.position.z
        );
    }

    private void GoForward()
    {
        Move(1, Axis.Z);
    }
    private void GoBackward()
    {
        Move(-1, Axis.Z);
    }
    private void GoLeft()
    {
        Move(-1, Axis.X);
    }
    private void GoRight()
    {
        Move(1, Axis.X);
    }
    #endregion
    
    #region Rotation
    private void Rotate()
    {
        float valueY = Input.GetAxis("Mouse Y") * -1;
        float valueX = Input.GetAxis("Mouse X");

        _currentX = Mathf.Clamp(_currentX, MIN_Y_ANGLE, MAX_Y_ANGLE);

        PlayerModel.transform.Rotate(0, valueX, 0);

        if ((valueY > 0 && _currentYRotation == MAX_Y_ANGLE) ||
            (valueY < 0 && _currentYRotation == MIN_Y_ANGLE))
            return;

        _currentYRotation += valueY;

        if (_currentYRotation > MAX_Y_ANGLE)
        {
            float correction = _currentYRotation - MAX_Y_ANGLE;
            _currentYRotation -= correction;
            valueY -= correction;
        }

        if (_currentYRotation < MIN_Y_ANGLE)
        {
            float correction = _currentYRotation - MIN_Y_ANGLE;
            _currentYRotation -= correction;
            valueY -= correction;
        }

        //PlayerModel.transform.Rotate(valueY, 0, 0);
    }
    #endregion
    
    private void MakeAction()
    {
        /*
        if (Input.GetKeyDown(GameInput.Action))
            Action();*/
    }

    private void Action()
    {

    }

    private void SecondAction()
    {

    }
}
