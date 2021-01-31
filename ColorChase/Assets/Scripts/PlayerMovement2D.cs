using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private const float FORWARD_ACCELERATION = 10f;
    private const float BACKWARD_ACCELERATION = 10f;
    private const float STRAFE_ACCELERATION = 10.0f;
    private const float MAX_FORWARD_VELOCITY = 6.0f;
    private const float MAX_BACKWARD_VELOCITY = 5.0f;
    private const float MAX_STRAFE_VELOCITY = 4.5f;
    private const float GRAVITY_ACCELERATION = 10.0f;
    private const float MAX_HEAD_TILT_ROTATION = 60.0f;
    private const float MIN_HEAD_TILT_ROTATION = 280.0f;
    private const float ANGULAR_VELOCITY_FACTOR = 2.0f;
    private const float MAX_FALL_VELOCITY = 100.0f;

    public GameObject firstPersonPlayer;

    private CharacterController _controller;
    private Transform _cameraTransform;
    private Vector3 _acceleration;
    private Vector3 _velocity;
    private Ray centerRay, upRay, downRay, leftRay, rightRay;
    private RaycastHit centerHit, upHit, downHit, leftHit, rightHit;
    private bool moveUp, moveDown, moveLeft, moveRight;
    public int currentColor;
    private string currentBelowGround;
    private string previousbelowGround;


    public int ground0Height = 0;
    public int ground1Height = 2;
    public int ground2Height = 4;

    public Sound sound;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _acceleration = Vector3.zero;
        _velocity = Vector3.zero;
        moveUp = true;
        moveDown = true;
        moveLeft = true;
        moveRight = true;
        centerRay.origin = transform.position;
        centerRay.direction = -transform.up;
        if (Physics.Raycast(centerRay, out centerHit, 2))
        {
            currentColor = centerHit.transform.gameObject.layer;
        }
        else currentColor = 6;

        currentBelowGround = "Ground0";
        

        HideCursor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        
        
        
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
        alignFirstPersonPlayer();

        centerRay.origin = transform.position;
        centerRay.direction = -transform.up;
        upRay.origin = transform.position + new Vector3(0, 0, 0.5f);
        upRay.direction = -transform.up;
        downRay.origin = transform.position + new Vector3(0, 0, -0.5f);
        downRay.direction = -transform.up;
        leftRay.origin = transform.position + new Vector3(-0.5f, 0, 0);
        leftRay.direction = -transform.up;
        rightRay.origin = transform.position + new Vector3(0.5f, 0, 0);
        rightRay.direction = -transform.up;

        if (Physics.Raycast(centerRay, out centerHit, 2))
        {
            currentColor = centerHit.transform.gameObject.layer;
        }

        if (Physics.Raycast(upRay, out upHit, 2))   //W
        {
            int colorUp = upHit.transform.gameObject.layer;
            moveUp = colorUp == currentColor;
        }
        if (Physics.Raycast(downRay, out downHit, 2))  //S
        {
            int colorDown = downHit.transform.gameObject.layer;
            moveDown = colorDown == currentColor;
        }

        if (Physics.Raycast(leftRay, out leftHit, 2))   //A
        {
            int colorLeft = leftHit.transform.gameObject.layer;
            moveLeft = colorLeft == currentColor;
        }
        if (Physics.Raycast(rightRay, out rightHit, 2))   //D
        {
            int colorRight = rightHit.transform.gameObject.layer;
            moveRight = colorRight == currentColor;
        }

    }

    
    private void UpdateAcceleration()
    {
        _acceleration.z = Input.GetAxis("Forward");

        _acceleration.z *= (_acceleration.z >= 0) ? FORWARD_ACCELERATION : BACKWARD_ACCELERATION;

        _acceleration.x = Input.GetAxis("Strafe") * STRAFE_ACCELERATION;

        if (_controller.isGrounded)
        {
            _acceleration.y = 0f;
        }
        else
        {
            _acceleration.y = -GRAVITY_ACCELERATION;
        }


    }

    private void UpdateVelocity()
    {
        _velocity += _acceleration * Time.fixedDeltaTime;

        _velocity.z = (_acceleration.z == 0f || _velocity.z * _acceleration.z < 0) ? 0f : Mathf.Clamp(_velocity.z, -MAX_BACKWARD_VELOCITY, MAX_FORWARD_VELOCITY);
        _velocity.x = (_acceleration.x == 0f || _velocity.x * _acceleration.x < 0) ? 0f : Mathf.Clamp(_velocity.x, -MAX_STRAFE_VELOCITY, MAX_STRAFE_VELOCITY);
        _velocity.y = (_acceleration.y == 0f) ? -0.1f : Mathf.Clamp(_velocity.y, -MAX_FALL_VELOCITY, 0);
    }

    private void UpdatePosition()
    {
        Vector3 motion = _velocity * Time.fixedDeltaTime;

        Vector3 firstPMotion = _velocity * Time.fixedDeltaTime;

        if (Physics.Raycast(centerRay, out centerHit, 2))
        {
            currentBelowGround = centerHit.transform.gameObject.tag;

        }
        
        if (!moveUp && motion.z >= 0.0) 
        {
            motion.z = 0;
            firstPMotion.z = 0;
        }
        if (!moveDown && motion.z <= 0.0)
        {
            motion.z = 0;
            firstPMotion.z = 0;
        }
        if (!moveLeft && motion.x <= 0.0)
        {
            motion.x = 0;
            firstPMotion.x = 0;
        }
        if (!moveRight && motion.x >= 0.0)
        {
            motion.x = 0;
            firstPMotion.x = 0;
        }

        var FPPx = firstPersonPlayer.transform.position.x;
        var FPPy = firstPersonPlayer.transform.position.y;
        var FPPz = firstPersonPlayer.transform.position.z;
        

        _controller.Move(transform.TransformVector(motion));

        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true)
        {
            sound.SoundIsPlaying();
        }

    }


    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public int getGroundLevel()
    {
        switch (currentBelowGround)
        {
            case "Ground0": return ground0Height;
            case "Ground1": return ground1Height;
            case "Ground2": return ground2Height;
            default: return 0;
        }
    }

    private void alignFirstPersonPlayer()
    {
        int heightDifference = getGroundLevel();
        firstPersonPlayer.transform.position =  new Vector3(
            transform.position.x+200, transform.position.y+heightDifference, transform.position.z);
    }


}