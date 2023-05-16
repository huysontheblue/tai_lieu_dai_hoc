#Viết chương trình tạo trackbar để thay đổi độ sáng và độ tương phản của ảnh

import cv2
import numpy as np

def get_contrast(pos):
    get_contrast.value=pos
get_contrast.value=1
def get_brightness(pos):
    get_brightness.value=pos
get_brightness.value=0.0
image = cv.imread("D:\\XuLyAnh\\sondeptrai.jpg")    
if img is None:
    print('khong mo dc file anh')
    exit(0)
    
new_image = np.zeros(image.shape, image.type)

cv2.imshow('Original Image', image)
cv2.namedWindow('output')

cv2.createTrackbar('contrast','output', 0 ,30, get_contrast)
cv2.createTrackbar('brightness','outpu', 0, 127, get_brightness)
cv2.setTrackbarPos('contrast', 'output', 10)
while(True):
    alpha = get_contrast.value/10
    beta = get_brightness.value
    new_image = cv2.convertScaleAbs(image, alpha, beta)
    print(alpha, beta)
    cv2.imshow('output', new_image)
    if cv.waitKey(5000)==ord('q'):break
#cv2.waitKey(0)
cv2.destroyAllWindows()
