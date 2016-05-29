<?php
/**
 * Created by PhpStorm.
 * User: yazda_000
 * Date: 28/05/16
 * Time: 13:32
 */

require_once("Location.php");

//test();
$loc = new Location();

//$loc->getLocationFromTagCode('iskdju4585wid71s');
//$loc->getJSONObject();

if( !isset( $_GET["app"] ))
{
    header( "Location: https://play.google.com/store/apps" );
}

if( isset( $_GET["tag"] ) ){
    $loc->getAllLocationsFromTagCode( $_GET["tag"] );
//    echo $loc->getNoOfTagsFromTagCode( $_GET["tag"] );
}
