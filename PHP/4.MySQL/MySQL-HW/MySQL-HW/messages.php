<?php 
//require 'Head.php';
require 'Constants.php';

if ($_SESSION['isLogged'] == true)
{
    $sqlSelectMSG;
    if ($_POST && array_key_exists('filter', $_POST)){
        $groupIndex = $_POST['filter'];
        $group = $groups[$groupIndex];
    
        if($groupIndex > 0){
            $sqlSelectMSG = 'SELECT * FROM `messages` WHERE `group` = "'.$group.'" ORDER BY `date` DESC';
        }
        else{
            $sqlSelectMSG = 'SELECT * FROM messages ORDER BY `date` DESC';
        }
    }
    else{
        $sqlSelectMSG = 'SELECT * FROM messages ORDER BY `date` DESC';
    }

    $sqlMessages = mysqli_query($connection, $sqlSelectMSG);
    
    if (!$sqlMessages){
	    echo 'ERROR';
    }
    
    if ($sqlMessages -> num_rows > 0){
        echo '<table border="1">
        <thead>
            <tr>
                <th>User</th>
                <th>Date</th>
                <th>Group</th>
                <th>Message</th>
            </tr>
        </thead>
        <tbody>';

	    while($row = $sqlMessages -> fetch_assoc()){  
                echo '<tr>
                    <td>'.$row['user'].'</td>
                    <td>'.$row['date'].'</td>
                    <td>'.$row['group'].'</td>
                    <td>'.$row['message'].'</td>
                </tr>';
    
        }
    
        echo '</tbody></table>';
    }
    
    echo '<a href="NewMessage.php">NEW MESSAGE</a>
        <form method="post">
            <select name="filter">';
                    foreach ($groups as $key => $value){
                        echo '<option value="'.$key.'">'.$value.'</option>';
                    }
            echo '</select>
            <input type="submit"  value="Filter" name="Filter" />
        </form>';
    require 'logOut.php';
}
//else{
//    header("location:/index.php");
//    exit();
//}

//require 'Footer.php';
?>