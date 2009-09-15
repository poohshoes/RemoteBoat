byte rudderServo = 0x00;

// in half micro seconds
int minServoPosition = 900;
int maxServoPosition = 4700;

void setup()
{
  Serial.begin(9600);
  
  setServoParameters();
  setServoSpeed();
  
  
}

void loop()
{
  setServoPosition(1000);
  delay(2000);
  setServoPosition(4500);
  delay(2000);
}


void setServoPosition(int newPosition)
{
  // we restrict the range to 450 - 2350 micro seconds so the servo dosen't break
  if(newPosition < minServoPosition)
  {
    newPosition = minServoPosition;
  }
  else if(newPosition > maxServoPosition)
  {
    newPosition = maxServoPosition;
  }
  
  byte lowByte, highByte;
  
  unsigned int temp;
  temp = newPosition & 0x1f80;  //get bits 8 thru 13 of position
  highByte = temp >> 7;     //shift bits 8 thru 13 by 7
  lowByte = newPosition & 0x7f; //get lower 7 bits of position
  
  Serial.print(0x80,BYTE);    //start byte
  Serial.print(0x01,BYTE);    //device id
  Serial.print(0x04,BYTE);    //command number
  Serial.print(rudderServo,BYTE);  //servo number
  Serial.print(highByte, BYTE);
  Serial.print(lowByte, BYTE);
}

void setServoParameters()
{
  Serial.print(0x80,BYTE);    //start byte
  Serial.print(0x01,BYTE);    //device id
  Serial.print(0x00,BYTE);    //command number
  Serial.print(rudderServo,BYTE);  //servo number
  Serial.print(0x4F,BYTE);  // set direction to forward, servo to on, and range to 15
}

void setServoSpeed()
{
  Serial.print(0x80,BYTE);    //start byte
  Serial.print(0x01,BYTE);    //device id
  Serial.print(0x01,BYTE);    //command number
  Serial.print(rudderServo,BYTE);  //servo number
  Serial.print(0x00,BYTE);  // 0 is default speed (instantainious)
}
