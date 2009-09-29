/**
 * A Mirf example to test the latency between two Ardunio.
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
 */

#include <Spi.h>
#include <mirf.h>
#include <nRF24L01.h>

// byte 0 is the part id and byte 1 and 2 are the command
#define messageLength 3
char message[messageLength];

byte numReceivedMessageBytes = 0;
#define messageActivator '%'

void setup(){
  Serial.begin(9600);
  /*
   * Setup pins / SPI.
   */
   
  /* To change CE / CSN Pins:
   * 
   * Mirf.csnPin = 9;
   * Mirf.cePin = 7;
   */
   
  Mirf.init();
  
  /*
   * Configure reciving address.
   */
   
  Mirf.setRADDR((byte *)"bTran");
  
  /*
   * Set the payload length to sizeof(unsigned long) the
   * return type of millis().
   *
   * NB: payload on client and server must be the same.
   */
   
  Mirf.payload = messageLength; //sizeof(unsigned long);
  
  /*
   * Write channel and payload config then power up reciver.
   */
   
  /*
   * To change channel:
   * 
   * Mirf.channel = 10;
   *
   * NB: Make sure channel is legal in your area.
   */
   
  Mirf.config();
  
  //Serial.println("Beginning ... "); 
  
  //message[0] = 'a';
  //message[1] = 'b';
}

void loop(){
  if(Serial.available()){
    
    if(numReceivedMessageBytes == 0)
    {
      //Serial.println("MessageBytesIsZero");
      if(Serial.read() == messageActivator)
      {
        //Serial.println("SerialIsActivator");
        numReceivedMessageBytes = 1;
      }
    }
    else if(numReceivedMessageBytes > 0)
    {
      message[numReceivedMessageBytes - 1] = char(Serial.read());

      numReceivedMessageBytes = numReceivedMessageBytes + 1;
    }
    
    if(numReceivedMessageBytes == 4)
    {
      sendMessage();
      clearMessage(); 
    }
  }
}

void sendMessage()
{
  //Serial.print(message[0]);
  //Serial.print(message[1]);
  //Serial.print(message[2]);
  //Serial.println(message[3]);
  
  Mirf.setTADDR((byte *)"bRecv");
  
  Mirf.send((byte *)&message);
  
  while(Mirf.isSending()){
  }
}

void clearMessage()
{
  // clear the message
  numReceivedMessageBytes = 0;
}

  
