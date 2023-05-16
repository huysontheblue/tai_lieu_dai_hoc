# Ghi văn bản, vẽ các hình đơn giản lên ảnh: đường thẳng, 
# mũi tên, hình tròn, elip, hình chữ nhật, đa giác
import cv2
import numpy as np
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
#Thêm văn bản
font = cv2.FONT_HERSHEY_PLAIN
cv2.putText(img,'hahuyson',(10,500),font,3,(255,255,0),2,cv2.LINE_AA)
#Đường thẳng
cv2.line(img,(10,10),(100,100),(255,255,0),5)
#Mũi tên
cv2.arrowedLine(img, (50,200), (200,200), (0,255,255))
#Hình tròn
cv2.circle(img,(400,400),100,(0,255,0),5)
#Hình elip
cv2.ellipse(img,(250,250),(100,50),0,0,180,(255,255,255),10)
#Hình chữ nhật
cv2.rectangle(img,(300,0),(500,100),(0,255,255),3)
#Hình đa giác
MT = np.array([[100,50],[200,300],[450,200],[400,100]], np.int32)
cv2.polylines(img,[MT],True,(255,255,255))
cv2.imshow('Test',img)
cv2.waitKey(0) 
cv2.destroyAllWindows()