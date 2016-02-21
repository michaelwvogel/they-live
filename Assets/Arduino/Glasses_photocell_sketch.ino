/* adapted from https://learn.adafruit.com/photocells/using-a-photocell 
 
Connect one end of the photocell to 5V, the other end to Analog 0.
Then connect one end of a 10K resistor from Analog 0 to ground.

*/
 
int photocellPin = 0;     // the cell and 10K pulldown are connected to a0
int photocellReading;     // the analog reading from the analog resistor divider
 
void setup(void) {
  // We'll send debugging information via the Serial monitor
  Serial.begin(9600);   
}
 
void loop(void) {
  photocellReading = analogRead(photocellPin);  
 /*
  Serial.print("Analog reading = ");
  Serial.print(photocellReading);     // the raw analog reading
 
  if (photocellReading < 100) {
    Serial.println(" - Glasses on");
  } else {
    Serial.println(" - Glasses not on");
  }*/
  /*
  Serial.println(photocellReading);
  Serial.write(photocellReading);
  */
  if (photocellReading < 100) {
    Serial.write(1);
    Serial.println(1);
  } else {
    Serial.write(0);
    Serial.println(0);
  }
  delay(20);
  Serial.flush();
}
