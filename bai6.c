#include <stdio.h>
#include <conio.h>
int Fibonacci(int n)
{
    if (n == 1 || n == 2)
        return 1;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
int main()
{
    int n;
    printf("nhap n: ");
    scanf("%d", &n);
    for(int i =1 ; i<=n;i++){
    printf(" %d,", Fibonacci(i));
    }
    return 0;
}