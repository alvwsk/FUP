#include <stdio.h>

int main (void)
{
    int posicaoHelicoptero, posicaoPolicial, posicaoFugitivo, direcao;

    scanf("%d %d %d %d", &posicaoHelicoptero, &posicaoPolicial, &posicaoFugitivo, &direcao);

    if (direcao == -1) {
        while(1) {
            if (posicaoFugitivo == -1){
                posicaoFugitivo = 15;
            }
            if (posicaoFugitivo == posicaoPolicial){
                printf("N\n");
                break;
            }
            if (posicaoFugitivo == posicaoHelicoptero){
                printf("S\n");
                break;
            }
            posicaoFugitivo--;
        }
    } else {
        while(1) {
            if (posicaoFugitivo == 16) {
                posicaoFugitivo = 0;
            }
            if (posicaoFugitivo == posicaoPolicial) {
                printf("N\n");
                break;
            }
            if (posicaoFugitivo == posicaoHelicoptero) {
                printf("S\n");
                break;
            }
            posicaoFugitivo++;
        }
    }
    return 0;
}
