#include <cstdlib>
#include <iostream>
#include <cstring>
#include <string>
#include <signal.h>
#include <string>
#include <stdarg.h>

using namespace std;

const int MAXV=5;
struct sinhvien
{
   int maso;
   char hoten[20];
   int namsinh;
   char gioitinh[5];
   char dctamtru[100];
   char dcthuongtru[100];
   sinhvien * link;
};
typedef sinhvien * sinhvienptr;
typedef sinhvienptr HashTable[MAXV];
//Bang bam
int Func(int a)
{
   return a%MAXV;
}
//Ham khoi tao bang bam
void Khoitao(HashTable ht)
{
   for(int i=0; i<MAXV;i++ )
   {
      ht[i]=NULL;
   }
}
//-------------------------Ham Them thong tin sinh vien-------------------------------
int Add(HashTable x, int ms,char ht[20], int ns, char gt[5], char dcthuongtru[100], char dctamtru[100])
{
   int k= Func(ms);
   sinhvienptr sv= new sinhvien;
   sv->maso=ms;
   strcpy(sv->hoten,ht);
   sv->namsinh=ns;
   strcpy(sv->gioitinh,gt);
   strcpy(sv->dcthuongtru,dcthuongtru);
   strcpy(sv->dctamtru,dctamtru);
   if(strcmp(sv->gioitinh,"nam")==0)
    sv->link=NULL;
   if(x[k]==NULL)
      x[k]=sv;
   else
   {
      sinhvienptr tam= x[k];
      while(tam->link!=NULL)
         {
            if(tam->maso==ms)
            {
               delete sv;
               return 0;
            }
            tam=tam->link;
         }      
            tam->link=sv;
   }
   return 1;
}
// ------------------------------Ham xoa thong tin sinh vien -----------------
int del(HashTable x, int ms)
{
   int k= Func(ms);
   sinhvienptr tam;
   sinhvienptr tam1;
   if(x[k]==NULL)
      return 0;
   if(x[k]->maso==ms)
   {
      tam1=x[k];
      x[k]=x[k]->link;
   }
   else
   {
      tam=x[k];
      tam1=tam->link;
      while(tam1!=NULL)
      {
         if(tam1->maso==ms)
            break;
         tam=tam1;
         tam1=tam1->link;
      }
      if(tam1==NULL)
         return 0;
      tam->link=tam1->link;
   }
   delete tam1;
   return 1;
}
//------------------------------Ham kiem tra du lieu -------------------------
int kiemtra(int ns)
{
   if(ns/100==20 && ns%100>=00 && ns%100<=50)
      return 1;
   else
      return 0;
}

//-------------------------------Ham tim kiem sinh vien ----------------------
int  Timkiemsv(HashTable x, int ms)
{
   int k= Func(ms);
   if(x[k]==NULL)
   {
      cout<<"\nKhong co sinh vien mang ma so nay";
      return 0;
   }
   sinhvienptr tam=x[k];
   while(tam!=NULL)
   {
      if(tam->maso==ms)
      {
         cout<<"\n******* THONG TIN SINH VIEN CAN TIM ************";
         cout<<"\n Ma so: "<<tam->maso;
         cout<<"\n Ho ten: "<<tam->hoten;
         cout<<"\n Ngay sinh: "<<tam->namsinh;
         if(tam->namsinh==NULL)
      tam->namsinh;

         cout<<"\n Gioi tinh: "<<tam->gioitinh;
         cout<<"\n Dia chi thuong tru: "<<tam->dcthuongtru;
         cout<<"\n Dia chi tam tru: "<<tam->dctamtru<<"\n";
         cout<<"**************************************************";
         break;
      }
      else
      {
         tam=tam->link;
      }
      if(tam==NULL)
         cout<<"\nKhong co sinh vien mang ma so nay";

   }
}
// ------------------------------Ham in danh sach sinh vien-------------------
void print(HashTable ht)
{
   cout<<"\n\t\t THONG TIN SINH VIEN\n";

   //cout<<"\n Ma so sinh vien"<<sv.maso;
   cout<<"MS  |    Ho ten   \t|  Ns \t| GT \t| D/c thuong tru \t| D/c tam tru \t|\n ";
   cout<<""; 
   for(int i=0;i<MAXV;i++)
   {
      sinhvienptr tam= ht[i];
      while(tam!=NULL)
      {
         cout<<tam->maso<<"  ";
         cout<<tam->hoten<<"\t";
         cout<<tam->namsinh<<"\t";
         cout<<tam->gioitinh<<"\t";
         cout<<tam->dcthuongtru<<"\t";
         cout<<tam->dctamtru<<"\t";
         cout<<"\n";
         tam=tam->link;
         
      }
   }
   
}
//--------------------------------------MENU-------------------------------
int menu()
{
   int chon;
   cout<<"\n\n\t\t\t\tMENU\n";
   cout<<"\n 1. Them thong tin sinh vien";
   cout<<"\n 2. Xoa thong tin sinh vien";
   //cout<<"\n 3. Sua thong tin sinh vien";
   cout<<"\n 3. Tim kiem thong tin sinh vien";
   cout<<"\n 4. Xuat bang bam";
   cout<<"\n 5. Nhap 0 de thoat khoi chuong trinh.";
   cout<<"\n 6. Nhap lua chon: ";
   cin>>chon;
   return chon;
}

int main()
{   
   HashTable x;
   int ms;
   char hoten[20];
   int namsinh;
   char gioitinh[5];
   char dctamtru[100];
   char dcthuongtru[100];
   int chon;
   Khoitao(x);

   do
   {
   chon=menu();
   switch(chon)
   {
   case 1:
      {
         
         cout<<"\n Nhap ma so sinh vien: ";
         cin>>ms;
         cin.ignore();
         cout<<"\n Nhap ho ten: ";
         cin.getline(hoten,20);
         cout<<"\n Nhap nam sinh: ";
         cin>>namsinh;
         cin.ignore();
         cout<<"\n Nhap gioi tinh: ";
         cin.getline(gioitinh,5);
         cout<<"\n Nhap dia chi tam tru: ";
         cin.getline(dctamtru,100);
         cout<<"\n Nhap dia chi thuong tru: ";
         cin.getline(dcthuongtru,100);
         if(kiemtra(namsinh)==1)
         {

            if (Add(x, ms, hoten, namsinh, gioitinh, dctamtru, dcthuongtru)==1)
               cout<<"\n Them thanh cong";
            else
               cout<<"\n Them that bai";
         }
         else
            cout<<"\n Nam sinh khong hop le";
         
         break;
      }
   case 2:
      {
         int xoa;
         cout<<"\nNhap ma so sinh vien can xoa: ";
         cin>>xoa;
         if(del(x,xoa)==0)
            cout<<"\n Xoa that bai, ko co sinh vien nay.";
         else
            cout<<"\n Xoa thanh cong";
         break;
      }
   case 3:
      {
         cout<<"\n Nhap ma so sinh vien can tim:";
         cin>>ms;
         Timkiemsv(x,ms);
         break;
      }
   case 4:
      {
         print(x);
         break;
      }
   case 5:
      break;
   default:
      {
         cout<<"\n Lua chon khong hop le.";
         break;
      }

   }
   }
   while (chon!=0);
   cin.get();
}
