#include <bits/stdc++.h>
using namespace std;
// H�m t�m max c?a 2 s? nguy�n
int max(int x, int y) {
  return (x>y) ? x:y;
}
// H�m t�m max c?a 2 s? th?c
double max(double x, double y) {
  return (x>y) ? x:y;
}
//H�m t�m max c?a 2 k� t?:
char max(char x, char y) {
   return (x>y) ? x:y;
}
int main() {
    cout<<"\n Max ="<< max(2,5);		// g?i h�m max n�o?
    cout<<"\n Max ="<< max(2.5,5.5);	// g?i h�m max n�o?
    cout<<"\n Max ="<< max('a', ' c' );	// g?i h�m max n�o?
} 

