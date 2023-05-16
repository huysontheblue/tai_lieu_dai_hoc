#Viết chương trình tạo trackbar để chon ngưỡng, dùng hàm có sẵn của openCV
# để đọc ảnh và chuyển ảnh qua nhị phân. Lưu lại ảnh nhị phân đó

import cv2
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg",0)
def get_nguong(vitri):
    get_nguong.value = vitri
get_nguong.value = 127
cv2.namedWindow('Nhiphan')
cv2.createTrackbar('dentrang:', 'Nhiphan', 127, 200, get_nguong)
while(True):
 #lấy ngưỡng:
 nguong = get_nguong.value
 #hàm phân ngưỡng:
 ret,anh =cv2.threshold(img, nguong, 255, cv2.THRESH_BINARY)
 cv2.imshow('Nhiphan',anh)
 #gọi hàm thay đổi độ sáng 
 #nếu ấn phím space thì thoát
 if cv2.waitKey(5)==ord(' '):
 #nếu ấn space thì thoát
     break
cv2.imwrite('D:\\XuLyAnh\\anh.jpg', anh)
cv2.waitKey(0)
cv2.destroyAllWindows()


