#include<bits/stdc++.h>
using namespace std;
class Circle{
    private: float r;
    public:
        const float pi = 3.14;
        /* Constructor */
        Circle(float r){
            this->r = r;
        };
        Circle(){
        };
        /* Ham nhap ban kinh */
        void set(float r){
            this->r = r;
        };

        float get(){
            return this->r;
        };

        /* Ham tinh chu vi */
        float chuvi(){
            return r*r*pi;
        };
        /* In */
        void display(){
            cout << "Ban kinh: " << r << endl << "Chu vi: " << chuvi() << endl;
        }
};
int main() {
    int n; float r;
    cout << "Nhap vao so luong: "; cin >> n;
    Circle **arr = new Circle*[n];
    for (int i = 0; i<n; i++){
        cout << "Nhap ban kinh thu " << i+1 << endl;
        cin >> r;
        arr[i] = new Circle(r);
        arr[i]->display();
    }
            /* b */
    cout << "Nhap ban kinh: "; cin >> r;
    Circle x(r);
    bool found = false;
    for (int i = 0; i<n; i++){
        if (arr[i]->chuvi() == x.chuvi()){
            found = true;
            break;
        }
    }
    if (found) cout << "Ton tai";
    else cout << "Khong ton tai";
    return 0;
}
