#include "pin_definitions.h"
#include "Motors.h"

#include <String.h>
#include <stdlib.h>
#include <Wire.h>


//
String IncommingCommnad = "";

//
boolean Echo = true;

Motor left_motor(50000, LEFT_MOTOR_PWM, LEFT_MOTOR_DIR);
Motor right_motor(50000,RIGHT_MOTOR_PWM, RIGHT_MOTOR_DIR);


void setup()
{
  // Setup Serial library at 9600 bps.
  Serial.begin(9600);
  ShowVersion();
}

void loop()
{
  //motor.run(FORWARD);
  //motor.run(BACKWARD);
  //motor.run(RELEASE);
  //motor.setSpeed(i);  

  ReadCommand();
}

//////////////////////////////////////////////////////////////////////////  
// Read incomming data from the serial buffer.
//////////////////////////////////////////////////////////////////////////  
void ReadCommand()
{
  // Fill the command data buffer with command.
  while(Serial.available())
  {
    // Add new char.
    IncommingCommnad += (char)Serial.read();
    // Wait a while for a a new char.
    delay(5);
  }

  // If command if not empty parse it.
  if(IncommingCommnad != "")
  {
    boolean isValid = ValidateCommand(IncommingCommnad);
    if(isValid)
    {
      ParseCommand(IncommingCommnad);
    }
    // Print command for feedback.
    if(Echo == true)
    {
      Serial.print("Cmd: ");
      Serial.println(IncommingCommnad);
    }
  }

  // Clear the command data buffer.
  IncommingCommnad = ""; 
}

//////////////////////////////////////////////////////////////////////////  
// Validate the incomming data from the serial buffer.
//////////////////////////////////////////////////////////////////////////  
boolean ValidateCommand(String command)
{
  // ?LF255RB255\n
  // |||||||||||||
  // |||||||||||\\- Termin
  // ||||||||\\\--- Right PWM value.
  // |||||||\------ Direction of the right bridge.
  // ||||||\------- Right bridge index.
  // |||\\\-------- Left PWM value.
  // ||\----------- Direction of the left bridge.
  // |\------------ Left bridge index.
  // \------------- Start symbol.
  //
  // Package lenght 1 + 1 + 1 + 3 + 1 + 1 + 3 + 1 = 12 bytes;
  //

  boolean state = false;

  if(command[0] == '?' && command[11] == '\n')
  {
    if(command[1] == 'L' && command[6] == 'R')
    {
      if((command[2] == 'F' || command[2] == 'B') && (command[7] == 'F' || command[7] == 'B'))
      {
        // PWM values.
        int leftWheelPWM = -1;
        int rightWheelPWM = -1;

        // Convert commands from string to numbers.
        leftWheelPWM = atoi(command.substring(3, 6).c_str());
        rightWheelPWM = atoi(command.substring(8, 11).c_str());

        //
        if((leftWheelPWM < 256 && leftWheelPWM > -1) && (rightWheelPWM < 256 && rightWheelPWM > -1))
        {
          // If is valid.
          state = true;
        }
      }        
    }
  }

  // Show version of the device.
  if(command == "?VERSION\n")
  {
    // If is valid.
    state = true;
  }

  // If is not valid.
  return state;
}

//////////////////////////////////////////////////////////////////////////  
// Parse the incomming data from the serial buffer.
//////////////////////////////////////////////////////////////////////////  
void ParseCommand(String command)
{
  //?LF255RF255\n - Motor controll.

  int leftWheelPWM = -1;
  int rightWheelPWM = -1;

  leftWheelPWM = atoi(command.substring(3, 6).c_str());
  rightWheelPWM = atoi(command.substring(8, 11).c_str());

  if(command[1] == 'L' && command[6] == 'R')
  {
    // Left motor direction block.
    if(command[2] == 'F')
    {
      left_motor.speed(leftWheelPWM);		// forward
    }
    else if(command[2] == 'B')
    {
      left_motor.speed(leftWheelPWM);		// forward
    }
    else
    {
      left_motor.speed(0);
    }

    // Right motor direction block.
    if(command[7] == 'F')
    {
      right_motor.speed(rightWheelPWM);
    }
    else if(command[7] == 'B')
    {	
      right_motor.speed(rightWheelPWM);
    }
    else
    {
      right_motor.speed(0);
    }

    Serial.print("Left motor speed: ");
    Serial.println(leftWheelPWM, DEC);
    Serial.print("Left motor direction: ");
    Serial.println(command[2] == 'F' ? "Forward" : "Backward");
    Serial.print("Right motor speed: ");
    Serial.println(rightWheelPWM, DEC);
    Serial.print("Right motor direction: ");
    Serial.println(command[7] == 'F' ? "Forward" : "Backward");

  }

  else if(command == "?VERSION\n")
  {
    // Show version of the device.
    ShowVersion();
  }
}


//////////////////////////////////////////////////////////////////////////
// Print the version of the device.
//////////////////////////////////////////////////////////////////////////
void ShowVersion()
{
  Serial.println("UNI : TU-Gabrovo");
  Serial.println("DEP : AIUT");
  Serial.println("NAME: Robot Karel v3.2");
  Serial.println("DATE: 23.10.2014y."); 
}










