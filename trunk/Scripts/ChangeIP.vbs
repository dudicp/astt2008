'=========================
' NAME: ChangeIPAddress.vbs
'
'AUTHOR: Mitch Tulloch
'DATE: October 2006
'ARGUMENTS:
'1. new_IP_address
'=========================-

'Option Explicit
'On Error Resume Next

Dim objWMIService
Dim objNetAdapter
Dim strComputer     ' Can specify IP address or hostname or FQDN
Dim strAddress     'Contains the new IP address
Dim arrIPAddress
Dim arrSubnetMask
Dim colNetAdapters
Dim errEnableStatic

'Check for missing arguments

If WScript.Arguments.Count = 0 Then
     Wscript.StdOut.WriteLine("Usage: ChangeIPAddress.vbs new_IP_address")
     WScript.Quit(-1)
End If

strComputer = "."
strAddress = Wscript.Arguments.Item(0)
arrIPAddress = Array(strAddress)
arrSubnetMask = Array("255.255.255.0")
Set objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")
Set colNetAdapters = objWMIService.ExecQuery("Select * from Win32_NetworkAdapterConfiguration where IPEnabled=TRUE")
For Each objNetAdapter in colNetAdapters
     errEnableStatic = objNetAdapter.EnableStatic(arrIPAddress, arrSubnetMask)


'Display result or error code

If errEnableStatic=0 Then
     Wscript.StdOut.Write("Adapter's IP address has been successfully changed to " & strAddress)
	 WScript.Quit(0)
Else
     Wscript.StdOut.Write("Changing the adapter's address was not successful. Error code " & errEnableStatic)
	 WScript.Quit(errEnableStatic)
End If

Next

