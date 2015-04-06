<?php
echo '<form method="post" action="index.php">
        <input type="submit" name="LogOut" value="LogOut" />
        </form>';

if ($_POST)
{
    if (array_key_exists('LogOut', $_POST))
    {
        $_SESSION['isLogged'] = false;
        
        session_destroy();
        header("location:/index.php");
        exit();
    }
}
?>