<?php
/**
 * Created by PhpStorm.
 * User: yazda_000
 * Date: 28/05/16
 * Time: 13:28
 */
class dbConnect{
    public function getConnection()
    {
        $dbHost = "localhost";
        $dbUser = "root";
        $dbPass = "";
        $dbName = "insidedb";
        //Create Connection object
        $connection = new mysqli($dbHost, $dbUser, $dbPass, $dbName);
        return $connection;
    }
}

?>