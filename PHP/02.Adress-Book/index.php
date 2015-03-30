<?php
$pageTitle='Home';
include 'header.php';
require 'Constants.php';
mb_internal_encoding('UTF-8');
?>
<a href="subscription.php">New expense!!!</a>
<table border="1">
    <tbody>
        <tr>
            <td>Date</td>
            <td>Name</td>
            <td>Price</td>
            <td>Type</td>
        </tr>
        <?php            
        if ($_POST){
            $selectedGroup = (int)$_POST['filter'];
    
            if (file_exists('data.txt'))
            {
                $result = file('data.txt');
                $total = 0;
                foreach ($result as $value){
                    echo '<tr>';
                    
                    $colums = explode('!',$value);
                    $length = count($colums);
                    if ($selectedGroup == $colums[$length-1]){
                        include 'funcs.php';
                    }
                    else if ($selectedGroup == 0){
                    	include 'funcs.php';
                    }
                    
                    echo '</tr>';
                }
                
                echo '<tr>';
                echo '<td>----</td><td>Total:</td><td>'.$total.'</td><td>----</td>';
                echo '</tr>';
            }
        }
        ?>
    </tbody>
</table>
<form method="post">
    <select name="filter">
        <?php
            foreach ($types as $key => $value){
                echo '<option value="'.$key.'">'.$value.'</option>';
            }
        ?>
    </select>
    <input type="submit"  value="Filter" name="Filter" />
</form>
<?php
include 'footer.php';
?>