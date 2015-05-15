using UnityEngine;
using System.Collections;

/// <summary>
/// Defines a ball helper.
/// </summary>
public class BallHelper : MonoBehaviour
{
    /// <summary>
    /// The ball.
    /// </summary>
    public GameObject Ball = null;

    /// <summary>
    /// The minimum Y value allowed for the ball.
    /// </summary>
    public float MinimumYValue = -40.0f;

    /// <summary>
    /// The position to reset the ball to.
    /// </summary>
    public Vector3 ResetPosition = new Vector3( 0.0f, 10.0f, 0.0f );

    /// <summary>
    /// The ball's rigid body.
    /// </summary>
    private Rigidbody ballRigidbody;

    /// <summary>
    /// Starts the ball helper script.
    /// </summary>
    void Start()
    {
        ballRigidbody = Ball.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Updates the ball helper script.
    /// </summary>
    void Update()
    {
        if ( Ball.transform.position.y < MinimumYValue )
        {
            // reset the position and remove any velocity the ball has
            Ball.transform.position = ResetPosition;
            ballRigidbody.velocity = Vector3.zero;
        }
    }
}