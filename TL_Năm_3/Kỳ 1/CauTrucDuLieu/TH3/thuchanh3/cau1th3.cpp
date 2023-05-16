// sap xep chon

#include<stdio.h>

void Selectionsort(int a[], int n)
{
	for(int i=0; i<n-1; i++)
	  {
	  	int min = i;
	  	  for(int j=i+1; j<n; j++)
	  	if(a[min]>a[j])
	  	  min = j;
	  	if(min !=i)
	  	  {
	  	    int tam=a[i];
	  	    a[i]=a[min];
	  	    a[min]=tam;
          }
        printf(" \n day sau luot sap xep thu %d:",i+1);
		   for(int k=0; k<n; k++)
		       printf(" %d", a[k]);
      }
}
int main()
{
	int a[] = { 4, 8, 9, 6, 7, 2, 3};
	printf("\n Day truoc khi sap xep la: "); 
        for(int i = 0; i < 6; i++) 
            printf("%d ", a[i]); 
          Selectionsort(a, 6);
    printf("\n Day sau khi sap xep la: "); 
        for(int i = 0; i < 6; i++) 
            printf("%d ", a[i]); 
}

