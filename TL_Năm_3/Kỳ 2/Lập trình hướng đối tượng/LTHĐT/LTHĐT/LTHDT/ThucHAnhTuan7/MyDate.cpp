#include <iostream>
#include <string>
#include <fstream>
#include <iomanip>
using namespace std;
class DATE
{
    protected:
        int d;
        int m;
        int y;
    public:
        DATE(int day, int month, int year)
        :d(day),m(month),y(year)
        {}
        DATE()
        {
            d = 1;
            m = 1;
            y = 1990;
        }
        DATE(DATE &a)
        {
            d = a.d;
            m = a.m;
            y = a.y;
        }
        int getDate()
        {
            return d;
        }
        int getMonth()
        {
            return m;
        }
        int getYear()
        {
            return y;
        }
        void dispDate()
        {
            cout << d << '-' << m <<'-' << y << setfill(' ') << setw(5);
        }
        ~DATE()
        {}
        bool operator > (DATE &a)
        {
            if(this-> y > a.y)
            {
                return true;
            }
            if((this->y == a.y) && (this->m > a.m))
            {
                return true;
            }
            if ((this->y == a.y) && (this->m > a.m) && (this->d > a.d))
            {
                return true;
            }
            return false;
        }
};
class Person : public DATE 
{
    protected:
        string name;
        string address;
        string phone;
    public:
        Person(): DATE()
        {
            name = "chua co";
            address = "chua co";
            phone = "chua co";
        }
        Person(int d, int m,int y, string name,string address, string phone):DATE(d,m,y)
        {
            this->name = name;
            this->address = address;
            this->phone = phone;
        }
        Person(Person &a):DATE((DATE &) a)
        {
            this->name = a.name;
            this->address = a.address;
            this->phone = a.phone;
        }
        string getName()
        {
            return name;
        }
        string getAddress()
        {
            return address;
        }
        string getPhone()
        {
            return phone;
        }
        void dispPerson()
        {
            DATE::dispDate();
            cout <<setfill(' ') << setw(20) << name << setfill(' ') << setw(23) << address << setw(5) << 
            setfill(' ') << setw(10) << phone;
        }
};
class Office : public Person
{
    protected:
        float salary;
    public:
        Office():Person()
        {
            salary = 0;
        }
        Office(int d, int m, int y, string name, string address, string phone,float salary):Person(d,m,y,name,address,phone)
        {
            this->salary = salary;
        }
        Office(Office &a):Person((Person &) a)
        {
            salary = a.salary;
        }
        float getSalary()
        {
            return salary;
        }
        void dispOfficer()
        {
            Person::dispPerson();
            cout << setfill(' ') << setw(5) << salary << endl;
        }
        bool operator > (Office &a)
        {
            DATE::operator>(a);
        }
};

int main()
{
   
    Office *listOffice;
    listOffice = new Office[4];
    ifstream inFile("xuatthongtin.txt");
    int count =0 ;
    while(!inFile.eof())
    {
        int day,month,year;
        string name,address,phone;
        float salary;
        inFile>>day>>month>>year;
        inFile.ignore(256,'\n');
        getline(inFile,name);
        getline(inFile,address);
        getline(inFile,phone);
        inFile >> salary;
        Office a(day,month,year,name,address,phone,salary);
        listOffice[count] = a;
        ++count;
        if (count == 4 )
        {
            break;
        }
    }

    inFile.close();
    cout << setfill('-') << setw(41) << "Hien thi thong tin nao may cung"<< setfill('-')<<setw(10) << '\n';
    for (int i = 0 ; i < 4 ; i++)
    {
        listOffice[i].dispOfficer();
    }
    cout << setfill('-') << setw(25) << "Sau khi sap xep"<< setfill('-')<<setw(20) << '\n';

    for (int i = 0; i < 4 ; i++)
    {
        for (int j = 0; j < 4-1-1; j++)
        {
            if (listOffice[j] > listOffice[j+1])
            {
                Office a = listOffice[j];
                listOffice[j] = listOffice[j+1];
                listOffice[j+1] = a;
            }
        }
    }
    for (int i = 0 ; i < 4 ; i++)
    {
        listOffice[i].dispOfficer();
    }
    // write to file , ngay mai co gang chuyen thanh ham
    ofstream outFile;
    int count_2 = 0;
  
    outFile.open("output.txt");
    outFile << setfill('-') << setw(41) << "Hien thi thong tin nao may cung"<< setfill('-')<<setw(10) << '\n';
    outFile << setfill(' ') << setw(5) << "D/M/Y" << setfill(' ') << setw(20) << "Name" << setfill(' ')
    << setw(26) << "Address" << setfill(' ') << setw(10) << "Phone" << setfill(' ') << setw(10) << "Salary" << "\n";
    while(count_2 < 4)
    {
        outFile << listOffice[count_2].getDate() << '-' << listOffice[count_2].getMonth() <<'-' << listOffice[count_2].getYear() << setfill(' ') << setw(5);
        outFile << setfill(' ') << setw(20) << listOffice[count_2].getName() << setfill(' ') << setw(23) << listOffice[count_2].getAddress() << setw(5) << 
        setfill(' ') << setw(10) << listOffice[count_2].getPhone();
        outFile << setfill(' ') << setw(10) << listOffice[count_2].getSalary() << '\n';
        count_2 = count_2 + 1;
    }
    outFile.close();
    

    return 0;

    
}   
