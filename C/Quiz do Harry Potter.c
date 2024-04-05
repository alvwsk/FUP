#include <stdio.h>

int main(void){
  char escolha;
  int count = 0;
  
  scanf(" %c", &escolha);
  if(escolha == 'd'){
    count++;
  }
  scanf(" %c", &escolha);
  if(escolha == 'a'){
    count++;
  }
  scanf(" %c", &escolha);
  if(escolha == 'c'){
    count++;
  }
  scanf(" %c", &escolha);
  if(escolha == 'd'){
    count++;
  }
  
  switch(count) {
    case 0:
      printf("Nunca assistiu");
      break;
    case 1:
      printf("Ja ouviu falar");
      break;
    case 2:
      printf("Interessado no assunto");
      break;
    case 3:
      printf("Fa");
      break;
    default:
      printf("Super fa");
      break;
  }
  
  return 0;
}  
