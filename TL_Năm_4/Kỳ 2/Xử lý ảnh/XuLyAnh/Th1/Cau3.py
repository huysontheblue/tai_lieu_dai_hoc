#Viết chương trình đổi ảnh màu sang ảnh xám, ảnh nhị phân.
#Lưu lại ảnh xám và ảnh nhị phân
import cv2
import numpy as np
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
(height,width)=img.shape[:2]
xam = np.zeros([height,width],dtype = np.uint8)
nhiphan = np.zeros([height,width],dtype = np.uint8)
#0.299*R + 0.587*G + 0.1149*B
nguong = 128
for i in range(height):
    for j in range(width):
        xam[i, j] = int(0.299*img[i,j,2]+0.857*img[i,j,1]+0.114*img[i,j,0])
        if xam[i,j] < nguong:
            nhiphan[i,j]=0
        else: nhiphan[i,j]=255
# hiện ảnh    
cv2.imshow("Hien anh goc",img)
cv2.imshow("Hien anh xam",xam)
cv2.imshow("Hien anh nhi phan",nhiphan)
# Lưu ảnh
cv2.imwrite("D:\\XuLyAnh\\Th1\\xamc3.jpg", xam)
cv2.imwrite("D:\\XuLyAnh\\Th1\\nhipahnc3.jpg", nhiphan)
cv2.waitKey(0)
cv2.destroyAllWindows() 