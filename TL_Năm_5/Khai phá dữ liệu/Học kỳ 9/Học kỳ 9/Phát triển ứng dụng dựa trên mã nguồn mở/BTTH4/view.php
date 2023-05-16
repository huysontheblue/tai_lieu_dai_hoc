<!DOCTYPE html>
<html>
<head>
  <title>Display all records from Database</title>
</head>

<style>
    table, tr, td {
        border-collapse: collapse; 
        border: 1px solid black;
    }
</style>
<body>

    <fieldset>
    <legend><h2>Danh sách người dùng</h2></legend>
    <table align="center">
        <tr>
            <td>ID</td>
            <td>Name</td>
            <td>Username</td>
            <td>Email</td>
            <td>Phone</td>
            <td>Avatar</td>
            <td colspan=2>Funtions</td>
        </tr>

        <?php

        include("connect.php"); 

        $values = mysqli_query($conn,"select * from user"); 

        while($row = mysqli_fetch_array($values))
        {
        ?>
        <tr>
            <td><?php echo $row['ID']; ?></td>
            <td><?php echo $row['Name']; ?></td>
            <td><?php echo $row['Username']; ?></td> 
            <td><?php echo $row['Email']; ?></td>
            <td><?php echo $row['Phone']; ?></td>
            <td><img src="photo/<?php echo $row['Avatar']; ?>" style="width:100px; height:100px"> </td>   
            <td><a href="edit.php?ID=<?php echo $row['ID']; ?>">Edit</a></td>
            <td><a href="delete.php?ID=<?php echo $row['ID']; ?>">Delete</a></td>
        </tr>	
        <?php
        }
        ?>
    </table>
    </fieldset>

</body>
</html>