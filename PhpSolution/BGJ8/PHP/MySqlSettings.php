<?php

	class MySqlSettings{
		
		public $Server;
		public $User;
		public $Password;
		public $Database;
		
		public function __construct(){
			$this->Server = 'localhost';
			$this->Password = 'Test';
			$this->User = 'silveryard_BGJ8';
			$this->Database = 'silveryard_BGJ8';
		}
		
	}

?>