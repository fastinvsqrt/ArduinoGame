using UnityEngine;
using System.Collections;

/// <summary>
/// An enumeration of possible controller button.
/// </summary>
public enum ControllerButton
{
    Up,
    Down,
    Left,
    Right
}

/// <summary>
/// Defines an Arduino controller script.
/// </summary>
public class Controller : MonoBehaviour
{
    private int[] values;
    private Arduino arduino;

    /// <summary>
    /// Checks to see if up is being pressed.
    /// </summary>
    public bool Up
    {
        get
        {
            return IsButtonDown( ControllerButton.Up );
        }
    }

    /// <summary>
    /// Checks to see if down is being pressed.
    /// </summary>
    public bool Down
    {
        get
        {
            return IsButtonDown( ControllerButton.Down );
        }
    }

    /// <summary>
    /// Checks to see if left is being pressed.
    /// </summary>
    public bool Left
    {
        get
        {
            return IsButtonDown( ControllerButton.Left );
        }
    }

    /// <summary>
    /// Checks to see if right is being pressed.
    /// </summary>
    public bool Right
    {
        get
        {
            return IsButtonDown( ControllerButton.Right );
        }
    }

    /// <summary>
    /// Checks to see if the given button is down.
    /// </summary>
    /// <param name="button">The button to check for.</param>
    /// <returns></returns>
    public bool IsButtonDown( ControllerButton button )
    {
        int index = (int)button;
        return values[ index ] != 0;
    }

    /// <summary>
    /// Starts the controller script.
    /// </summary>
    void Start()
    {
        values = new int[ 4 ] { 0, 0, 0, 0 };
        if ( Arduino.AvailablePorts.Length > 0 )
        {
            string port = Arduino.AvailablePorts[ 0 ];
            arduino = new Arduino( port );
        }
    }

    /// <summary>
    /// Updates the controller.
    /// </summary>
    void Update()
    {
        if ( arduino != null )
        {
            // tell the Arduino to update
            arduino.WriteLine( "update" );

            // get the button values
            arduino.WriteLine( "getvalues" );
            string line = arduino.ReadLine();
            string[] bits = line.Split( ',' );
            for ( int i = 0; i < 4; ++i )
            {
                values[ i ] = int.Parse( bits[ i ] );
            }
        }
    }
}
