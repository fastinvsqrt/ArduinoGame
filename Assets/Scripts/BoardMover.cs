using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// Defines a script used to move the board.
/// </summary>
public class BoardMover : MonoBehaviour
{
    /// <summary>
    /// The rotation speed.
    /// </summary>
    public float RotateSpeed = 30.0f;

    /// <summary>
    /// The maximum amount of X rotation allowed.
    /// </summary>
    public float MaxRotationX = 30.0f;

    /// <summary>
    /// The maximum amount of Z rotation allowed.
    /// </summary>
    public float MaxRotationZ = 30.0f;

    /// <summary>
    /// The board to move.
    /// </summary>
    public GameObject Board = null;

    /// <summary>
    /// The ball.
    /// </summary>
    public GameObject Ball = null;

    private float totalRotationX;
    private float totalRotationZ;
    private Quaternion initialRotation;
    private Vector3 initialBallPosition;
    private Controller controller;

    /// <summary>
    /// The method that will be called when the game has been won.
    /// </summary>
    public void OnWin()
    {
        Debug.Log( "You won!" );
        Reset();
    }

    /// <summary>
    /// Starts the board mover.
    /// </summary>
    void Start()
    {
        totalRotationX = 0.0f;
        totalRotationZ = 0.0f;
        initialRotation = Board.transform.rotation;
        initialBallPosition = Ball.transform.position;
        controller = gameObject.GetComponent<Controller>();
    }

    /// <summary>
    /// Updates the board mover.
    /// </summary>
    void Update()
    {
        float rotationX = 0.0f;
        float rotationZ = 0.0f;

        // check for input
        if ( Input.GetKey( KeyCode.LeftArrow ) || controller.Left )
        {
            rotationX += RotateSpeed * Time.deltaTime;
        }
        if ( Input.GetKey( KeyCode.RightArrow ) || controller.Right )
        {
            rotationX -= RotateSpeed * Time.deltaTime;
        }
        if ( Input.GetKey( KeyCode.UpArrow ) || controller.Up )
        {
            rotationZ += RotateSpeed * Time.deltaTime;
        }
        if ( Input.GetKey( KeyCode.DownArrow ) || controller.Down )
        {
            rotationZ -= RotateSpeed * Time.deltaTime;
        }

        // add to our total rotations
        totalRotationX += rotationX;
        totalRotationZ += rotationZ;

        // ensure we're not rotating too far
        if ( Math.Abs( totalRotationX ) > MaxRotationX )
        {
            totalRotationX = Math.Sign( totalRotationX ) * MaxRotationX;
            rotationX = 0.0f;
        }
        if ( Math.Abs( totalRotationZ ) > MaxRotationZ )
        {
            totalRotationZ = Math.Sign( totalRotationZ ) * MaxRotationZ;
            rotationZ = 0.0f;
        }

        // rotate the board
        Board.transform.rotation = initialRotation;
        Board.transform.Rotate( Vector3.forward, totalRotationX );
        Board.transform.Rotate( Vector3.right,   totalRotationZ );
    }

    /// <summary>
    /// Resets the board mover.
    /// </summary>
    void Reset()
    {
        // reset the board rotation
        totalRotationX = 0.0f;
        totalRotationZ = 0.0f;
        Board.transform.rotation = initialRotation;

        // reset the ball position and velocity
        Ball.transform.position = initialBallPosition;
        Ball.GetComponent<Rigidbody>().velocity = new Vector3();
    }
}