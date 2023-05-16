#include<iostream>
#include<string.h>
#include<conio.h>
#include<stdio.h>
#include<iomanip>
#include<fstream>
using namespace std;

void swap(int &xp, int &yp)
{
    int temp = xp;
    xp = yp;
    yp = temp;
}
 void xuatmang(int arr[], int size)
{
    int i;
    for (i=0; i < size; i++)
        printf("%d  ", arr[i]);
}
void selectionSort(int arr[], int n)// sap xep chon
{
    for (int i = 0; i < n-1; i++)
    {
    	int min = i;
    for (int j = i+1; j < n; j++)
        if (arr[j] < arr[min])
        min = j;
        swap(arr[min], arr[i]);
    }
}
void insertionSort(int arr[], int n)// sap xep chen
{
   int i, key, j;
   int demb=1;
   
   
   for (i = 1; i < n; i++)
   {
       int deml=1;
	   cout<<"\nBuoc "<<demb<<": i= "<<i;
	   key = arr[i];
       j = i-1;
 
       /* Di chuyen cac phan tu co gia tri lon hon gia tri
       key ve sau mot vi tri so voi vi tri ban dau cua no */
       while (j >= 0 && arr[j] > key)
       {
       		
       		cout<<"\n\tLan "<<deml<<" :";
           	arr[j+1] = arr[j];
           	j = j-1;
           	arr[j+1] = key;
           	deml++;
           	xuatmang(arr, n);
       }
       arr[j+1] = key;
       if(j >= 0 && arr[j] < key) 
	   {
	   		cout<<endl<<"\t";
	   		xuatmang(arr, n);
	   }
       demb++;
   }
} 

void noibot(int arr[],int n)
{
	int i,j;
	//int demb=1;
	for(int i=0; i<n-1; i++)
	{
		int deml=1;
	   	//cout<<"\nBuoc "<<demb<<": i= "<<i;
		for(int j=n-1; j-1>=i ; j--)
		{
			if(arr[j]<arr[j-1])
			{
//				cout<<endl<<"\t";
//	   			xuatmang(arr, n);
				swap(arr[j],arr[j-1]);
				cout<<endl<<"\t";
	   			xuatmang(arr, n);cout<<endl;	
			}

		}
	}
}

void quickSort(int a[],int l,int r)
{
    //int key = a[l + rand() % (r-l+1)];  //lay khoa la gia tri ngau nhien tu a[l] -> a[r]
    int key = a[(l+r)/2];
    
    int i = l, j = r;
//    printf("\n\nl = %d   r = %d    select: key = %d  (random) ",l, r, key);
	printf("\n\nl = %d   r = %d    select: key = %d ",l, r, key); 
    while(i <= j)
    {
        //printf("n");
        printf("\n\n\ti : %d", i);
        while (a[i] < key) { i++; printf(" -> %d",i); }
        printf("\n\tj : %d", j);
        while (a[j] > key) { j--; printf(" -> %d",j); }
        if(i <= j)
        {
            if (i < j)
            {
                swap(a[i], a[j]);  // doi cho 2 phan tu kieu int a[i], a[j].
                printf("\n\tswap(a[%d], a[%d])  swap(%d, %d)", i, j, a[i], a[j]);
            }
            i++;
            j--;
            printf("\n\tarr[] : ");
            for (int i=0; i<10; i++)
                printf ("%d ", a[i]);
        }
    }
    //bay gio ta co 1 mang : a[l]....a[j]..a[i]...a[r]
    if (l < j) quickSort(a, l, j);   // lam lai voi mang a[l]....a[j]
    if (i < r) quickSort(a, i, r); // lam lai voi mang a[i]....a[r]
}

//hoan vi nut cha thu i phai lon hon nut con (vun dong)
void Heapify(int A[],int n, int i) 
{
 int Left = 2*(i+1)-1;
 int Right = 2*(i+1);
 int Largest;
 if(Left<n && A[Left]>A[i])
  Largest = Left;
 else
  Largest = i;
 if(Right<n && A[Right]>A[Largest])
  Largest = Right;
 if(i!=Largest) 
  {
    swap(A[i],A[Largest]);
    Heapify(A,n,Largest);
  }
}
//xay dung Heap sao cho moi nut cha luon lon hon nut con tren cay (tao cay)
void BuildHeap(int A[], int n) 
{
  for(int i = n/2-1; i>=0; i--)
  Heapify(A,n,i);
}
// heap-sort
void HeapSort(int A[], int n) 
{
  BuildHeap(A,n);
  for(int i = n-1; i>0; i--)
  {
    
	swap(A[0],A[i]);
    Heapify(A,i,0);
  }
}



int main()
{
	FILE *fsort;
    char ch;
    int chon;
    int n;
    int a[50];
	
    do{
	    system("cls");
	    cout<<"==================MENU================"<<endl;
	    cout<<"1.Nhap mang"
			<<endl<<"2.Xuat mang"
			<<endl<<"3.Sap xep chon"
			<<endl<<"4.Sap xep chen"
			<<endl<<"5.Sap xep noi bot"
			<<endl<<"6.Sap xep nhanh"
			<<endl<<"7.Sap xep vun dong"
			<<endl<<"0.Thoat";
	    cout<<endl<<"Chon: ";
		cin>>chon;
	    switch(chon)
	    {
	    	case 1://nhap mang
	    		printf("\nNhap so luon phan tu = ");
				scanf("%d",&n);
//				int a[n];
				for(int i=0; i<n; i++)
				{
					printf("\n\tGia tri phan tu thu %d = ",i+1);
					scanf("%d",&a[i]);
				}
				printf("\n\n\tBan da nhap : ");
				for(int i=0; i<n; i++)
					printf("%d  ",a[i]);
				FILE *fsort;
				fsort = fopen("intput.txt","a");
				fprintf(fsort,"%d\n",n);
				for(int i=0; i<n; i++)
					fprintf(fsort,"%d\n",a[i]);
				fclose(fsort);
				printf("\n\n\tLuu FILE thanh cong ! :> ");
				break;
	    	case 2://xuat mang
				fsort = fopen("intput.txt","r");
				fscanf(fsort,"%d",&n);
				a[n];
				for(int i=0; i<n; i++)
					fscanf(fsort,"%d",&a[i]);
				printf("\nGia tri lay tu intput : ");
				for(int i=0; i<n; i++)
					printf("%d  ",a[i]);
				fclose(fsort);
	    		system("pause");
        		break;
        	case 3://sap xep chon
        		fsort = fopen("intput.txt","r");
				fscanf(fsort,"%d",&n);
				for(int i=0; i<n; i++)
					fscanf(fsort,"%d",&a[i]);
				selectionSort(a,n);
				printf("\nGia tri lay tu intput : ");
				for(int i=0; i<n; i++)
					printf("%d  ",a[i]);
				fclose(fsort);
				system("pause");
        		break;
        	case 4://sap xep chen
        		fsort = fopen("intput.txt","r");
				fscanf(fsort,"%d",&n);
				for(int i=0; i<n; i++)
					fscanf(fsort,"%d",&a[i]);
				insertionSort(a,n);
				printf("\nGia tri lay tu intput : ");
				for(int i=0; i<n; i++)
					printf("%d  ",a[i]);
				fclose(fsort);
				system("pause");

			case 5://noi bot
        		fsort = fopen("intput.txt","r");
				fscanf(fsort,"%d",&n);
				for(int i=0; i<n; i++)
					fscanf(fsort,"%d",&a[i]);
				noibot(a,n);
				printf("\nGia tri lay tu intput : ");
				for(int i=0; i<n; i++)
					printf("%d  ",a[i]);
				fclose(fsort);
				system("pause");
			case 6://sap xep nhanh 
				fsort = fopen("intput.txt","r");
				fscanf(fsort,"%d",&n);
				for(int i=0; i<n; i++)
					fscanf(fsort,"%d",&a[i]);
				quickSort(a, 0, n-1);
				printf("\nGia tri lay tu intput : ");
				for(int i=0; i<n; i++)
					printf("%d  ",a[i]);
				fclose(fsort);
				system("pause");
			case 7://vun dong
				fsort = fopen("intput.txt","r");
				fscanf(fsort,"%d",&n);
				for(int i=0; i<n; i++)
					fscanf(fsort,"%d",&a[i]);
				HeapSort(a,n);
				printf("\nGia tri lay tu intput : ");
				for(int i=0; i<n; i++)
					printf("%d  ",a[i]);
				fclose(fsort);
				system("pause");
	    	case 0:
	    		break;
	    	default:
				cout<<"Ban chon sai!Moi ban chon lai menu! ";
				system("pause");
				break;
		}
	}while(chon!=0);
	
	return 0;
}
