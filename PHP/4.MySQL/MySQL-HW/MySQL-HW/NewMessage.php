<?php 
require 'Head.php';
require 'Constants.php';

if ($_SESSION['isLogged']){
    $badMessage = false;
    
    if ($_POST)
    {
        $titleLen = strlen($_POST['title']);
        $msgLen = strlen($_POST['message']);
        $message = $_POST['message'];
        
        if (($titleLen <= 0) || ($titleLen > 50)) {
        	echo 'Title lenght invalid! </br>';
            $badMessage = true;
        }
        
        if (($msgLen <= 0) || ($msgLen > 250)) {
        	echo 'Message length invalid!';
            $badMessage = true;
        }
        
        $currUser = $_SESSION['user'];
        $date = date("Y-m-d");
        $groupIndex = $_POST['filter'];
        $groupToSend = $groups[$groupIndex];
        
        if (!$badMessage) {
            $sqlSendMsg = 'INSERT INTO `messages` (`user`, `message`, `date`, `group`) 
                            VALUES ("'.$currUser.'", "'.$message.'", NOW(), "'.$groupToSend.'")';
            $sqlSendResult = mysqli_query($connection, $sqlSendMsg);
            if (!$sqlSendResult){
                echo 'Message not sent.';
            }
            else{
                echo 'Message sent.';
            }
            
        	include 'index.php';
        }
        else {
            echo 'Message not send';
            echo '<form action="" method="post" enctype="multipart/form-data">
	        Title: <input type="text" name="title" />
            Message: <textarea name="message"></textarea>
            <select name="filter">';
            foreach ($groups as $key => $value){
                if ($key==0) {
                    continue;
                }
                echo '<option value="'.$key.'">'.$value.'</option>';
            }
            echo '</select>
	        <input type="submit" name="submit" value="Submit" />
        </form>';
            echo '<a href="index.php">Messages</a>';   
            
            require 'logOut.php';
        }
    }
    else {
        echo '<a href="index.php">Messages</a>';   
        
        echo '<form action="" method="post" enctype="multipart/form-data">
	        Title: <input type="text" name="title" />
            Message: <textarea name="message"></textarea>
            <select name="filter">';
        foreach ($groups as $key => $value){
            if ($key==0) {
                continue;
            }
            echo '<option value="'.$key.'">'.$value.'</option>';
        }
        echo '</select>
	        <input type="submit" name="submit" value="Submit" />
        </form>';
        
        require 'logOut.php';
    }
}

require 'Footer.php';
?>