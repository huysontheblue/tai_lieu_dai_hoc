<!DOCTYPE html>
<html>
<head>
  <title>Edit</title>
</head>
<body>

<?php
    include("connect.php");
        $id = $_GET['ID'];
        $sql = "select * from user where ID='$id'";
        $query = mysqli_query($conn, $sql);
        $row = mysqli_fetch_array($query);
    
?>


<fieldset>
<legend><h2>Cập nhật người dùng</h2></legend>
<form method="POST" action="" enctype="multipart/form-data">
    <table align="center">
        <tr>
            <td hidden>ID</td>
            <td><input type="text" value="<?php echo $row['ID']; ?>" name="ID" hidden></td>
        </tr>
        <tr>
            <td>Name</td>
            <td><input type="text" value="<?php echo $row['Name']; ?>" name="Name"></td>
        </tr>
        <tr>
            <td>Username</td>
            <td><input type="text" value="<?php echo $row['Username']; ?>" name="Username"></td>
        </tr>
        <tr>
            <td>Email</td>
            <td></label><input type="text" value="<?php echo $row['Email']; ?>" name="Email"></td>
        </tr>
        <tr>
            <td>Phone</td>
            <td><input type="text" value="<?php echo $row['Phone']; ?>" name="Phone"></td>
        </tr>
        <tr>
            <td>Avatar</td>
            <td>
                <img src="photo/<?php echo $row['Avatar']; ?>" style="width:100px; height:100px">
                <input type="file" name="image">
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center"><input type="submit" name="edit" value="Cập nhật"></td>
        </tr>
    </table>
</form>
</fieldset>
</body>
</html>


<?php

    if(isset($_POST['edit'])) 
    {
        $id = $_POST['ID'];
        $name = $_POST['Name'];
        $username = $_POST['Username'];
        $email = $_POST['Email'];
        $phone = $_POST['Phone'];
        
        if(isset($_FILES['image']['name']) && ($_FILES['image']['name'] != "")) {

  	        $image = $_FILES['image']['name'];

            unlink("photo/$old_image");
            $target = "photo/$image";
            move_uploaded_file($_FILES['image']['tmp_name'], $target);
        }
        else{
            $image = $old_image;
        }

        $sql = "update user set Name='$name', Username='$username', Email='$email', Phone='$phone', Avatar='$image' where ID='$id'";

        if (mysqli_query($conn, $sql) == true) {
            echo "<script>alert('Cập nhật thành công')</script>";
            header("location:view.php"); 
        }else{
            echo "<script>alert('Cập nhật không thành công')</script>";
        }
            
        mysqli_close($conn);
        
    }
?>











    