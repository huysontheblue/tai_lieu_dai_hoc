#include <bits/stdc++.h>
using namespace std;
int tong(int a[],int n){
    if(n==1) {
        return a[0];
    }
    return (a[n-1]+tong(a,n-1));
}
int main()
{
	int a[4]={7, 8, 6, 9};
	printf("%d\n", tong(a,4));
	return 0;
}
// tuyen tinh
