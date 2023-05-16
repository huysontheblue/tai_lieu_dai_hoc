#include<conio.h>
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
	int n; int a[10];
	FILE *fsort;
	fsort = fopen("intput.txt","r");
	fscanf(fsort,"%d",&n);
	a[n];
	for(int i=0; i<n; i++)
		fscanf(fsort,"%d",&a[i]);
	printf("\nGia tri lay tu intput : ");
	for(int i=0; i<n; i++)
		printf("%d  ",a[i]);
	fclose(fsort);
    Selectionsort(a, n);
	return 0;
}
