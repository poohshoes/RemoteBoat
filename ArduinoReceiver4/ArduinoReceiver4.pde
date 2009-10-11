/**
 * An Mirf example which copies back the data it recives.
 *
 * Pins:
 * Hardware SPI:
 * MISO -> 12
 * MOSI -> 11
 * SCK -> 13
 *
 * Configurable:
 * CE -> 8
 * CSN -> 7
 *
 */

#include <Spi.h>
#include <mirf.h>
#include <nRF24L01.h>

#define messageLength 3

#define rudderServo 0

#define rudderServoId '0'
#define topsailHoistMotorId '1'
#define headSailHoistMotorId '2'
#define topSailSheetId '3'
#define headSailSheetId '4'
#define mainSailSheetId '5'

#define minServoPosition 900
#define maxServoPosition 4700

#define topsailHoistMotorHighPin 2
#define topsailHoistMotorLowPin 3
#define mainSailSheetHighPin 16
#define mainSailSheetLowPin 17
#define headSailSheetHighPin 18
#define headSailSheetLowPin 19
#define topSailSheetHighPin 4
#define topSailSheetLowPin 5

void setup(){
  
  pinMode(topsailHoistMotorHighPin, OUTPUT);
  pinMode(topsailHoistMotorLowPin, OUTPUT);
  pinMode(mainSailSheetHighPin, OUTPUT);
  pinMode(mainSailSheetLowPin, OUTPUT);
  pinMode(headSailSheetHighPin, OUTPUT);
  pinMode(headSailSheetLowPin, OUTPUT);
  pinMode(topSailSheetHighPin, OUTPUT);
  pinMode(topSailSheetLowPin, OUTPUT);
  
  digitalWrite(topsailHoistMotorHighPin, HIGH);
  digitalWrite(topsailHoistMotorLowPin, HIGH);
  digitalWrite(mainSailSheetHighPin, HIGH);
  digitalWrite(mainSailSheetLowPin, HIGH);
  digitalWrite(headSailSheetHighPin, HIGH);
  digitalWrite(headSailSheetLowPin, HIGH);
  digitalWrite(topSailSheetHighPin, HIGH);
  digitalWrite(topSailSheetLowPin, HIGH);
  
  setServoParameters();
  setServoSpeed();
  
  Serial.begin(9600);
  
  /*
   * Setup pins / SPI.
   */
   
  Mirf.init();
  
  /*
   * Configure reciving address.
   */
   
  Mirf.setRADDR((byte *)"bRecv");
  
  /*
   * Set the payload length to sizeof(unsigned long) the
   * return type of millis().
   *
   * NB: payload on client and server must be the same.
   */
   
  Mirf.payload = messageLength; // sizeof(unsigned long);
  
  /*
   * Write channel and payload config then power up reciver.
   */
   
  Mirf.config();
  
  //Serial.println("Listening..."); 
}

void loop(){
  /*
   * A buffer to store the data.
   */
   
  byte data[Mirf.payload];
  
  /*
   * If a packet has been recived.
   */
  if(Mirf.dataReady()){
    
    do{
      Mirf.getData(data);
       
    //Serial.print("Data[0]:");
    //Serial.print(data[0]);
    //Serial.print("!");
       
     switch (data[0])
     {
       case rudderServoId:
         setServoPosition(data[1], data[2]);
         break;
       case topsailHoistMotorId:
         setMotorMotion(data[1], data[2], topsailHoistMotorLowPin, topsailHoistMotorHighPin);
         break;
       case topSailSheetId:
         setMotorMotion(data[1], data[2], topSailSheetLowPin, topSailSheetHighPin);
         break;
       case headSailSheetId:
         setMotorMotion(data[1], data[2], headSailSheetLowPin, headSailSheetHighPin);
         break;
       case mainSailSheetId:
         setMotorMotion(data[1], data[2], mainSailSheetLowPin, mainSailSheetHighPin);
         break;
     }    
      
    }while(!Mirf.rxFifoEmpty());
  }
}

void setMotorMotion(byte onOff, byte dir, short lowPin, short highPin)
{
  if(onOff == 'f')
  {
    digitalWrite(lowPin, HIGH);
    digitalWrite(highPin, HIGH);
  }
  else
  {
    if(dir == 'l')
    {
      digitalWrite(lowPin, HIGH);
      digitalWrite(highPin, LOW);
    }
    else
    {
      digitalWrite(lowPin, LOW);
      digitalWrite(highPin, HIGH);
    }
  }
}

void setServoPosition(byte high, byte low)
{
  Serial.print(0x80,BYTE);    //start byte
  Serial.print(0x01,BYTE);    //device id
  Serial.print(0x04,BYTE);    //command number
  Serial.print(rudderServo,BYTE);  //servo number
  Serial.print(high, BYTE);
  Serial.print(low, BYTE);
  
    /*Serial.println(0x80,HEX);    //start byte
  Serial.println(0x01,HEX);    //device id
  Serial.println(0x04,HEX);    //command number
  Serial.println(rudderServo,HEX);  //servo number
  Serial.println(high, HEX);
  Serial.println(low, HEX);*/
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
