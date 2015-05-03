<?php

session_name('Register');
if(session_status() == PHP_SESSION_NONE){
    session_start();
}

echo '<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="Script/Send-And-Recieve.js"></script>
    <meta charset="UTF-8" />
</head>
<body>';

