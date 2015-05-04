<?php

/**
 * AbstractClass short summary.
 *
 * AbstractClass description.
 *
 * @version 1.0
 * @author Хъдсън
 */
class AbstractClass extends User implements Iterator
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
    #region Iterator Members

    /**
     * Return the current element
     * Returns the current element.
     *
     * @return mixed
     */
    function current()
    {
        // TODO: implement the function Iterator::current
    }

    /**
     * Return the key of the current element
     * Returns the key of the current element.
     *
     * @return scalar
     */
    function key()
    {
        // TODO: implement the function Iterator::key
    }

    /**
     * Move forward to next element
     * Moves the current position to the next element.
     *
     * @return void
     */
    function next()
    {
        // TODO: implement the function Iterator::next
    }

    /**
     * Rewind the Iterator to the first element
     * Rewinds back to the first element of the Iterator.
     *
     * @return void
     */
    function rewind()
    {
        // TODO: implement the function Iterator::rewind
    }

    /**
     * Checks if current position is valid
     * This method is called after Iterator::rewind() and Iterator::next() to check if the current position is valid.
     *
     * @return bool
     */
    function valid()
    {
        // TODO: implement the function Iterator::valid
    }

    #endregion
}
