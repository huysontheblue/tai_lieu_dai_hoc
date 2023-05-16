#include <iostream>
#include <fstream>

int main()
{
	std::ifstream fileInput("D:/TL_Nam_3/Ky_1/CauTrucDuLieu/my_document.txt");

	if (fileInput.fail())
	{
		std::cout << "Failed to open this file!" << std::endl;
		return -1;
	}
while (!fileInput.eof())
{
	char c;
	if(fileInput >> c)
		std::cout << c << " ";
}
std::cout << std::endl;
}
