#include <bits/stdc++.h>
using namespace std;
// chong toan tu
struct ps{
int ts;
int ms;
};
ps taophanso
// Hàm cong hai phân so:
ps cong(ps a, ps b) {
ps c;
c.ts  =  a.ts*b.ms + a.ms*b.ts;
c.ms =  a.ms*b.ms;
return c;
}
int main()
{
    cout << "int max = " << ps cong(4, 5) << endl;
    //cout << "float max = " << max(4.4, 5.5) << endl;
    return 0;
}
