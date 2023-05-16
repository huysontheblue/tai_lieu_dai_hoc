<?php
	$id=$_GET['ID'];
	include("connect.php"); 
    $query = "delete from `user` where ID='$id'";
	mysqli_query($conn, $query);
	header('location:view.php');
?>