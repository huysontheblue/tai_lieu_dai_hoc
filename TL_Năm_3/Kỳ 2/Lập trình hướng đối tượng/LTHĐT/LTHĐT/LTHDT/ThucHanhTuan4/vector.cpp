#include<iostream>
using namespace std;
class vector {
private:
	int n;
	float* v;
public:
	vector();
	void display();
	~vector()
	{
		delete v;
	}
};

vector::vector() 
	{
		cout<<"Moi nhap so phan tu n = "; cin>>n;
		v = new float[n];
		for (int i = 0; i < n; i++)
		{
			cout << "v[" << i << "]=";
			cin >> v[i];
		}
		
	}

void vector::display()
	{

		for (int i = 0; i < n; i++)
			cout << "\t" << v[i];
		cout<<"\n";
		
	}
int main()
{
	int m;
	cout << " Nhap so vecto:";
	cin >> m;
	vector b[m];
	for (int i = 0; i < m; i++)
		b[i].display();
	
	return 0;
}
