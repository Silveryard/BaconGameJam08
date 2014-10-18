<?php

	include_once __DIR__."/MySqlSettings.php";
	include_once __DIR__."/MySqlConnector.php";
	
	$user = $_POST["User"];
	$score = $_POST["Score"];
	
	$settings = new MySqlSettings();
	$connector = MySqlConnector::GetInstance($settings);
	
	$connector->AddHighScore($user, $score);

?>