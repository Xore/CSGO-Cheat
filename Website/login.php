<?php

	include('config.php');
	error_reporting(E_STRICT);
	
	if(!$_GET['username'] || !$_GET['password'] || !$_GET['hwid']){
				Die('invalid');
	}
	
	$get_username = htmlspecialchars($_GET['username']);
	$get_password = htmlspecialchars($_GET['password']);
	$get_hwid = htmlspecialchars($_GET['hwid']);
	
	function sha512($str, $salt, $iterations){
		for ($x=0; $x<$iterations; $x++) {
			$str = hash('sha512', $str . $salt);
			}
		return $str;
	}
	
	try {
		$pdo = new PDO('mysql:host='.MYSQL_HOST.';dbname='.MYSQL_DTBS.'', ''.MYSQL_USER.'', ''.MYSQL_PSSWD.'');
		$statement = $pdo->prepare('SELECT username, password, publickey
								FROM users
								WHERE username = ? AND password = ?');
		$statement->execute(array($get_username, $get_password)); 
		$publickey = $statement->fetchColumn(2);
		$getCount = $statement->rowCount();

		
		if($getCount == 0){
			
				echo 'invalid';
			
			}else{
				echo 'isvalid ';
				echo $publickey;
			}
				$pdo = null;
				die();
	}catch(PDOException $e){
		print "PDO ERROR: " . $e->getMessage() . "<br/>";
		die();
	}
?>