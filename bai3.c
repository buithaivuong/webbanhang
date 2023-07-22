#include <stdio.h> 
#include <string.h>
#include <stdlib.h>

struct Acc{ 
    char name[25];
    char number[15]; 
    char Pin[6]; 
    int balance; 
};
struct Acc acc; 
void createAcc(struct Acc acc);
void menu();
void login();
void uiBank();
void checkingBalance();
void withdrawal();
void changePin();
void getString(char str[]); 
void getInt(int *num);
void main(){
    menu();
}
void menu(){ 
    int choice;
    printf("\n==============================\n");     
    printf(" VTC Academy Bank\n");
    printf("==============================\n");
    printf(" ATM Machine\n");
    printf("------------------------------\n");
    printf("1.User log in\n");
    printf("2.Create account\n");
    printf("3.Exit\n");
    printf("------------------------------\n");
    printf("Your choice: ");
    scanf("%d", &choice);
    while (choice != 1 && choice != 2 && choice != 3) {
        printf("Invalid choice, please enter again: ");
        scanf("%d", &choice);
    }
    switch (choice){
    case 1:
        login();
        break;
    case 2:
        createAcc(acc);
        break;
    default:
        break;
    }   
}

void login(){
    int found = 0;
    FILE *f = fopen("C:\\Users\\THA\\Desktop\\vuong2.txt", "r");
    if (f == NULL) {
        printf("ko the mo file\n");
        exit(1);
    }
    char accNo[20], accPin[20];
    printf("nhap tai khoan: ");
    getString(accNo);
    printf("nhap mat khau: ");
    getString(accPin);
    while(fscanf(f,"%s %s %s %d", acc.name, acc.number, acc.Pin, &acc.balance) == 4) {
        if (strcmp(accNo, acc.number) == 0 && strcmp(accPin, acc.Pin) == 0) {
            found = 1;
            break;
        }
    }
    fclose(f);
    if (found){
        printf("Dang nhap thanh cong.\n");
        uiBank();
    } 
    else{
        printf("Loi dang nhap.\n");
    }
}


void createAcc(struct Acc acc){ 
    FILE *f = fopen("C:\\Users\\THA\\Desktop\\vuong2.txt", "a");
    if (f == NULL) {
        printf("khong the mo file.\n");
        exit(1);
    }
    printf("\n==============================\n"); 
    printf(" VTC Academy Bank\n");
    printf("==============================\n");
    printf(" Create ATM Cards\n");
    printf("------------------------------\n");
    printf(" Input Account Name: \n"); 
    getString(acc.name);
    printf(" Nhap tai khoan 14 ki tu: \n"); 
    getString(acc.number);
    while(strlen(acc.number) < 14 ){
        printf(" Nhap lai so tai khoan: ");
        getString(acc.number);
    }
    printf("Nhap Ma PIN gom 6 so : "); 
    getString(acc.Pin); 
    while(strlen(acc.Pin) < 6){
        printf(" Nhap lai ma pin: \n");
        getString(acc.Pin);
    }
    printf(" So du tai khoan: ");
    getInt(&acc.balance); 
    while(acc.balance<50000){
        printf(" So du tai khoan phai lon hon hoac bang 50000VND: ");
        getInt(&acc.balance);
    } 
    printf("------------------------------\n");
    printf(" Do you want to create ATM Card? (Y/N): "); 
    char answer[3]; 
    getString(answer); 
    while (strcmp(answer, "Y") != 0 && strcmp(answer, "y") != 0 && strcmp(answer, "N") != 0 && strcmp(answer, "n") != 0){ 
        printf("Vui long nhap lai ");
        getString(answer);   
    } 
    if (strcmp(answer,"Y") == 0 || strcmp(answer,"y") == 0){
        fprintf(f,"%s %s %s %d", acc.name, acc.number, acc.Pin, acc.balance);
        fprintf(f,"\n");
        fclose(f);
        printf(" Create ATM complete!\n");
    }
    menu();
}


void uiBank(){
    int choice;
    FILE *f = fopen("C:\\Users\\THA\\Desktop\\vuong2.txt", "r");
    if (f == NULL) {
        printf("khong the mo file\n");
        exit(1);
    }
    printf("\n==============================\n");     
    printf(" VTC Academy Bank\n");
    printf("==============================\n");
    printf(" ATM Machine\n");
    printf("------------------------------\n");
    printf(" Account Number: %s\n",acc.number);
    printf(" Pin Code: ******\n");
    printf("------------------------------\n");
    printf("Account Name: %s\n",acc.name);
    printf("------------------------------\n");
    printf(" 1. Checking account balance\n");
    printf(" 2. Withdrawal\n");
    printf(" 3. Transfers\n");
    printf(" 4. Change PIN\n");
    printf(" 5. End of transaction\n");
    printf("------------------------------\n");
    printf(" Your choice: ");
    scanf("%d",&choice);
    while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5) {
        printf("Vui long thu lai: ");
        scanf("%d", &choice);
    }
    switch (choice){
    case 1:
        checkingBalance();
        break;
    case 2:
        break;
    case 3:
        break;
    case 4:
        break;
    default:
        break;
    }
}


void checkingBalance(){
    char ch;
    FILE *f = fopen("C:\\Users\\THA\\Desktop\\vuong2.txt", "r");
    printf("------------------------------\n");
    printf(" So du tai khoan: %d VND\n",acc.balance);
    fflush(stdin);
    printf(" Nhan Enter de tiep tuc\n");
    scanf("%c",&ch);
    uiBank();
}

void getString(char str[]){
    scanf("%s", str); 
}

void getInt(int *num){ 
    scanf("%d", num); 
}