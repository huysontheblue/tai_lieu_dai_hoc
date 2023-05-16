#include <iostream>
#include <conio.h>
#include <windows.h>
using namespace std;
void gotoxy(int column, int line)
{
 
    COORD coord;
 
    coord.X = column;
 
    coord.Y = line;
 
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}
int move() {
 
    char c = getch();
 
    if ((int) c == -32) c = getch();
 
    switch ((int) c) {
 
        case 80:
            return 1; //cout << "Xuong";
 
        case 72:
            return 2; //cout << "Len";
 
        case 77:
            return 3; //cout << "Phai";       
 
        case 75:
            return 4; //cout << "Trai";
 
        case 27:
            return 8; //Nut ESC thoat
 
        case 13:
            return 5; //Nut Enter
 
        default:
            return 0; //cout << "Sai";
 
    }
 
}
class Menu {
 
    public:
 
        Menu();
 
    ~Menu() {}
 
    void printMenu();
 
    void deleteMenu(); //X�a menu khi k?t th�c chuong tr�nh b?ng c�ch vi?t d� k� t? tr?ng
 
    int numberOfItem() {
        return _numberOfItem;
    }
 
    string * getItem() {
        return item;
    }
 
    private:
 
        string * item; //M?ng luu t�n c?a c�c menu
 
    int _numberOfItem; //S? lu?ng menu
};
Menu::Menu() {
 
    item = new string[100];
 
    _numberOfItem = 4;
 
    item[0] = "CHOI";
 
    item[1] = "DIEM CAO";
 
    item[2] = "HUONG DAN";
 
    item[3] = "THOAT";
}
void Menu::printMenu() {
 
    for (int i = 0; i < _numberOfItem; i++) {
 
        gotoxy(3, i);
 
        cout << item[i];
 
        Sleep(100); //T?m d?ng 100ms
 
    }
}
void Menu::deleteMenu() {
 
    for (int i = 0; i < _numberOfItem; i++) {
 
        Sleep(100);
 
        gotoxy(0, i);
 
        for (int j = 0; j < item[i].size() + 3; j++) {
 
            cout << " "; //X�a bang c�ch ghi d� k� tu trong
 
        }
   }
}
int main()
{
 
    Menu menu;
    int x;
    int line = 0; //Vi tr� d�ng cua menu
    bool thoat = false;
    menu.printMenu();
    gotoxy(0, line);
    cout << (char) 1; //Vi con tro tri tri menu
    while (!thoat) {
 
        if (kbhit()) {
 
            x = move();
 
            gotoxy(0, line);
            cout << " "; //X�a con tr? ? v? tr� cu
 
            switch (x) {
 
                case 1:
 
                case 3:
                    {
 
                        line++;
 
                        if (line >= menu.numberOfItem()) line = 0;
 
                        break;
 
                    }
 
                case 2:
 
                case 4:
                    {
 
                        line--;
 
                        if (line < 0) line = menu.numberOfItem() - 1;
 
                        break;
 
                    }
 
                case 5:
                    {
 
                        gotoxy(0, 10);
                        cout << "                                           ";
 
                        gotoxy(0, 10);
                        cout << "Ban chon " << menu.getItem()[line];
                        break;
                    }
                case 8:
                thoat = true;
            }
            gotoxy(0, line);
            cout << (char) 1;
        }
    }
    menu.deleteMenu();
    return 0;
}
