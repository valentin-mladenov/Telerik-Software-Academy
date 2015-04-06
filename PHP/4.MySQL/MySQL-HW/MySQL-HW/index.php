<?php
require 'Head.php';

if (!$connection) {
	echo 'no database';
    exit;
}

if ($_POST && array_key_exists('pass', $_POST) && array_key_exists('user', $_POST)) {
	$CurrentPass = $_POST['pass'];
    $currentUser = $_POST['user'];
    $badUser = false;
    
    $sqlSelectUser = 'SELECT *
                        FROM users
                        WHERE user_name="'.$currentUser.'"';
    $sqlResult = mysqli_query($connection,$sqlSelectUser);
    
    
    if ($sqlResult->num_rows == 1) {
        $row=$sqlResult->fetch_assoc();
        $userName = $row['user_name'];
        $userPass = $row['password'];
        
        if (strcmp($userName, $currentUser)  === 0 && strcmp($CurrentPass, $userPass) === 0) {
            echo '<p>Loged in</p>';
            $_SESSION['isLogged'] = true;
            $_SESSION['user'] = $currentUser;
        }
        else {
            $badUser = true;
        }
    }
    else {
        $badUser = true;
    }
        
    if($badUser) {
    	echo '<p>Bad Username or Password</p>';
    }
}

if (!$_SESSION['isLogged']) {
    echo '<form method="post">
    <div>
        Username:<input type="text" name="user" placeholder="username" />
    </div>
    <div>
        Password: <input type="password" name="pass" placeholder="password" />
    </div>
    <a href="register.php">Register</a>
    <input type="submit" value="LogIn" />
</form>';
}
    
if ($_SESSION['isLogged']){    
    include 'messages.php';
}
    
require 'Footer.php';
?>