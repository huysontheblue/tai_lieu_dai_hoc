# Dịch chuyển ảnh với khoảng cách trục x, trục y thay đổi 
# lấy từ trackbar.
import cv2
import numpy as np
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
def get_trucx(vitri):
    get_trucx.value = vitri
def get_trucy(vitri):
    get_trucy.value = vitri
get_trucx.value = 0
get_trucy.value = 0
cv2.namedWindow('Dichanh')
cv2.createTrackbar('trucx', 'Dichanh', 0, 150, get_trucx)
cv2.createTrackbar('trucy', 'Dichanh', 0, 150, get_trucy)
while(True):
    alpha = get_trucx.value
    beta = get_trucy.value
    h,c = img.shape[:2]
    M = np.array([[1,0,alpha],[0,1,beta]],dtype= np.float32)
    img1 = cv2.warpAffine(img, M, (c,h)) 
    cv2.imshow('Dichanh',img1)
    if cv2.waitKey(5)==ord('q'):
        break
cv2.destroyAllWindows()

