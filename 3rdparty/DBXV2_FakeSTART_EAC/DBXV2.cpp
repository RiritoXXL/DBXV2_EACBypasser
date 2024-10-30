#include <BlackBone/Process/Process.h>
#include <Windows.h>
#include <iostream>
#include <filesystem>
#include "termcolor.hpp"
namespace fs = std::filesystem;
using namespace std;
void EACBypass_DBXV2() {
	blackbone::Process process_eac;
	std::wstring xm = fs::current_path();
	std::wstring stringeac = xm;
	NTSTATUS st = process_eac.CreateAndAttach(xm + L"\\bin\\DBXV2.exe");
	if (st) {
		cout << termcolor::color<120, 0, 0> << "Failed to Execute Bypass" << endl;
	}
	else {
		cout << termcolor::color<65, 43, 43> << "Success!!!" << endl;
		Sleep(2100);
		exit(122);
	}
}

int main()
{
	EACBypass_DBXV2();
	return 0;
}