<?php

$con = mysqli_connect('localhost', 'root','root','login');

 //check if username exist

 if(mysqli_connect_error())
 {
   echo "1: Connection Failed.";//error #1 = connection failed.
   exit();
 }

 $username = $_POST["username"];
 $password = $_POST["password"];

 //check if username exists

$namecheckquery = "SELECT Username, Hash, Salt, Medic, Infected FROM Players WHERE Username='".$username."';";
$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name Check Query Failed");//Error code #2 = name check query failed.

 if(mysqli_num_rows($namecheck) != 1)
 {
   echo "5: Either no user with this name, or more than one"; //Error code #5 = number of names matching is not 1
 }

 //get login info from query

 $existinginfo = mysqli_fetch_assoc($namecheck);
 $Salt=$existinginfo["Salt"];
 $Hash=$existinginfo["Hash"];

 $loginhash = crypt($password, $Salt);
 if($Hash!=$loginhash)
 {
  echo "6: Incorrect Password.";//Error code #6 = password doesn't hash to match table.
  exit();
 }

 echo ("0\t" . $existinginfo["Medic"] . "\t" . $existinginfo["Infected"]);


?>