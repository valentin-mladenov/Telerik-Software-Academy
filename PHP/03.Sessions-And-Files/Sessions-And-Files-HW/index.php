<?php
require 'Head.php';

if ($_POST && array_key_exists('pass', $_POST) && array_key_exists('user', $_POST))
{
	$pass = $_POST['pass'];
    $user = $_POST['user'];
    $result = file('users.txt');
    $badUser = true;
    
    foreach ($result as $value){
        $users = explode('!',$value);
        $currUser = trim($users[0]);
        $badUser = true;
        
        echo $user.' '.$currUser.'!';
        
        $userResult = strcmp($user, $currUser);
        
    	if (strcmp($user, $currUser)!==0){
            $badUser = false;
        }
        
        $trimedPass = trim($users[1],"\r\n");
        echo $pass.' '.$trimedPass.'!';
        
        $passRezult = strcmp($pass, $trimedPass);
        
        if (strcmp($user, $currUser)  === 0 && strcmp($pass, $trimedPass) === 0){
    	    echo '<p>Loged in</p>';
            $_SESSION['isLogged'] = true;
            $_SESSION['user'] = $currUser;
            break;
        }
    }
    
    if ($badUser)
    {
    	echo '<p>Bad Username or Password</p>';
    }
}

if (!$_SESSION['isLogged'])
{
    echo '<form method="post">
    <div>
        Username:<input type="text" name="user" placeholder="username" />
    </div>
    <div>
        Password: <input type="password" name="pass" placeholder="password" />
    </div>
    <input type="submit" value="LogIn" />
</form>';
}
    
if ($_SESSION['isLogged']){
    echo '<a href="upload.php">Upload</a>
        <a href="files.php">Files</a>';        
        
    require 'logOut.php';
}
    
require 'Footer.php';
?>