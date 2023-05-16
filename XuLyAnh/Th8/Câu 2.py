#  Đọc ảnh và thực hiện các thao tác sau:
# - Tạo trackbar để lấy giá trị phân ngưỡng.
# - Phân vùng ảnh bằng phương pháp phân ngưỡng nhị phân
# - Thực hiện phép giãn nở ảnh
# - Ấn phím Q để lưu lại ảnh kết quả

import cv2
import numpy as np
img = cv2.imread("D:\\XuLyAnh\\hoahong.png",0)
def get_nguong(vitri):
    get_nguong.value = vitri
get_nguong.value =127
kernel = np.ones((5,5), np.uint8)
cv2.namedWindow('Nhiphan')
cv2.createTrackbar('dentrang','Nhiphan',127,200,get_nguong)
while(True):
    nguong = get_nguong.value
    ret,anh = cv2.threshold(img,nguong,255,cv2.THRESH_BINARY)
    img2 = cv2.dilate(img, kernel, iterations=1)
    cv2.imshow('Nhiphan',anh)
    cv2.imshow('Gian',img2)
    if cv2.waitKey(5) == ord('q'):
        cv2.imwrite('D:\\np.jpg', anh)
        cv2.imwrite('D:\\gian.jpg', img2)
        break
cv2.waitKey(0)
cv2.destroyAllWindows()
