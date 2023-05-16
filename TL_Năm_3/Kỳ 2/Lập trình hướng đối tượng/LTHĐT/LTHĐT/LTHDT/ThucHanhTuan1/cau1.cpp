#include <bits/stdc++.h>
using namespace std;

int main() {
	int chieucao;
	cout<<"nhap n : ";
	cin >> chieucao;
	for(int i =1;i<=chieucao;i++){
		for(int j=i; j<chieucao;j++)
		{
			cout<<" ";
		}
		for (int j=1;j<=i;j++)
		{
			cout<<"  "<<i;
		}
		cout<<endl;
	}
	return 0;
}
