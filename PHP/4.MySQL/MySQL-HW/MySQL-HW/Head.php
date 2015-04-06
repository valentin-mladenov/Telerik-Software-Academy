<?php

session_name('login');
if(session_status() == PHP_SESSION_NONE){
    session_start();
}

$connection = mysqli_connect('localhost','hudsonvsm','Valentin', 'messages');

if (!array_key_exists('isLogged',$_SESSION))
{
	$_SESSION['isLogged'] = false;
}

echo '<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta charset="UTF-8" />
</head>
<body>';

?>