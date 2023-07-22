#include<stdio.h>
#include<stdlib.h>
#include<conio.h>
void chon1(){
  printf("ban thich doc sach?\n");
}
void chon2(){
  printf("ban thich nghe nhac?\n");
}
void chon3(){
  printf("ban thich choi the thao?\n");
}
void chon4(){
  printf("ban thich may tich?\n");
}
void chon5(){
  printf("vui long thu lai \n");
}
int main (int argc,char *argv[]){
  int gt;
  do{
  printf ("SO THICH CA NHAN \n");
  printf("1- doc sach\n");
  printf("2- nghe nhac \n");
  printf("3- choi the thao \n");
  printf("4- may tinh \n");
  printf("5- thoat\n");
  printf("chon\n");
  scanf("%d",&gt); 
  switch (gt){
    case 1: chon1();
  
    break;
   
    break;
    case 3: chon3();
    
    break;
    case 4: chon4();
    
    break;
    case 5: chon5();
    
    break;
    default: printf("gia tri khong dung \n");
  }
}while (gt!=5 );
}

