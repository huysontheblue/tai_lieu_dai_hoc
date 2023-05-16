#include<conio.h>
#include<stdio.h>
float LuyThua(float x , int n) { 
if(n == 0)
return 1; 
return LuyThua(x,n-1)*x; 
}
float Tong(float x , int n) { 
if(n == 1) {
return x; 
}
return Tong(x,n-1) + LuyThua(x,n-1)*x; 
}
int main(){
    int x, n;
    int lt = 1;
    int s = 0;
    printf("Nhap x: ");
    scanf("%d",&x);
    printf("Nhap n: ");
    scanf("%d",&n);
    //Nhap gia tri x, n
    for(int i = 1; i <= n; i++){
        lt = lt * x;
        s += lt;
    }
    //Tinh s = x^1 + x^2 + .. + x^n
    printf("%d",s);
}





