using UnityEngine;
using System.Collections;
using System.IO.Ports;

/// <summary>
/// Defines an easy way to interface with an Arduino.
/// </summary>
public class Arduino
{
    /// <summary>
    /// The default baud rate to use when connecting.
    /// </summary>
    public const int DefaultBaudRate = 9600;

    private SerialPort _port;

    /// <summary>
    /// Gets all of the available port names.
    /// </summary>
    public static string[] AvailablePorts
    {
        get
        {
            return SerialPort.GetPortNames();
        }
    }

    /// <summary>
    /// Checks to see if the connection to the Arduino was successful.
    /// </summary>
    public bool IsConnected
    {
        get
        {
            return _port.IsOpen;
        }
    }

    /// <summary>
    /// Gets the connected port's name.
    /// </summary>
    public string PortName
    {
        get
        {
            return _port.PortName;
        }
    }

    /// <summary>
    /// Creates a new Arduino interface.
    /// </summary>
    /// <param name="port">The name of the port.</param>
    public Arduino( string port )
    {
        _port               = new SerialPort( port );
        _port.BaudRate      = DefaultBaudRate;
        _port.NewLine       = "\n";
        _port.ReadTimeout   = 150;
        _port.WriteTimeout  = 150;
        _port.Open();
    }

    /// <summary>
    /// Reads a line of text from the Arduino.
    /// </summary>
    /// <returns></returns>
    public string ReadLine()
    {
        string line = _port.ReadLine();
        return line.Substring( 0, line.Length - 1 );
    }

    /// <summary>
    /// Writes a line of text to the Arduino.
    /// </summary>
    /// <param name="text">The text to write.</param>
    public void WriteLine( string text )
    {
        _port.WriteLine( text );
    }
}
