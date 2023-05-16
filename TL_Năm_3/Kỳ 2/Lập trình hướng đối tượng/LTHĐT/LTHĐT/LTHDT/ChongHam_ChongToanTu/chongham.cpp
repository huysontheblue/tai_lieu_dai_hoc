#include <bits/stdc++.h>
using namespace std;
// Hàm tìm max c?a 2 s? nguyên
int max(int x, int y) {
  return (x>y) ? x:y;
}
// Hàm tìm max c?a 2 s? th?c
double max(double x, double y) {
  return (x>y) ? x:y;
}
//Hàm tìm max c?a 2 ký t?:
char max(char x, char y) {
   return (x>y) ? x:y;
}
int main() {
    cout<<"\n Max ="<< max(2,5);		// g?i hàm max nào?
    cout<<"\n Max ="<< max(2.5,5.5);	// g?i hàm max nào?
    cout<<"\n Max ="<< max('a', ' c' );	// g?i hàm max nào?
} 

