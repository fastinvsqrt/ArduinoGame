using UnityEngine;
using System.Collections;

/// <summary>
/// A script for helping with triggers.
/// </summary>
public class TriggerHelper : MonoBehaviour
{
    private Collider ballCollider;
    private BoardMover boardMover;

    /// <summary>
    /// The ball.
    /// </summary>
    public GameObject Ball = null;

    /// <summary>
    /// Starts the trigger helper script.
    /// </summary>
    void Start()
    {
        ballCollider = Ball.GetComponent<Collider>();
        boardMover = Camera.main.GetComponent<BoardMover>();
    }

    /// <summary>
    /// The event that is called when the given collider collides with us.
    /// </summary>
    /// <param name="collider">The other collider.</param>
    void OnTriggerEnter( Collider collider )
    {
        if ( collider == ballCollider )
        {
            boardMover.OnWin();
        }
    }
}
