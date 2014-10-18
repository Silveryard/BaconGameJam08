<?php

	include_once __DIR__."/MySqlSettings.php";
	include_once __DIR__."/MySqlConnector.php";
	
	$settings = new MySqlSettings();
	$connector = MySqlConnector::GetInstance($settings);
	
	$connector->GetHighScore();

?>