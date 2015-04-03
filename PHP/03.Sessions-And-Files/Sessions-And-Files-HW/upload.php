<?php 
require 'Head.php';
      
if ($_SESSION['isLogged']){
    echo '<a href="files.php">Files</a>
        <a href="index.php">Home</a>';   
    
    echo '<form action="" method="post" enctype="multipart/form-data">
	        Your File: <input type="file" name="file" size="25" />
	        <input type="submit" name="submit" value="Submit" />
        </form>';
    
    if ($_POST)
    {
        $info = pathinfo($_FILES['file']['name']);
        $ext = $info['extension'];
        $filename = $info['filename'];
        $newname = $_SESSION['user']."-".$filename.'.'.$ext;
        
    	$target = "files".DIRECTORY_SEPARATOR.$_SESSION['user'].DIRECTORY_SEPARATOR.$newname;
        //$target = $target.basename( $_FILES['userFile']['name'] );
        move_uploaded_file( $_FILES['file']['tmp_name'], $target );
    }
    
    require 'logOut.php';
}


require 'Footer.php';
?>