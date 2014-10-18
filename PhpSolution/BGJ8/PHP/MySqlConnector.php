<?php

	include_once __DIR__."/MySqlSettings.php";
	
	class MySqlConnector{
		
		private static $_instance;
		
		public static function GetInstance(MySqlSettings $settings){
			if(!isset(MySqlConnector::$_instance))
				MySqlConnector::$_instance = new MySqlConnector($settings);
			
			return MySqlConnector::$_instance;
		}
		
		private $_connection;
		
		function __construct(MySqlSettings $settings){
			$this->_connection = mysql_connect($settings->Server, $settings->User, $settings->Password) or die("Connection Error");
			mysql_select_db($settings->Database) or die ("Selection Error");
		}
		
		function __destruct(){
			mysql_close($this->_connection);
		}
		
		public function AddHighScore($user, $score){
			if($this->GetUser($user)){
				if($this->IsHigher($user, $score)){
					$query = "UPDATE Scores SET Score = '".$score."' WHERE User = '".$user."'";
					$result = mysql_query($query);
					if(!$result)
						echo "Update Error";
				}		
			}else{
				$query = "INSERT INTO Scores (User, Score) VALUES ('".$user."', '".$score."')";
				$result = mysql_query($query);
				if(!$result)
					echo "Insert Error";
			}
		}
		
		public function GetHighScore(){
			$query = "SELECT User, Score FROM Scores ORDER BY Score DESC";
			$result = mysql_query($query);
			
			if(!result)
				echo "HighScoreErrror";
			
			while($row = mysql_fetch_object($result)){
				echo $row->User.': '.$row->Score.' <br>';
			}
		}
		
		private function GetUser($user){
			$query = "SELECT User FROM Scores WHERE User = '".$user."'";
			$result = mysql_query($query);
			
			if(!result)
				echo "Get User Error";
			
			while($row = mysql_fetch_object($result)){
				if($row->User == $user){
					echo "User Found";
					return true;
				}
			}
			
			echo "User Not Found";
			return false;
		}
		
		private function IsHigher($user, $score){
			return $this->GetScore($user) < $score;
		}
		
		private function GetScore($user){
			$query = "SELECT User, Score FROM Scores WHERE User = '".$user."'";
			$result = mysql_query($query);
			
			if(!$result)
				echo "Get Score Error";
			
			while($row = mysql_fetch_object($result)){
				if($row->User == User){
					echo "Score: ".$row->Score;
					return $row->Score;
				}
			}
		}
	}

?>