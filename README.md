# SiemensToIgnitionTagConverter
Converts Siemens tags in csv format to Ignition JTAG format

Example Tag CSV:
Name;Path;Data Type;Logical Address;Comment;Hmi Visible;Hmi Accessible;Hmi Writeable;Typeobject ID;Version ID
SR01_MV0;damper;Int;%QW8;;True;True;True;;
TT01_TC_Actmode;PID;Bool;%M2.0;;True;True;True;;
TT01_PID_Mode;PID;Int;%MW200;;True;True;True;;


Example DB CSV
Static;;;;;;;;
LRV;Real;0.0;0.0;FALSE;TRUE;TRUE;TRUE;FALSE
URV;Real;4.0;0.0;FALSE;TRUE;TRUE;TRUE;FALSE
xL;Bool;8.0;FALSE;FALSE;TRUE;TRUE;TRUE;FALSE
