<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Trang đăng nhập</title>
    </head>
    <body>
    <fieldset>
        <legend>Đăng nhập</legend>
        <form action="login.php" method="POST">
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
				    <td colspan="2" align="center">
                        <input type="submit" name="btn_login" value="Đăng nhập">
                    </td>
			    </tr>
            </table>
        </form>
    </fieldset>

        <?php
            session_start();
		    if (isset($_POST["btn_login"])) {

                $username = $_POST["txtUsername"];
                
                $password = $_POST["txtPassword"];
                $password=md5($password); 

                include("connect.php");

			    if ($username == "" || $password == "") {
				   echo "bạn vui lòng nhập đầy đủ thông tin";
                   exit;
                }
                else{
                    
  					$sql="select * from user where Username = '$username' and Password = '$password'";
					$result=mysqli_query($conn, $sql);
                    
                    if (mysqli_num_rows($result)==0) {
                        echo "Tên đăng nhập hoặc mật khẩu không đúng !";
                    }else{
                        $_SESSION['txtUsername'] = $username;
                        header('Location: view.php');
                    }
                }
            }
	        
	    ?>
    </body>
</html>