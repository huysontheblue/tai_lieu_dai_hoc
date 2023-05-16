#include<iostream>
using namespace std;

template <class T>
T max(T *a, int n){
	T max1 = a[0];
	for (int i=0; i<n; i++){
		if (a[i] > max1){
			max1 = a[i];
		}
	}
	return max1;
}

int main(){
	cout <<"\n\t SO NGUYEN \n";
	int *ListInt = new int[3];
	for (int i=0; i<3; i++){
		cout <<"\n Nhap so thu "<<i+1<<" la: "; cin >> ListInt[i];
	}
	int maxInt = max(ListInt, 3);
	cout <<"\n MAX = "<< maxInt<<endl;
	
	cout <<"\n\t SO THUC \n";
	float *ListFloat = new float[3];
	for(int i=0; i<3; i++){
		cout <<"\n Nhap so thu "<<i+1<<" la: ";
		cin >> ListFloat[i];
	}
	float maxFloat = max(ListFloat, 3);
	cout <<"\n MAX = "<< maxFloat;
	
	cout << "\n\t KY TU \n";
	char *ListChar = new char[3];
	for(int i=0; i<3; i++){
		cout <<"\n Nhap ky tu thu "<<i+1<<" la: ";
		cin>>ListChar[i];
	}
	char maxChar = max(ListChar, 3);
	cout <<"\n MAX = "<< maxChar;
	
	cout <<"\n\t XAU KY TU \n";
	string *ListXau = new string[3];
	for(int i=0; i<3; i++){
		cout <<"\n Nhap xau thu "<<i+1<< " la: ";
		cin >> ListXau[i];
	}
	string maxXau = max(ListXau, 3);
	cout <<"\n MAX = "<< maxXau;
}
