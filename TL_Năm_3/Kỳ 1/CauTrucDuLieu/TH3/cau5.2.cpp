#include <iostream>
using namespace std;

// Vun dong mot cay con co nut root la i
// n la kich thuoc cua dong
void heapify(int arr[], int n, int i)
{
	int largest = i; // khoi tao largest nhu la root
	int l = 2 * i + 1; // left = 2*i + 1
	int r = 2 * i + 2; // right = 2*i + 2

	// Neu nut con trai lon hon so voi root
	if (l < n && arr[l] > arr[largest])
		largest = l;

	// Neu nut con phai lon hon so voi root
	if (r < n && arr[r] > arr[largest])
		largest = r;

	// Neu root khong phai la lon nhat
	if (largest != i)
	{
		swap(arr[i], arr[largest]);

		// De quy lai ham heapify
		heapify(arr, n, largest);
	}
}

// Ham vun dong
void heapSort(int arr[], int n)
{
	// Tao mot dong (Sap xep lai mang)
	for (int i = n / 2 - 1; i >= 0; i--)
		heapify(arr, n, i);

	// Trích xu?t t?ng m?t ph?n t? m?t t? heap
	for (int i = n - 1; i >= 0; i--)
	{
		// Di chuyen root ve cuoi cung
		swap(arr[0], arr[i]);

		// goi ham heapify
		heapify(arr, i, 0);
		printf("\ni = %3d: ", i); printArray(arr, n);
	}
}

void printArray(int arr[], int n)
{
	for (int i = 0; i<n; ++i)
		cout << arr[i] << " ";
	cout << "\n";
}

int main()
{
	int arr[] = { 12, 11, 13, 5, 6, 7 };
	int n = sizeof(arr) / sizeof(arr[0]);
	printf("n = %d", n);
	printf("\nINPUT: "); 
	printArray(arr, n); 
	printf("\n");
    heapSort(arr, n);
    cout << "Sorted array is \n";
	printArray(arr, n);
	cin.get();
	getchar();
	return 0;
}
