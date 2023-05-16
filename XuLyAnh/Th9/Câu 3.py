# 3. Tách biên ảnh bằng phương pháp Canny với ngưỡng dưới được lấy từ
# trackbar, ngưỡng trên bằng 2 lần ngưỡng dưới.

import cv2
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg",0)
# lọc ảnh
img2 = cv2.blur(img,(3,3))    

def get_value(x):
    get_value.value = x
get_value.value = 0
#tạo của số
cv2.namedWindow("a")
# tạo trackbar
cv2.createTrackbar('1','a',1,255,get_value)

while(True):
    a = get_value.value
    b = a*2
    img3 = cv2.Canny(img,a,b)
    cv2.imshow("a",img3)
    if cv2.waitKey(5) == ord("q"):
        break
cv2.destroyAllWindows()