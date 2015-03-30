<?php
mb_internal_encoding('UTF-8');
$pageTitle = 'Subscription';
include 'header.php';
require 'Constants.php';

if ($_POST){
	$name = trim($_POST['name']);
    $name = str_replace('!','',$name);
    $date = trim($_POST['date']);
    $price = trim($_POST['price']);
    $selectGroup = (int)$_POST['group'];
    
    $error = false;
    $result ='';
    
    if (empty($date)){
        $date = date("Y-m-d");
    }
    
    if (mb_strlen($name) < 4){
    	echo '<div>The name is too short.</div>';
        $error = true;
    }
    
    if ($price <= 0){
    	echo '<div>Bad Number.</div>';
        $error = true;
    }
    
    if (!array_key_exists($selectGroup, $types)){
    	echo '<div>Bad groupe.</div>';
        $error = true;
    }
    
    if(!$error){        
        $result = $date.'!'.$name.'!'.$price.'!'.$selectGroup."\r\n";
        if(file_put_contents('data.txt', $result, FILE_APPEND)){
            echo '<div>Write.</div>';
        }
    }
}

// echo '<pre>'.print_r($_POST, true).'</pre>';

?>

<a href="index.php">Expenses</a>
<form method="post">
    <div>
        Date: <input type="date" name="date" />
    </div>
    <div>
        Name:<input type="text" name="name" />
    </div>
    <div>
        Price: <input type="number" step="any" name="price" />
    </div>
    <div>
        Type:<select name="group">
            <?php
                foreach ($types as $key => $value){
                    if ($key == 0)
                    {
                    	continue;
                    }
                    
                    echo '<option value="'.$key.'">'.$value.'</option>';
                }                    
            ?>
        </select>
    </div>
    <div>
        <input type="submit" name="GO" />
    </div>
</form>
<?php
include 'footer.php';
?>