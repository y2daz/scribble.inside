<?php
/**
 * Created by PhpStorm.
 * User: yazda_000
 * Date: 28/05/16
 * Time: 15:58
 */

require_once("dbConnect.php");

class Location{

    public $LocationId = NULL;
    public $PrecedingLocation = NULL;
    public $ModelId = NULL;
    public $Name = NULL;
    public $Type = NULL;
    public $Description = NULL;
    public $Tags = NULL;
    public $PositionX = NULL;
    public $PositionY = NULL;
    public $PositionZ = NULL;
    public $RotationX = NULL;
    public $RotationY = NULL;
    public $RotationZ = NULL;
    public $ScaleX = NULL;
    public $ScaleY = NULL;
    public $ScaleZ = NULL;

    public function getJSONObject( $locationArray ){

        if( !isset($locationArray[0]) )
            return;
//        echo "Yaz";
//        var_dump($locationArray);

//        echo "<pre>";
        echo "[\n";
        for($i = 0; $i < count($locationArray); $i++)
        {
            echo "{\n";
            echo "\"locationid\" : \"" . $locationArray[$i]->LocationId . "\",\n";
            echo "\"precedinglocation\" : \"" . $locationArray[$i]->PrecedingLocation . "\",\n";
            echo "\"modelid\" : \"" . $locationArray[$i]->ModelId . "\",\n";
            echo "\"name\" : \"" . $locationArray[$i]->Name . "\",\n";
            echo "\"type\" : \"" . $locationArray[$i]->Type . "\",\n";
            echo "\"description\" : \"" . $locationArray[$i]->Description . "\",\n";
            echo "\"tags\" : \"" . $locationArray[$i]->Tags . "\",\n";
            echo "\"positionx\" : \"" . $locationArray[$i]->PositionX . "\",\n";
            echo "\"positiony\" : \"" . $locationArray[$i]->PositionY . "\",\n";
            echo "\"positionz\" : \"" . $locationArray[$i]->PositionZ . "\",\n";
            echo "\"rotationx\" : \"" . $locationArray[$i]->RotationX . "\",\n";
            echo "\"rotationy\" : \"" . $locationArray[$i]->RotationY . "\",\n";
            echo "\"rotationz\" : \"" . $locationArray[$i]->RotationZ . "\",\n";
            echo "\"scalex\" : \"" . $locationArray[$i]->ScaleX . "\",\n";
            echo "\"scaley\" : \"" . $locationArray[$i]->ScaleY . "\",\n";
            echo "\"scalez\" : \"" . $locationArray[$i]->ScaleZ . "\"";

            if($i == count($locationArray) - 1)
            {
                echo "\n}\n";
            }
            else{
                echo "\n},\n";
            }
        }
        echo "\n]22";
//        echo "</pre>";
    }

    public function getNoOfTagsFromTagCode($tagCode)
    {
        $dbObj = new dbConnect();
        $mysqli = $dbObj->getConnection();

        $count = 0;

        if( !isset($tagCode))
            return 0;

        if ($mysqli->connect_errno) {
            die ("Failed to connect to MySQL: " . $mysqli->connect_error );
        }

        if ($stmt = $mysqli->prepare("SELECT Count(*) FROM `tbllocation` WHERE `locationid` = ?;"))
        {
            $stmt -> bind_param("s", $tagCode);
            if ($stmt->execute())
            {
//                $loc = new location();

                $stmt->bind_result( $count );
                $stmt->fetch();

                $stmt->close();
                $mysqli->close();
            }
            else{
                echo $mysqli->error;
            }
        }
        return $count;
    }

    public function getAllLocationsFromTagCode( $tagCode )
    {
        if( !isset($tagCode))
            return 0;

        $dbObj = new dbConnect();
        $mysqli = $dbObj->getConnection();
        if ($mysqli->connect_errno) {
            die ("Failed to connect to MySQL: " . $mysqli->connect_error );
        }

        if ($stmt = $mysqli->prepare(
            "SELECT `locationid`, `modelid`, `PrecedingLocation`, `Name`, `Type`, `Description`, `Tags`, `PositionX`, `PositionY`,
            `PositionZ`, `RotationX`, `RotationY`, `RotationZ`, `ScaleX`, `ScaleY`, `ScaleZ`
            FROM `tbllocation`
            WHERE `modelid` = (SELECT `modelid` FROM `tbllocation` WHERE `locationid` = ?);"))
        {
            $stmt -> bind_param("s", $tagCode);
            if ($stmt->execute())
            {
                $result = $stmt->get_result();
                $locations = array();
                $count = count($result);

                $i = 0;
                while($row = $result->fetch_array())
                {
                    $locations[$i] = new Location();
                    $locations[$i]->LocationId = $row[0];
                    $locations[$i]->ModelId = $row[1];
                    $locations[$i]->PrecedingLocation = $row[2];
                    $locations[$i]->Name = $row[3];
                    $locations[$i]->Type = $row[4];
                    $locations[$i]->Description = $row[5];
                    $locations[$i]->Tags = $row[6];
                    $locations[$i]->PositionX = $row[7];
                    $locations[$i]->PositionY = $row[8];
                    $locations[$i]->PositionZ = $row[9];
                    $locations[$i]->RotationX = $row[10];
                    $locations[$i]->RotationY = $row[11];
                    $locations[$i]->RotationZ = $row[12];
                    $locations[$i]->ScaleX = $row[13];
                    $locations[$i]->ScaleY = $row[14];
                    $locations[$i]->ScaleZ = $row[15];

//                    var_dump( $locations[$i] );
                    $i++;
                }

                $this->getJSONObject( $locations );

                $stmt->close();
                $mysqli->close();
            }
            else{
                echo $mysqli->error;
            }
        }
        return 0;
    }

    public function getLocationFromTagCode( $tagCode ) //Deprecated Don't Use
    {
        $dbObj = new dbConnect();
        $mysqli = $dbObj->getConnection();
        if ($mysqli->connect_errno) {
            die ("Failed to connect to MySQL: " . $mysqli->connect_error );
        }

        if ($stmt = $mysqli->prepare(
            "SELECT `locationid`, `modelid`, `PrecedingLocation`, `Name`, `Type`, `Description`, `Tags`, `PositionX`,
            `PositionY`, `PositionZ`, `RotationX`, `RotationY`, `RotationZ`, `ScaleX`, `ScaleY`, `ScaleZ`
            FROM `tbllocation`
            WHERE `modelid` = (SELECT `modelid` FROM `tbllocation` WHERE `locationid` = ?);"))
        {
            $stmt -> bind_param("s", $tagCode);
            if ($stmt->execute())
            {
                $stmt->bind_result( $this->LocationId, $this->ModelId, $this->PrecedingLocation, $this->Name, $this->Type, $this->Description, $this->Tags,
                    $this->PositionX, $this->PositionY, $this->PositionZ, $this->RotationX, $this->RotationY, $this->RotationZ,
                    $this->ScaleX, $this->ScaleY, $this->ScaleZ);
                $stmt->fetch();

                $stmt->close();
                $mysqli->close();
            }
            else{
                echo $mysqli->error;
            }
        }
        return 0;
    }
}