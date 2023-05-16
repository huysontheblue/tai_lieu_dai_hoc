#Viết chương trình tạo trackbar để thay đổi độ sáng và độ tương phản của ảnh

import cv2

def get_value(pos):
    get_value.value=pos
    
get_value.value=0

cv2.namedWindow('trackbar')
cv2.createTrackbar('value', 'trackbar',0,255,get_value)

img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
cv2.imshow('trackbar', img)
alpha=1
while(True):
    beta = get_value.value
    img1 = cv2.convertScaleAbs(img,alpha=alpha,beta=beta)
    if cv2.waitKey(5)==ord('q'):
        break
cv2.destroyAllWindows()
