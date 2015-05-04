<?php

/**
 * AbstractClass short summary.
 *
 * AbstractClass description.
 *
 * @version 1.0
 * @author Хъдсън
 */
class ImplementedClass extends AbstractClass implements IAbstractInterface
{
    private $data = array();
    
    public function __construct(){
		
    }
    
    public function __get ($name){
        return $this->data[$name];
    }
    
    public function __set ($name, $value){
        $this->data[$name] = $value;
    }

    public function __destruct (){
        echo 'Quit';
    }
}
