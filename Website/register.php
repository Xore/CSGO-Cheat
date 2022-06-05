<?php

	include('config.php');
	error_reporting(E_STRICT);	
		
	if(!$_POST['username'] || !$_POST['password'] || !$_POST['email']){
		die('Bischt dumm oder wat');
	}	
	
	$post_username = htmlspecialchars($_POST['username']);
	$post_password = htmlspecialchars($_POST['password']);
	$post_email = htmlspecialchars($_POST['email']);
	
	function sha512($str, $salt, $iterations){
		for ($x=0; $x<$iterations; $x++) {
			$str = hash('sha512', $str . $salt);
			}
		return $str;
	}
	
	$crypted_password = sha512($post_password, SHASALT, 1);
	
	try {
		$pdo = new PDO('mysql:host='.MYSQL_HOST.';dbname='.MYSQL_DTBS.'', ''.MYSQL_USER.'', ''.MYSQL_PSSWD.'');
		$statement = $pdo->prepare("INSERT INTO users (username, password, email)
								   VALUES (:username, :password, :email)");
		
		$statement->bindParam(':username', $post_username, PDO::PARAM_STR);		
		$statement->bindParam(':password', $crypted_password, PDO::PARAM_STR);	
		$statement->bindParam(':email', $post_email, PDO::PARAM_STR);
		
		$statement->execute();
		
		
		$pdo = null;
		header("Location: http://REDIRECTURLALLA/index.php?f=register");
		die();
	}catch(PDOException $e){
		print "PDO ERROR: " . $e->getMessage() . "<br/>";
		die();
	}
		
?>