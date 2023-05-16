#include <iostream> 
using namespace std;

int N = 6; /* S? ph?n t? c?a heap */
void max_heap(int A[], int i, int heap_size) {
    int largest; /* Ch? s? c?a ph?n t? l?n nh?t trong b? ba: node hi?n t?i
                         con b�n tr�i, v� con b�n ph?i c?a n� */
    int left = 2 * i; /* V? tr� c?a con b�n tr�i */
    int right = 2 * i + 1; /* V? tr� c?a con b�n ph?i */
    if (left <= heap_size and A[left] > A[i]) /* heap_size l� s? ph?n t? trong m?ng*/
        largest = left;
    else
        largest = i;
    if (right <= heap_size and A[right] > A[largest])
        largest = right;
    if (largest != i) {
        swap(A[i], A[largest]); /* Th?c hi?n d?i ch? hai ph?n t? n?u 
                                              gi� tr? c?a node cha nh? hon node con */
        max_heap(A, largest, heap_size); /* G?i d? quy node t?i v? tr� m?i */
    }
}

void run_maxheap(int A[]) { /* �p d?ng h�m max_heap cho t?t c? c�c node
                                               tr? node l� */
    for (int i = N / 2; i >= 1; i--) {
        max_heap(A, i, N);
    }
}

void max_heap_sort(int A[ ])
{
    int heap_size = N;
    run_maxheap(A);
    for(int i = N; i>=2 ; i-- )
    {
        swap(A[ 1 ], A[ i ]);
        max_heap(A, 1, --heap_size);
    }
}

int main() {
    int A[7] = {-1,8,4,7,1,3,5};
    int n = sizeof(A)/sizeof(int);
    max_heap_sort(A);
    printf("\n\tGia tri cua mang sau khi ap dung h�m max_heap_sort\n");
    printf("\t");
    for (int i = 0; i < N+1; i++) { /* In ra gi� tr? c?a m?ng sau khi s?p x?p v?i 
                                                 h�m max_heap_sort */
        printf("%d    ", A[i]);
    }
}
