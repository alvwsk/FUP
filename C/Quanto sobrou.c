#include <stdio.h>

int main (void){
  int p[3];
  float v[3], money;
  
  for(int i=0; i<3; i++){
    scanf("%d", &p[i]);
  }
  for(int i=0; i<3; i++){
    scanf("%f", &v[i]);
  }

  scanf("%f", &money);

  for(int i=0; i<3; i++){
    money = money - v[i] * p[i];
  }
  printf("%.2f\n", money); 
  return 0;
}
