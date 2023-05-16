#include <bits/stdc++.h>
using namespace std;

int mul(int a, int n) {
	if (n == 0) return 1;
	else 
		return a*mul(a,n-1);
}

int tong(int a, int n) {
	if (n == 0) return 0;
	else 
		return tong(a,n-1)+mul(a,n);
}
int main() {
	int a, n;
	cin>>a>>n;
	cout << tong(a,n);
	return 0;
	
}
