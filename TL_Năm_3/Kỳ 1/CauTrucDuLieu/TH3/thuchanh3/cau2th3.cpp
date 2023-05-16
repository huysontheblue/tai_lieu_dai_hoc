// sap xep chen

#include<stdio.h>

 void InsertionSort(int a[], int n)
 {
    for (int i = 1; i < n; i++)
  {
    int x = a[i];
    int j = i-1;
       while (j >=0 && a[j ] > x) 
       {
          a[j+1] = a[j];
          j--;
       }
    a[j+1] = x;
    printf("\nDay sau buoc thu %d la: ", i); 
       for(int i = 0; i < n; i++) 
        printf("%d ", a[i]); 
  }
}
int main()
{
	int a[] = {4, 8, 9, 6, 7, 2, 3}; 
    printf("Day truoc khi sap xep la: "); 
       for(int i = 0; i < 8; i++) 
           printf("%d ", a[i]); 
    InsertionSort(a, 8); 
    printf("\nDay sau khi sap xep la: "); 
        for(int i = 0; i < 8; i++) 
           printf("%d ", a[i]); 
}

