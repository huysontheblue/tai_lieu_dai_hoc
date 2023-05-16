#include <bits/stdc++.h>
using namespace std;
double tinhS(int x, int n){
	if(n==1)
	{
	    return pow(x,2*n);
	}
    return tinhS(x,n-1)+pow(x,2*n);
}
int main() {
	int x, n, s;
	s = 0;
	cin>>x>>n;
	cout << tinhS(x,n);
	return 0;
}
	

