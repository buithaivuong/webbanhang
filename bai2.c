#include<stdio.h>
#include<stdlib.h>
int insert (struct node **root ,int newvalue){
 struct node *newnode;
 newnode = (strcut node *)malloc(sizeof(struct node));
 newnode->value= newvalue;
 newnode -> left = NULL;
 newnode->right = NULL;
 if(*root ==NULL){
  *root = newnode;
 }else{
  if(newvalue<(*root)-> value){
    insert(&(*root)->left,newvalue);
  }else{
    insert(&(*root)->right,newvalue);
  }
 }
 return 1;
}
int main (){
  insert();
}