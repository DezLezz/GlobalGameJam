using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float FORWARD_ACCELERATION = 10f;
    private const float BACKWARD_ACCELERATION = 10f;
    private const float STRAFE_ACCELERATION = 10.0f;
    private const float MAX_FORWARD_VELOCITY = 6.0f;
    private const float MAX_BACKWARD_VELOCITY = 2.0f;
    private const float MAX_STRAFE_VELOCITY = 4.5f;
    private const float GRAVITY_ACCELERATION = 10.0f;
    private const float MAX_HEAD_TILT_ROTATION = 60.0f;
    private const float MIN_HEAD_TILT_ROTATION = 280.0f;
    private const float ANGULAR_VELOCITY_FACTOR = 2.0f;
    private const float MAX_FALL_VELOCITY = 100.0f;


    public GameObject camPlayer;
    private CharacterController _controller;
    private Transform _cameraTransform;
    private Vector3 _acceleration;
    private Vector3 _velocity;
    private Ray upRay, downRay, leftRay, rightRay;
    private RaycastHit upHit, downHit, leftHit, rightHit;
    private bool moveUp, moveDown, moveLeft, moveRight;

    public GameObject arrow;
    public GameObject botModel;

    public Sound sound;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _cameraTransform = GetComponentInChildren<Camera>().transform;
        _acceleration = Vector3.zero;
        _velocity = Vector3.zero;
        moveUp = true;
        moveDown = true;
        moveLeft = true;
        moveRight = true;

        HideCursor();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHeadTilt();
        UpdateRotation();
    }

    void FixedUpdate()
    {
       
        
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
        alignMapPlayer();    
        upRay.origin = transform.position + Vector3.Scale(transform.forward, new Vector3(0.5f,1,0.5f));
        upRay.direction = -transform.up;
        downRay.origin = transform.position - Vector3.Scale(transform.forward, new Vector3(0.5f,1,0.5f));
        downRay.direction = -transform.up;
        leftRay.origin = transform.position - Vector3.Scale(transform.right, new Vector3(0.5f,1,0.5f));
        leftRay.direction = -transform.up;
        rightRay.origin = transform.position + Vector3.Scale(transform.right, new Vector3(0.5f,1,0.5f));
        rightRay.direction = -transform.up;
        moveUp = Physics.Raycast(upRay, out upHit, 2);   //W

        moveDown = Physics.Raycast(downRay, out downHit, 2);  //S
        
        moveLeft = Physics.Raycast(leftRay, out leftHit, 2);   //A
        
        moveRight = Physics.Raycast(rightRay, out rightHit, 2);   //D
        
    }

    private void UpdateHeadTilt()
    {
        Vector3 cameraRotation = _cameraTransform.localEulerAngles;

        cameraRotation.x -= Input.GetAxis("Mouse Y") * ANGULAR_VELOCITY_FACTOR;

        if (cameraRotation.x < 180.0f)
            cameraRotation.x = Mathf.Min(cameraRotation.x, MAX_HEAD_TILT_ROTATION);
        else
            cameraRotation.x = Mathf.Max(cameraRotation.x, MIN_HEAD_TILT_ROTATION);

        _cameraTransform.localEulerAngles = cameraRotation;
    }

    private void UpdateRotation()
    {
        float rotation = Input.GetAxis("Mouse X") * ANGULAR_VELOCITY_FACTOR;
        arrow.transform.Rotate(0, rotation, 0);
        botModel.transform.Rotate(0, rotation, 0);
        transform.Rotate(0, rotation, 0);
    }

    private void UpdateAcceleration()
    {
        _acceleration.z = Input.GetAxis("Forward");

        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true)
        {
            sound.SoundIsPlaying();
        }



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

        Vector3 camMotion = _velocity * Time.fixedDeltaTime;

        if (!moveUp && motion.z >= 0.0)
        {
            motion.z = 0;
            camMotion.z = 0;
        }
        if (!moveDown && motion.z <= 0.0)
        {
            motion.z = 0;
            camMotion.z = 0;
        }
        if (!moveLeft && motion.x <= 0.0)
        {
            motion.x = 0;
            camMotion.x = 0;
        }
        if (!moveRight && motion.x >= 0.0)
        {
            motion.x = 0;
            camMotion.x = 0;
        }

        //if (Math.Abs((CPx+200) - FPPx )> 0.1)
        //{
        //    camMotion.x = 0;
        //}

        //if (Math.Abs(CPz - FPPz) > 0.1)
        //{
        //    camMotion.z = 0;
        //}

        //camPlayer.GetComponent<CharacterController>().Move(transform.TransformVector(camMotion));
       // camPlayer.transform.position = new Vector3(_controller.transform.position.x-200, camPlayer.transform.position.y, _controller.transform.position.z);
        _controller.Move(transform.TransformVector(motion));
    }


    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void alignMapPlayer()
    {
        int heightDifference = camPlayer.GetComponent<PlayerMovement2D>().getGroundLevel();
        camPlayer.transform.position =  new Vector3(
            transform.position.x-200, transform.position.y-heightDifference, transform.position.z);
    }


}