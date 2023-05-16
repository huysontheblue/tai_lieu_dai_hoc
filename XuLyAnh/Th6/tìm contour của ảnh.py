import cv2
import numpy as np
# đọc ảnh
img = cv2.imread("E:\\XuLyAnh\\sondeptrai.jpg", cv2.IMREAD_UNCHANGED)

# chuyển qua ảnh xám
img_grey = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)

#  phân ngưỡng cho ảnh 
ret,thresh_img = cv2.threshold(img_grey, 100, 255, cv2.THRESH_BINARY)

# tìm đường viền
contours, hierarchy = cv2.findContours(thresh_img, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)

# taoh một hình ảnh trống cho các đường viền
img_contours = np.zeros(img.shape)

# vẽ các đường viền trên hình trống
cv2.drawContours(img_contours, contours, -1, (255,0,255), 1)
#save image
cv2.imshow('Contuor', img_contours)
cv2.waitKey()
cv2.destroyAllWindows()