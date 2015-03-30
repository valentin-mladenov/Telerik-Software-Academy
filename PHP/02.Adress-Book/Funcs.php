<?php
for ($i = 0; $i < $length; $i++){
    if ($i == $length - 1){
        $trimed = trim($colums[$i],"\r\n");
        echo '<td>'.$types[$trimed].'</td>';
    }
    else if ($i == $length - 2){
        $total +=  $colums[$i];
        echo '<td>'.number_format($colums[$i], 2).'</td>';
    }
    else{
        echo '<td>'.$colums[$i].'</td>';
    }
}
?>