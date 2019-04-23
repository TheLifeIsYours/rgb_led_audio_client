#include <FastLED.h>

#define LED_PIN     9
#define NUM_LEDS    300
#define LED_TYPE    WS2812B
#define COLOR_ORDER GRB

CRGB leds[NUM_LEDS];

int pingDelay = 1000;
unsigned long lastPing;

int streamCheckDelay = 5000;
unsigned long lastStreamCheck;

bool readyToRecieve = false;
int serialReadColor = 4;
int serialReadData;
int lastStreamCheckData;

void setup() {
  Serial.begin(115200);
  while(!Serial){
    ;
  }
  
  FastLED.addLeds<LED_TYPE, LED_PIN, COLOR_ORDER>(leds, NUM_LEDS);
  FastLED.setBrightness(64);
}

void loop() {
  if(readyToRecieve == false && millis() - lastPing > pingDelay){
    lastPing += pingDelay;
    Serial.write(0); //ping the serial
  }

  //Loop to check if the stream hasn't crashed for some reason.
  if(readyToRecieve == true && millis() - lastStreamCheck > streamCheckDelay){
    lastStreamCheck += streamCheckDelay;

    //We know if the last read serialdata is three or four,
    //that the client is idle, or has stopped the stream by choice
    if(lastStreamCheckData == serialReadData && lastStreamCheckData != 3 && lastStreamCheckData != 4){
      readyToRecieve = false;
      return;
    }
    
    lastStreamCheckData = serialReadData;
  }
  
  if (Serial.available() > 0) {
    serialReadData = Serial.read();

    //Check if client wants to connnect the stream
    if(readyToRecieve == false && serialReadData == 0){
      readyToRecieve = true;
      Serial.write(1); //Send to client that the connection has been confirmend
      return;
    }
    
    //Check if client wants to disconnect the stream
    if(readyToRecieve == true && serialReadData == 1){
      readyToRecieve = false;
      return;
    }

    //Check for valid stream data (4 - 256)
    if(readyToRecieve == true && serialReadData >= 4){
      setLed(serialReadData);
      Serial.write(serialReadData); //Send client recieved data
      return;
    }

    //If there's no valid stream data, but the stream is ideling.
    if(readyToRecieve == true && serialReadData <= 3 ){
      setLed(4);
    }
  }
  
  scrollLed();
}

void setLed(int amp){
    int col = map(amp, 4, 210, 0, 255);

    FastLED.setBrightness(averageBrightness(col));
    leds[0] = CHSV(col, 255, col);
    
    FastLED.show();
}

void scrollLed(){
  for (int i = NUM_LEDS - 1; i > 0; i--){
    leds[i] = leds[i - 1];
  }
  FastLED.show();
}

long averageBrightness(int M) {
  #define LM_SIZE 10
  static int LM[LM_SIZE];      // LastMeasurements
  static byte index = 0;
  static long sum = 0;
  static byte count = 0;

  // keep sum updated to improve speed.
  sum -= LM[index];
  LM[index] = M;
  sum += LM[index];
  index++;
  index = index % LM_SIZE;
  if (count < LM_SIZE) count++;

  return sum / count;
}
