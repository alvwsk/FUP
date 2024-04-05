#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <locale.h>

#define MAX_ALUNOS 100

int menu(void);
void cadastro(void);
void pesquisaAluno(void);
void excluirAluno(void);
void listarAlunos(void);
void editarAluno(void);

char nome[MAX_ALUNOS][100], alunoExcluir[100];
int matricula[MAX_ALUNOS], editar[100];
char curso[MAX_ALUNOS][100];
int dia[MAX_ALUNOS], mes[MAX_ALUNOS], ano[MAX_ALUNOS];
int numNomes = 0;

int main(void) {
    setlocale(LC_ALL, "Portuguese");

    while(1) {
        switch(menu()) {

        case 1:
            cadastro();
            break;

        case 2:
            pesquisaAluno();
            break;

        case 3:
            excluirAluno();
            break;

        case 4:
            listarAlunos();
            break;

        case 5:
            editarAluno();
            break;

        case 6:
            exit(0);
            break;

        default:
            printf("Digitação inválida!\n");
        }
    }

    return 0;
}

int menu(void) {
    int opcao;
    printf("\n======MENU=====\n");
    printf("1. Adicionar novo aluno\n");
    printf("2. Buscar aluno por nome\n");
    printf("3. Excluir aluno\n");
    printf("4. Listar todos os alunos\n");
    printf("5. Editar dados de um aluno\n");
    printf("6. Sair\n");
    printf("\nEscolha uma opção: ");
    scanf("%d", &opcao);
    return opcao;
}

void cadastro(void) {
    if(numNomes >= MAX_ALUNOS) {
        printf("Limite máximo de alunos atingido.\n");
        return;
    }

    printf("Digite o nome do aluno: ");
    scanf(" %[^\n]", nome[numNomes]);
    printf("Digite a matrícula: ");
    scanf("%d", &matricula[numNomes]);
    printf("Digite o curso: ");
    scanf(" %[^\n]", curso[numNomes]);
    printf("Digite a data de nascimento no formato dd/mm/aaaa: ");
    scanf("%d/%d/%d", &dia[numNomes], &mes[numNomes], &ano[numNomes]);
    printf("Aluno cadastrado com sucesso!\n\n");

    numNomes++;
    return;
}

void pesquisaAluno(void) {
    char nomePesquisa[100];
    printf("Pesquisar aluno por nome: ");
    scanf(" %[^\n]", nomePesquisa);

    int encontrado = 0;
    for(int i = 0; i < numNomes; i++) {
        if(strcasecmp(nome[i], nomePesquisa) == 0) {
            encontrado = 1;
            printf("O aluno \"%s\" foi encontrado.\n", nomePesquisa);
            printf("Matrícula: %d\n", matricula[i]);
            printf("Curso: %s\n", curso[i]);
            printf("Data de nascimento: %02d/%02d/%04d\n", dia[i], mes[i], ano[i]);
            break;
        }
    }
    if(encontrado == 0) {
        printf("O aluno \"%s\" não foi encontrado.\n", nomePesquisa);
    }
    return;
}

void excluirAluno(void) {
    printf("Digite o nome do aluno que você deseja excluir: ");
    scanf(" %[^\n]", alunoExcluir);

    int encontrado = 0;
    for(int i = 0; i < numNomes; i++) {
        if(strcasecmp(nome[i], alunoExcluir) == 0) {
            encontrado = 1;
            printf("O aluno \"%s\" foi excluído.\n", nome[i]);

            for(int j = i; j < numNomes - 1; j++) {
                strcpy(nome[j], nome[j + 1]);
            }
            numNomes--;
            break;
        }
    }
    if(encontrado == 0) {
        printf("O aluno \"%s\" não foi encontrado.\n", alunoExcluir);
    }
    return;
}

void listarAlunos(void) {
    if(numNomes == 0) {
        printf("Nenhum aluno cadastrado.\n");
    }

    for(int i = 0; i < numNomes; i++) {
        printf("\nAluno %d:\n", i + 1);
        printf("Nome: %s\n", nome[i]);
        printf("Matrícula: %d\n", matricula[i]);
        printf("Curso: %s\n", curso[i]);
        printf("Data de nascimento: %02d/%02d/%04d\n\n", dia[i], mes[i], ano[i]);
    }
    return;
}

void editarAluno(void) {
    char editar[100];
    printf("Qual aluno você deseja editar as informações: ");
    scanf(" %[^\n]", editar);

    int encontrado = 0;
    for(int i = 0; i < numNomes; i++) {
        if(strcasecmp(nome[i], editar) == 0) {
            encontrado = 1;

            printf("Informações atuais do aluno:\n");
            printf("Nome: %s\n", nome[i]);
            printf("Matrícula: %d\n", matricula[i]);
            printf("Curso: %s\n", curso[i]);
            printf("Data de nascimento: %02d/%02d/%04d\n", dia[i], mes[i], ano[i]);

            printf("\nDigite as novas informações do aluno:\n");
            printf("Novo nome: ");
            scanf(" %[^\n]", nome[i]);
            printf("Nova matrícula: ");
            scanf("%d", &matricula[i]);
            printf("Novo curso: ");
            scanf(" %[^\n]", curso[i]);
            printf("Nova data de nascimento (dd/mm/aaaa): ");
            scanf("%d/%d/%d", &dia[i], &mes[i], &ano[i]);

            printf("Informações do aluno atualizadas com sucesso.\n");
            break;
        }
    }

    if(encontrado == 0) {
        printf("O aluno \"%s\" não foi encontrado.\n", editar);
    }
    return;
}
