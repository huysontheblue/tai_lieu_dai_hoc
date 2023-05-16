<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Trang đăng ký</title>
    </head>
    <body>
        <fieldset>
        <legend><h2>Đăng ký thành viên mới</h2></legend>
        <form action="register.php" method="POST">
            <table align="center">
                <tr>
                    <td>
                        Tài khoản: 
                    </td>
                    <td>
                        <input type="text" name="txtUsername" size="50" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Mật khẩu:
                    </td>
                    <td>
                        <input type="password" name="txtPassword" size="50" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Nhập lại mật khẩu:
                    </td>
                    <td>
                        <input type="password" name="txtPassword" size="50" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:
                    </td>
                    <td>
                        <input type="text" name="txtEmail" size="50" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Tên hiển thị:
                    </td>
                    <td>
                        <input type="text" name="txtName" size="50" />
                    </td>
                </tr>

                <tr>
				    <td colspan="2" align="center">
                        <input type="submit" name="btn_register" value="Đăng ký">
                    </td>
			    </tr> 
            </table>   
        </form>

        <a href="login.php">Click to Login </a>
        </fieldset>

        <?php
        
		    
		    if (isset($_POST["btn_register"])) {
                $username = $_POST["txtUsername"];
                $password = $_POST["txtPassword"];
                $password=md5($password);
                $email = $_POST["txtEmail"];
                $name = $_POST["txtName"];

            include("connect.php");
  			
			    if ($username == "" || $password == "" || $name == "" || $email == "") {
				   echo "bạn vui lòng nhập đầy đủ thông tin";
                }else{

  					$sql="select * from user where Username='$username'";
					$result=mysqli_query($conn, $sql);

					if(mysqli_num_rows($result)  > 0){
						echo "Tài khoản đã tồn tại";
					}else{

	    				$sql = "insert into user (Username, Password, Email, Name) 
                            VALUES ('".$username."', '".$password."','".$email."', '".$name."')";

   						mysqli_query($conn,$sql);
				   		echo "chúc mừng bạn đã đăng ký thành công";
					}	
			    }
	        }
	    ?>
    </body>
</html>