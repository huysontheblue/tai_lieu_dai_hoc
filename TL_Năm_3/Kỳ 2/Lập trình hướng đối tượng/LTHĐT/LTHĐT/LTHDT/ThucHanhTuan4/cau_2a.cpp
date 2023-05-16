#include <iostream>
#include <iomanip>
#include <string.h>
using namespace std;
char  month_table[]      = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
char  leap_month_table[] = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
#define IS_LEAP_YEAR(year) ((year%400 == 0) || (year%4 == 0 && year%100 != 0))?   true : false
class CDate
{
private:
    int day;
    int month;
    int year;
public:
    CDate(int d = 0, int m = 0, int y = 0): day(d), month(m), year(y)
    {
    }
    ~CDate()
    {
    }
    void print()
    {
        cout << setfill ('0') << setw(2) << day << "-"
            << setfill ('0') << setw(2) <<month << "-"
            << setfill ('0') << setw(4) << year << endl;
    }
    bool validDate()
    {
        // validate dd/mm/yyyy
        if (year < 1 || year > 9999 ||
            month < 1 || month > 12 ||
            day < 1 || day > 31)
        {
            return false;
        }
 
        if (IS_LEAP_YEAR(year))
        {
            if (day > leap_month_table[month-1])
            {
                return false;
            }
        }
        else
        {
            if (day > month_table[month-1])
            {
                return false;
            }
        }
        return true;
    }
};
 
int main()
{
    CDate date1(01, 01, 1980);
    if (date1.validDate())
    {
        date1.print();
        date1.print();
    }
    else
    {
        cout << "Invalid Date";
    }
     system("pause");
}
