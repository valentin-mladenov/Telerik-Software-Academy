<?php 
require 'Head.php';

if ($_SESSION['isLogged']){
    $dir = scandir('.'.DIRECTORY_SEPARATOR.'files'.DIRECTORY_SEPARATOR.$_SESSION['user']);
    
    echo '<a href="upload.php">Upload</a>
        <a href="index.php">Home</a>';   
    
    echo '<div>';
    foreach ($dir as $key => $value)
    {
        if ($value === '.' || $value === '..')
        {
        	continue;
        }
      
        $file = 'files'.DIRECTORY_SEPARATOR.$_SESSION['user'].DIRECTORY_SEPARATOR.$value;
    	echo '<a href="'.$file.' ">'.$value.' - '.filesize($file).' bytes.</a></br>';
    }
    
    echo '</div>';

    require 'logOut.php';
}

require 'Footer.php';
?>
