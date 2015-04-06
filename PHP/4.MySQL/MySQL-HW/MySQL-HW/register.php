<?php
require 'Head.php';

if ($_POST && array_key_exists('regpass', $_POST) && array_key_exists('reguser', $_POST)) {
	$regPass = $_POST['regpass'];
    $regUser = $_POST['reguser'];
    $badUser = false;
    
    $sqlFindUser = 'SELECT *
                        FROM users
                        WHERE user_name="'.$regUser.'"';
    $sqlFingResult = mysqli_query($connection,$sqlFindUser);
    
    if ($sqlFingResult->num_rows != 0) {
        echo 'User allready exists.';
    }
    else {
        $sqlAddUser = 'INSERT INTO `users`(`user_name`, `password`)
                            VALUES ("'.$regUser.'","'.$regPass.'")';
        $sqlAddResult = mysqli_query($connection,$sqlAddUser);

        echo 'Registration done';
        header("location:/index.php");
    }
}

echo '<form method="post">
    <div>
        Username:<input type="text" name="reguser" placeholder="username" />
    </div>
    <div>
        Password: <input type="password" name="regpass" placeholder="password" />
    </div>
    <a href="index.php">Home</a>
    <input type="submit" value="Register" />
</form>';

require 'Footer.php';
?>