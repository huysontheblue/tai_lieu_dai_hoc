#include <stdlib.h>
#include <stdio.h>
 
#define Max 10 //so phan tu toi da cua Stack
typedef int item; //kieu du lieu cua Stack
struct Stack
{
    int Top; //Dinh Top
    item Data[Max]; //Mang cac phan tu
};
 
void Init (Stack &S); //khoi tao Stack rong
int Isempty(Stack S); //kiem tra Stack rong
int Isfull(Stack S); //kiem tra Stack day
void Push(Stack &S, item x); //them phan tu vao Stack
int Peak(Stack S); //Lay phan tu o dau Stack nhung khong xoa
int Pop(Stack &S); //Loai bo phan tu khoi Stack
void Input (Stack &S); //Nhap Stack
void Output(Stack S); //Xuat Stack
 
void Init (Stack &S) //khoi tao Stack rong
{
    S.Top = 0; //Stack rong khi Top la 0
}
 
int Isempty(Stack S) //kiem tra Stack rong
{
    return (S.Top == 0);
}
 
int Isfull(Stack S) //kiem tra Stack day
{
    return (S.Top == Max); //
}
 
void Push(Stack &S, item x) //them phan tu vao Stack
{
    if (!Isfull(S))
    {
        S.Data[S.Top] = x; //Gan du lieu
        S.Top ++; //Tang Top len 1
    }
}
 
int Peak(Stack S) //Lay phan tu o dau Stack nhung khong xoa
{
    return S.Data[S.Top-1]; //Lay du lieu tai Top
}
 
int Pop(Stack &S) //Loai bo phan tu khoi Stack
{
    if (!Isempty(S))
    {
        S.Top --; //Giam Top
        return S.Data[S.Top]; //Lay du lieu tai Top
    }
}
 
void Input (Stack &S)
{
    int n;
    item x;
    do
    {
        printf("Nhap so phan tu cua Stack (<%d) :",Max);
        scanf("%d",&n);
    } while (n>Max || n<1);
    for (int i=0; i<n; i++)
    {
        printf("Nhap phan tu thu %d : ", i+1);
        scanf("%d",&x);
        Push(S,x);
    }
}
 
void Output(Stack S)
{
    for (int i=S.Top-1; i>=0; i--)
        printf("%d   ",S.Data[i]);
    printf("\n");
}
 
int main()
{
    Stack S;
    Init(S);
    Input(S);
    Output(S);
 
    int lua_chon;
    printf("Moi ban chon phep toan voi DS LKD:");
    printf("\n1: Kiem tra Stack rong");
    printf("\n2: Kiem tra Stack day");
    printf("\n3: Them phan tu vao Stack");
    printf("\n4: Xoa phan tu trong Stack");
    printf("\n5: Xuat Stack");
    printf("\n6: Lay phan tu o dau stack nhung khong xoa");
    printf("\n7: Thoat");
    do
    {
        printf("\nBan chon: ");
        scanf("%d",&lua_chon);
        switch (lua_chon)
        {
            case 1:
            {
                if (Isempty(S)) printf("Stack rong !");
                else printf ("Stack khong rong !");
                break;
            }
            case 2:
            {
                if (Isfull(S)) printf("Stack day !");
                else printf ("Stack chua day !");
                break;
            }
            case 3:
            {
                item x;
                printf ("Nhap phan tu can chen vao DS: ");
                scanf("%d",&x);
                Push(S,x);
                break;
            }
            case 4:
            {
                Pop(S);
                break;
            }
            case 5: 
            {
                Output(S);
                break;
            }
            case 6: 
			{   
			    item x;
                printf ("Lay phan tu tren cung cua ngan xep: "); 
                scanf("%d",&x);    
				Peak(S);
                break;
            }
            case 7: break;
        }
    }while (lua_chon !=6);
    return 0;
}
