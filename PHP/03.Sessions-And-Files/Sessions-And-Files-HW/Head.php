<?php
session_name('login');
session_start();
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