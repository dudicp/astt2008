#include <iostream>
#include <fstream>
//#include <winsock.h>
#include <windows.h>

//using namespace std;

static const int DCIP_OK = 0;
static const int DCIP_FAIL = -1;
static const int DCIP_DIR_NOT_FOUND = -2;
static const int DCIP_FILE_NOT_FOUND = -3;
static const int DCIP_UNAUTHORIZE_ACCESS = -4;


static void Usage() {
	std::cout << "\nUsage: DChangeIP.exe <computer_name> <shared_name> \n\t\t\t<username> <password> <end-station id>\n" << std::endl;
    std::cout << " <computer_name>\tThe name of the computer holds the shared folder\n\t\t\t(can be also IP address)." << std::endl;
    std::cout << " <shared_name>\t\tThe shared folder name on the computer name,\n\t\t\tthis is the path to write the new IP address." << std::endl;
    std::cout << " <username>\t\tThe username for the computer_name." << std::endl;
    std::cout << " <password>\t\tThe password for the computer_name." << std::endl;
    std::cout << " <end-station id>\tThe ID of the end-station in the AST database." << std::endl;
    std::cout << "\n\n This command will release the current IP and renew it,\n if success it will write the new IP in \\\\<shared_folder>\\<end-station id> \n otherwise, it will return a non-positive error code." << std::endl;
}

static int RunProcess(std::string& command, const std::string& arguments){
	int errorCode = 0;

	STARTUPINFO si;
	PROCESS_INFORMATION pi;

	ZeroMemory(&si, sizeof(si));
	si.cb = sizeof(si);
	ZeroMemory(&pi, sizeof(pi));

	std::string commandStr(command);
	commandStr.append(" ");
	commandStr.append(arguments);
	char* commandChar = new char[commandStr.length()+1];
	strncpy(commandChar,commandStr.c_str(),commandStr.length());
	commandChar[commandStr.length()] = '\0';

	if(!CreateProcess(NULL, commandChar, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi)){
		std::cout << "Could not start process, error code: " << GetLastError() << std::endl;
		return DCIP_FAIL;
	}

	// Wait until child processes exit.
	WaitForSingleObject( pi.hProcess, INFINITE );

	// Check exit code
	DWORD dwExitCode = 0;
	
	GetExitCodeProcess(pi.hProcess, &dwExitCode);

	// Close process and thread handles.
	CloseHandle( pi.hProcess );
	CloseHandle( pi.hThread );

	errorCode = dwExitCode;

	return errorCode;
}

static int GetCurrentIPAddress(std::string& ip){

	int errorCode = 0;

	SECURITY_ATTRIBUTES saAttr;
	saAttr.bInheritHandle = TRUE;
	saAttr.nLength = sizeof(SECURITY_ATTRIBUTES);
	saAttr.lpSecurityDescriptor = NULL;

	HANDLE pipe_stdin_read, pipe_stdin_write;
	HANDLE pipe_stdout_read, pipe_stdout_write;
	HANDLE pipe_stderr_read, pipe_stderr_write;
	int result; /* CreateProcess() return value and other use(s) */
	STARTUPINFO startup;
	PROCESS_INFORMATION process;
	/* create the pipes for the standard I/O handles */
	result = 1; /* error indicator */
	pipe_stdin_read = pipe_stdin_write = INVALID_HANDLE_VALUE;
	pipe_stdout_read = pipe_stdout_write = INVALID_HANDLE_VALUE;
	pipe_stderr_read = pipe_stderr_write = INVALID_HANDLE_VALUE;
	/* standard in (stdin) */
	if (CreatePipe(&pipe_stdin_read, &pipe_stdin_write, &saAttr, 0))
		/* standard output (stdout) */
		if (CreatePipe(&pipe_stdout_read, &pipe_stdout_write, &saAttr, 0))
			/* standard error (stderr) */
			if (CreatePipe(&pipe_stderr_read, &pipe_stderr_write, &saAttr, 0))
				result = 0;
	if (result) { /* not all pipes were created */
		CloseHandle(pipe_stdin_read);
		CloseHandle(pipe_stdin_write);
		CloseHandle(pipe_stdout_read);
		CloseHandle(pipe_stdout_write);
		CloseHandle(pipe_stderr_read);
		CloseHandle(pipe_stderr_write);
		return DCIP_FAIL;
	}

	/* initialize the STARTUPINFO structure */
	memset(&startup, 0, sizeof(STARTUPINFO));
	startup.cb = sizeof(STARTUPINFO);
	startup.dwFlags = STARTF_USESTDHANDLES;
	startup.hStdInput = pipe_stdin_read;
	startup.hStdOutput = pipe_stdout_write;
	startup.hStdError = pipe_stderr_write;

	try{
		result = CreateProcess( NULL,
								"ipconfig", /* command line */
								&saAttr, &saAttr, /* process, thread attributes */
								TRUE, /* inherit (standard) handles */
								DETACHED_PROCESS | CREATE_SUSPENDED,
								NULL,
								".", 
								&startup, &process);

		if (result == 0) { /* process creation failed */
			CloseHandle(pipe_stdin_read);
			CloseHandle(pipe_stdin_write);
			CloseHandle(pipe_stdout_read);
			CloseHandle(pipe_stdout_write);
			CloseHandle(pipe_stderr_read);
			CloseHandle(pipe_stderr_write);
			return DCIP_FAIL;
		}

		CloseHandle(pipe_stdin_read);
		CloseHandle(pipe_stdout_write);
		CloseHandle(pipe_stderr_write);

		ResumeThread(process.hThread);
		/* these handles aren't needed anymore by the parent process, and they
		have to be closed now or else the threads will continue trying to
		access the pipes */
	}
	// process creation failed.
	catch(...){
		return DCIP_FAIL;
	}

	DWORD dwRead;
	char* buff1 = new char[128];
	std::string content;

	while ( ReadFile ( pipe_stdout_read, buff1, 128, &dwRead, NULL) && dwRead != 0 ){
		buff1[dwRead] = '\0';
		content.append(buff1);
	}

	int StartIndex = content.find("IPv4");
	if(StartIndex < 0)
		return DCIP_FAIL;

	while(content.at(StartIndex)!=':') StartIndex++;
	int EndIndex = StartIndex;
	while(content.at(EndIndex)!='\n') EndIndex++;
	ip = content.substr(StartIndex+2,EndIndex-StartIndex-1);

	return errorCode;
}

int main(int argc, char* argv[]){
	
	if ((argc < 4)||(argc > 6)) {
		Usage();
		return DCIP_FAIL;
	}
	else if (argc == 5) {
		std::cout << "you can't enter username without password.\n" << std::endl;
		return DCIP_FAIL;
	}

	std::string computerName(argv[1]);
	std::string shardFolderName(argv[2]);
	std::string endStationID(argv[3]);
	std::string username = "";
	std::string password = "";
	std::string account = "";

	//in-case we selected the optional username and password parameters.
	if (argc == 6) {
		username = argv[3];
		password = argv[4];
		endStationID = argv[5];
		account = "/user:";
		account.append(username);
		account.append(" ");
		account.append(password);
	}

	//Fixing the slash problem - removing the last slash
	if ((shardFolderName.at(shardFolderName.length() - 1) == '\\') ||
		(shardFolderName.at(shardFolderName.length() - 1) == '/')) {

			shardFolderName = shardFolderName.substr(0,shardFolderName.length() - 1);
	}

	//1. First we try to get access to the shared folder.
    int errorCode = 0;
	std::string command = "net";
    std::string arguments = "use \\\\";
	arguments.append(computerName);
	arguments.append("\\");
	arguments.append(shardFolderName);
	arguments.append(" ");
	arguments.append(account);

	errorCode = RunProcess(command,arguments);

	if (errorCode != 0) {
		std::cout << "Could not get access to the shared folder, error code: " << errorCode << std::endl;
        return DCIP_FAIL;
    }

	//2. Second we try to open a file in the shared folder.
	std::string filename("\\\\");
	filename.append(computerName);
	filename.append("\\");
	filename.append(shardFolderName);
	filename.append("\\");
	filename.append(endStationID);
	filename.append(".txt");

	std::ofstream fileOutput;
	fileOutput.open(filename.c_str(),std::ios::out | std::ios::trunc);


	//3. Execute the 'ipconfig /release' shell command.
	errorCode = 0;
	command = "ipconfig";
    arguments = "/release";

	errorCode = RunProcess(command,arguments);

	if (errorCode != 0) {
		std::cout << "Could not release the current IP, error code: " << errorCode << std::endl;
		fileOutput << DCIP_FAIL << ": release the current IP, error code: " << errorCode << std::endl;
		fileOutput.close();
        return DCIP_FAIL;
    }

	//4. Execute the 'ipconfig /renew' shell command.
	errorCode = 0;
	command = "ipconfig";
    arguments = "/renew";

	errorCode = RunProcess(command,arguments);

	if (errorCode != 0) {
		//write error to the file
		fileOutput << DCIP_FAIL << ": Could not renew IP, error code: " << errorCode << std::endl;
		fileOutput.close();
		std::cout << "Could not renew IP, error code: " << errorCode << std::endl;
        return DCIP_FAIL;
    }

	//5. Writing the new IP address to the file.
	std::string ip = "";
	errorCode = GetCurrentIPAddress(ip);
	if (errorCode != 0) {
		//write error to the file
		fileOutput << DCIP_FAIL << ": Could not get the new IP address." << std::endl;
		fileOutput.close();
		std::cout << "Could not get the new IP address." << std::endl;
        return DCIP_FAIL;
    }
	fileOutput << ip.c_str() << std::endl;
	fileOutput.flush();
	fileOutput.close();
	
	//6. Closing the connection to the shared folder.
	errorCode = 0;
	command = "net";
	arguments = "use \\\\";
	arguments.append(computerName);
	arguments.append("\\");
	arguments.append(shardFolderName);
	arguments.append(" /delete");

	errorCode = RunProcess(command,arguments);

	if (errorCode != 0) {
		std::cout << "Could not end the connection to the shared folder, error code: " << errorCode << std::endl;
        return DCIP_FAIL;
    }

	std::cout << "\n\nDynamic IP address was successfuly changed." << std::endl;

	return DCIP_OK;
}
