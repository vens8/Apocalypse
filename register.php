<?php

$con = mysqli_connect('localhost', 'root', 'root', 'login');

//check that connection occurred

if(mysqli_connect_errno())
{
	echo "1: Connection Failed"; //error #1 = connection failed.
	exit();
}

$username = $_POST["username"];
$password = $_POST["password"];

//check if username already exists

$namecheckquery = "SELECT Username FROM Players WHERE Username='" . $username . "';";

$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name Check Query Failed"); //error code #2 = name check query failed.

if (mysqli_num_rows($namecheck)>0)
{
	echo "3: Username already exists";
	exit(); //error code #3 = username exists
}

//add user to the table

$Salt = "\$5\$rounds=5000\$" . "secured" . $username . "\$"; //creation of salt to create a secure password. "secured" can hold any string. Can use more secure ways of randomizing.

$Hash = crypt($password, $Salt); //creation of hash. Not the most secure form.

$insertuserquery = "INSERT INTO Players (Username, Hash, Salt) VALUES ('" . $username . "', '" . $Hash . "', '" . $Salt . "');";

mysqli_query($con, $insertuserquery) or die("4: Insert Players Query Failed"); //Error code #4 = insert query failed.

echo("0");

?>