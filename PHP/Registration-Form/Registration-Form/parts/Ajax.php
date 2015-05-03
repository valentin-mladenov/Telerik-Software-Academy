<?php

$connection = mysqli_connect('localhost','root','','registration');

if ($_POST && array_key_exists('regpass', $_POST) 
        && array_key_exists('reguser', $_POST) 
        && array_key_exists('regEmail', $_POST)) {
	$regPass = mysqli_real_escape_string($connection, $_POST['regpass']);
    $regUser = mysqli_real_escape_string($connection, $_POST['reguser']);
    $regEmail = mysqli_real_escape_string($connection, $_POST['regEmail']);
    
    $sqlFindUser = 'SELECT *
                        FROM users
                        WHERE user_name="'.$regUser.'"';
    $sqlFindResult = mysqli_query($connection,$sqlFindUser);
    
    if ($sqlFindResult -> num_rows != 0) {
        echo json_encode('User allready exists.');
    }
    else {
        $sqlAddUser = 'INSERT INTO `users`(`user_name`, `password`, `Email`)
                            VALUES ("'.$regUser.'","'.$regPass.'","'.$regEmail.'")';
        $sqlAddResult = mysqli_query($connection,$sqlAddUser);

        if ($sqlAddResult) {
        	echo json_encode('Registration done');
            include 'Confirmation.php';
        }
        else {
            echo json_encode('Registration failed');
        }
    }
}

