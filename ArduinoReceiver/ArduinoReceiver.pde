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

#define rudderServo '0'

#define minServoPosition 900
#define maxServoPosition 4700

void setup(){
  
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
      
     switch (data[0])
     {
       case rudderServo:
         setServoPosition(data[1], data[2]);
         break;
     }    
      
    }while(!Mirf.rxFifoEmpty());
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
