#Tách biên ảnh bằng phương pháp Canny. Tạo trackbar để chọn ngưỡng dưới, ngưỡng trên lấy bằng 3 lần ngưỡng dưới
import cv2

img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg",0)

img2 = cv2.blur(img,(3,3))    

def get_value(x):
    get_value.value = x
get_value.value = 0

cv2.namedWindow("a")

cv2.createTrackbar('1','a',1,85,get_value)

while(True):
    a = get_value.value
    b = a*3
    img3 = cv2.Canny(img,a,b)
    cv2.imshow("a",img3)
    if cv2.waitKey(5) == ord("q"):
        break
cv2.destroyAllWindows()