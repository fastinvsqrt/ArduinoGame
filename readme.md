# RIT IGME-470 Final Project

This is the final project that @Heltrskelter and myself worked on for the final
project in RIT's IGME-470 (Physical Computing and Alternative Interfaces) course.

You can play the game without the Arduino hookup by using the arrows.

## Arduino Code

```c++
// the pins used for the up, down, left, and right button hookups
#define PIN_UP    2
#define PIN_DOWN  A2
#define PIN_LEFT  A5
#define PIN_RIGHT 13

const  int    pins[]    = { PIN_UP, PIN_DOWN, PIN_LEFT, PIN_RIGHT };
static int    values[]  = {      0,        0,        0,         0 };
static String command   = "";

// setup the board
void setup()
{
  for (int i = 0; i < 4; ++i)
  {
    pinMode(pins[i], INPUT);
  }
  Serial.begin(9600);
  while (!Serial) {}
}

// loop (check for commands)
void loop()
{
  // check if there is anything to read from the serial
  if (Serial.available() > 0)
  {
    command = Serial.readStringUntil('\n');
    
    // get the values
    if (command == "getvalues")
    {
      Serial.print(values[0], DEC); Serial.print(',');
      Serial.print(values[1], DEC); Serial.print(',');
      Serial.print(values[2], DEC); Serial.print(',');
      Serial.print(values[3], DEC); Serial.println();
    }
    // update the values
    else if (command == "update")
    {
      for (int i = 0; i < 4; ++i)
      {
        values[i] = digitalRead(pins[i]);
      }
    }
  }
}
```
